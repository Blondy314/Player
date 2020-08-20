using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using PcapDotNet.Core;
using PcapDotNet.Core.Extensions;
using PcapDotNet.Packets;

namespace Player
{
    public partial class PlayerForm : Form
    {
        private PacketInfo[] _packets;
        private DeviceInfo[] _devices;

        public PlayerForm()
        {
            InitializeComponent();

            Icon = Icon.FromHandle(new Bitmap(Properties.Resources.play).GetHicon());

            lstPackets.Columns.AddRange(new ColumnHeader[]
            {
                new OLVColumn("#", "Num"),
                new OLVColumn("TimeStamp", "TimeStamp"),
                new OLVColumn("Length", "Length"),
                new OLVColumn("Kind", "Kind"),

            });
            
            lstDevices.Columns.AddRange(new ColumnHeader[]
            {
                new OLVColumn("Description", "Description"),
                new OLVColumn("Address", "Address"),
                new OLVColumn("Name", "Name")
            });
        }

        private async void PlayerForm_Load(object sender, EventArgs e)
        {
            try
            {
                ContextMenu = new ContextMenu(new[]
                {
                    new MenuItem("Send Packet", SendPackets),
                });

                await LoadDevices();
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void SendPackets(object sender, EventArgs e)
        {
            try
            {
                SendPackets(lstPackets.SelectedObjects.Cast<PacketInfo>().ToArray());
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void SendPackets(PacketInfo[] packets)
        {
            try
            {
                var devices = lstDevices.SelectedObjects;
                if (devices.Count == 0)
                {
                    throw new Exception("Select at least one device");
                }

                if (packets.Length == 0)
                {
                    throw new Exception("Select at least one packet");
                }

                foreach (DeviceInfo device in devices)
                {
                    Log($"Sending {packets.Length} packets on {device.Address}");

                    var currDevice = device;
                    ThreadPool.QueueUserWorkItem(_ => SendPackets(packets, currDevice));
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void ToggleBusy(bool busy)
        {
            tsProg.Style = busy ? ProgressBarStyle.Marquee : ProgressBarStyle.Continuous;
        }

        private async Task LoadDevices()
        {
            ToggleBusy(true);

            try
            {
                var allDevices = new LivePacketDevice[0];

                await Task.Run(() =>
                {
                    allDevices = LivePacketDevice.AllLocalMachine.ToArray();
                });

                _devices = allDevices.Select(d => new DeviceInfo
                {
                    Name = GetName(d.Name),
                    Description = d.Description,
                    Address = string.Join(",", d.Addresses.
                        Where(a => a.Address.Family == SocketAddressFamily.Internet).
                        Select(a => a.Address.ToString().Split(' ')[1]).
                        ToArray()),
                    Device = d
                }).OrderByDescending(a => a.Address).ToArray();

                Log($"Found {_devices.Length} devices");

                lstDevices.SetObjects(_devices);

                lstDevices.AutoResizeColumns();
                lstDevices.CalculateReasonableTileSize();
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
            finally
            {
                ToggleBusy(false);
                tsNumInterfaces.Text = $@"{_devices.Length} Interfaces.";
            }
        }

        private string GetName(string str)
        {
            try
            {
                if (!str.Contains("_"))
                {
                    return str;
                }

                return str.Split('_')[1];
            }
            catch
            {
                return str;
            }
        }

        private async Task LoadFile()
        {
            var file = txtPath.Text;
            if (!File.Exists(file))
            {
                throw new Exception("File not found - " + file);
            }

            Log("Loading packets from file " + file);

            var dumpFile = new OfflinePacketDevice(file);

            Packet[] packets;

            await Task.Run(() =>
            {
                using (var communicator =
                    dumpFile.Open(65536,
                        PacketDeviceOpenAttributes.None,
                        1000))
                {
                    packets = communicator.ReceivePackets().ToArray();
                }

                _packets = packets.Select((p, i) => new PacketInfo
                {
                    Num = i + 1,
                    TimeStamp = p.Timestamp,
                    Length = p.Length,
                    Kind = p.DataLink.Kind,
                    Packet = p
                }).ToArray();
            });

            lstPackets.SetObjects(_packets);

            lstPackets.AutoResizeColumns();
            lstPackets.CalculateReasonableTileSize();

            SetColumnWidth("Length", 80);
        }

        private void SetColumnWidth(string title, int width)
        {
            var col = lstPackets.Columns.Cast<OLVColumn>().FirstOrDefault(c => c.Text == title);
            if (col == null)
            {
                throw new Exception("Failed to get column - " + title);
            }

            col.Width = width;
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dlg = new OpenFileDialog
                {
                    Title = @"Browse Text Files",

                    CheckFileExists = true,
                    CheckPathExists = true,
                    Filter = @"pcap files (*.pcap)|*.pcap",
                    FilterIndex = 2,
                    RestoreDirectory = true,
                    ReadOnlyChecked = true,
                    ShowReadOnly = true
                })
                {
                    if (dlg.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    txtPath.Text = dlg.FileName;
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void UpdateNumPackets(int num)
        {
            tsNum.Text = $@"{num} packets";
            Log($"Showing {num} packets");
        }

        private async void txtPath_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ToggleBusy(true);

                tsWireshark.Enabled = File.Exists(txtPath.Text);

                await LoadFile();
                UpdateNumPackets(_packets.Length);

                grpPackets.Enabled = true;
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                grpPackets.Enabled = false;
            }
            finally
            {
                ToggleBusy(false);
            }
        }

        private async void BtnInterfaces_Click(object sender, EventArgs e)
        {
            try
            {
                await LoadDevices();
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void PlayerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }

            if (e.KeyCode == Keys.C && e.Alt)
            {
                btnChoose_Click(sender, e);
            }
        }

        private void SendPackets(PacketInfo[] packets, DeviceInfo device)
        {
            try
            {
                using (PacketCommunicator communicator =
                    device.Device.Open(65536, 
                        PacketDeviceOpenAttributes.None,
                        1000))
                {
                    foreach (var packet in packets)
                    {
                        communicator.SendPacket(packet.Packet);
                    }

                    Log($"Sent {packets.Length} packets on {device.Address}");
                }
            }
            catch (Exception e)
            {
                Log(e.Message);
            }
        }
        private void Log(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => Log(message)));
                return;
            }

            var time = DateTime.Now.ToString("HH:mm:ss");
            txtLog.AppendText($"{time}: {message}\r\n");
        }

        private void btnSendAll_Click(object sender, EventArgs e)
        {
            try
            {
                var devices = lstDevices.SelectedObjects;
                if (devices.Count == 0)
                {
                    throw new Exception("Select at least one device");
                }

                foreach (DeviceInfo device in devices)
                {
                    Log($"Sending {_packets.Length} packets on {device.Address}");

                    var currDevice = device;
                    ThreadPool.QueueUserWorkItem(_ => SendPackets(_packets, currDevice));
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void tsWireshark_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(txtPath.Text);
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private bool AnswersBpf(Packet packet, string bpf)
        {
            return new BerkeleyPacketFilter(bpf, 65536, DataLinkKind.Ethernet).Test(packet);
        }
        
        private void tsFilterGo_Click(object sender, EventArgs e)
        {
            try
            {
                if (tsBpf.TextLength == 0)
                {
                    Log("Removing BPF");
                }
                else
                {
                    Log("Setting BPF to " + tsBpf.Text);
                }

                var filtered = _packets.Where(p => AnswersBpf(p.Packet, tsBpf.Text)).ToArray();
                
                lstPackets.SetObjects(filtered);
                UpdateNumPackets(filtered.Length);

                tsBpf.BackColor = tsBpf.Text.Length > 0  ? Color.GreenYellow : Color.White;
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                tsBpf.BackColor = Color.Salmon;
            }
        }

        private void tsBpf_TextChanged(object sender, EventArgs e)
        {
            tsBpf.BackColor = Color.LightGray;
        }

        private void tsBpf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            tsFilterGo_Click(sender, e);
        }
    }

    public class PacketInfo
    {
        public int Num;
        public DateTime TimeStamp;
        public int Length;
        public DataLinkKind Kind;
        public Packet Packet;
    }

    public class DeviceInfo
    {
        public string Description;
        public string Address;
        public string Name;
        public LivePacketDevice Device;
    }
}
