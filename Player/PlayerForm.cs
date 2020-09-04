using System;
using System.Collections.Generic;
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
using PcapDotNet.Packets.Ethernet;
using PcapDotNet.Packets.IpV4;

namespace Player
{
    public partial class PlayerForm : Form
    {
        private Point _lastHit;
        private PacketInfo[] _packets;
        private DeviceInfo[] _devices;

        public PlayerForm()
        {
            InitializeComponent();

            Icon = Icon.FromHandle(new Bitmap(Properties.Resources.play).GetHicon());
        }

        private void InitLists()
        {
            lstPackets.Columns.AddRange(new ColumnHeader[]
            {
                new OLVColumn("#", "Num"),
                new OLVColumn("TimeStamp", "TimeStamp"),
                new OLVColumn("Length", "Length"),
                new OLVColumn("Protocol", "Protocol"),
                new OLVColumn("Kind", "Kind"),
            });

            lstDevices.Columns.AddRange(new ColumnHeader[]
            {
                new OLVColumn("Description", "Description"),
                new OLVColumn("Address", "Address"),
                new OLVColumn("MAC", "Mac"),
                new OLVColumn("Name", "Name")
            });

            lstLog.Columns.AddRange(new ColumnHeader[]
            {
                new OLVColumn("Time", "Time"),
                new OLVColumn("Message", "Message"),
            });

            var menu = new ContextMenuStrip();

            menu.Items.Add("Send Packet", Properties.Resources.play, SendPackets);
            menu.Items.Add("Save To Pcap", Properties.Resources.wireshark, SavePackets);
            menu.Items.Add("Copy Packet To Clipboard", Properties.Resources.clipboard, CopyPackets);
            
            lstPackets.ContextMenuStrip = menu;

            lstDevices.UseCustomSelectionColors = true;
            lstDevices.HighlightBackgroundColor = Color.CornflowerBlue;
            lstDevices.UnfocusedHighlightBackgroundColor = Color.CornflowerBlue;

            lstDevices.MouseUp += LstDevicesOnMouseUp;
          
            var deviceMenu = new ContextMenuStrip();
            deviceMenu.Items.Add("Copy", Properties.Resources.clipboard, OnCopy);
            lstDevices.ContextMenuStrip = deviceMenu;
        }

        private void LstDevicesOnMouseUp(object sender, MouseEventArgs e)
        {
            _lastHit = e.Location;
        }

        private void OnCopy(object sender, EventArgs e)
        {
            try
            {
                var hit = lstDevices.HitTest(_lastHit);

                if (hit.Item == null)
                {
                    return;
                }

                Clipboard.SetText(hit.SubItem.Text);
            }
            catch
            {
                // ignored
            }
        }

        private async void PlayerForm_Load(object sender, EventArgs e)
        {
            try
            {
                InitLists();

                Text = $@"Player (Version {Properties.Settings.Default.Version})";

                await LoadDevices();
            }
            catch (Exception ex)
            {
                Log(ex);
            }
        }

        private void SavePackets(object sender, EventArgs e)
        {
            try
            {
                string path;

                if (_devices.Length == 0)
                {
                    throw new Exception("At least one interface should be found");
                }

                using (var dlg = new SaveFileDialog
                {
                    Title = @"Save Packets",
                    Filter = @"pcap files (*.pcap;*.pcapng)|*.pcap;*.pcapng",
                    RestoreDirectory = true})
                {
                    if (dlg.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    path = dlg.FileName;
                }

                var packets = lstPackets.SelectedObjects.Cast<PacketInfo>().ToArray();

                using (var communicator =
                    _devices[0].Device.Open(65536,
                        PacketDeviceOpenAttributes.Promiscuous,
                        1000))
                {
                    using (var dumpFile = communicator.OpenDump(path))
                    {
                        foreach (var packet in packets)
                        {
                            dumpFile.Dump(packet.Packet);
                        }
                    }
                }

                Log($"Saved {packets.Length} packets to {path}");
            }
            catch (Exception ex)
            {
                Log(ex);
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
                Log(ex);
            }
        }

        private void CopyPackets(object sender, EventArgs e)
        {
            try
            {
                var packets = lstPackets.SelectedObjects.Cast<PacketInfo>()
                    .Select(p => BitConverter.ToString(p.Packet.Buffer).Replace("-", string.Empty)).ToArray();

                var length = string.Join(", ", packets.Select(p => $"{p.Length / 2} bytes"));
                Log($"Copied {packets.Length} packets to clipboard. ({length})");

                Clipboard.SetText(string.Join("\n", packets));
            }
            catch (Exception ex)
            {
                Log(ex);
            }
        }

        private void SendPackets(PacketInfo[] packets)
        {
            try
            {
                var devices = lstDevices.SelectedObjects;
                if (devices.Count == 0)
                {
                    throw new Exception("Select at least one interface from list below");
                }

                if (packets.Length == 0)
                {
                    throw new Exception("Select at least one packet");
                }

                foreach (DeviceInfo device in devices)
                {
                    var currDevice = device;
                    int.TryParse(txtDelay.Text, out var delayMs);
                    int.TryParse(txtNumTimes.Text, out var numTimes);

                    var srcMac = txtSrcMac.Enabled ? txtSrcMac.Text : chkSrcMac.Checked ?  device.Mac : null;
                    var dstMac = txtDstMac.Enabled ? txtDstMac.Text : chkDstMac.Checked ?  device.Mac : null;
                    var srcIp = txtSrcIp.Enabled ? txtSrcIp.Text : chkSrcIp.Checked ?  device.Address : null;
                    var dstIp = txtDstIp.Enabled ? txtDstIp.Text : chkDstIp.Checked ?  device.Address : null;

                    var msg = $"Sending {packets.Length} packets on {device.Description} ({device.Address})";
                    
                    if (srcMac != null)
                    {
                        msg = $"{msg} from src MAC {srcMac}";
                    }

                    if (dstMac != null)
                    {
                        msg = $"{msg} to dst MAC {dstMac}";
                    }

                    if (srcIp != null)
                    {
                        msg = $"{msg} from src IP {srcIp}";
                    }

                    if (dstIp != null)
                    {
                        msg = $"{msg} to dst IP {dstIp}";
                    }

                    if (delayMs > 0)
                    {
                        msg = $"{msg} with delay of {delayMs} ms";
                    }

                    if (numTimes != 0)
                    {
                        msg = numTimes == -1 ?  $"{msg} infinite times" : $"{msg} {numTimes} times";
                    }
                    else
                    {
                        numTimes = 1;
                    }

                    if (chkIpOption.Checked)
                    {
                        msg = $"{msg} (with IP Options)";
                    }

                    Log(msg);

                    ThreadPool.QueueUserWorkItem(_ => SendPacketsImp(packets, 
                        currDevice, 
                        delayMs, 
                        numTimes, 
                        chkRandom.Checked, 
                        srcMac, 
                        dstMac, 
                        srcIp, 
                        dstIp));
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message, true);
            }
        }

        private void ToggleBusy(bool busy)
        {
            tsProg.Style = busy ? ProgressBarStyle.Marquee : ProgressBarStyle.Continuous;
        }

        private string GetMac(LivePacketDevice device)
        {
            try
            {
                var mac = device.GetMacAddress();
                return mac.ToString();
            }
            catch
            {
                return null;
            }
        }
        private async Task LoadDevices()
        {
            ToggleBusy(true);

            try
            {
                Log("Fetching interface list..");

                await Task.Run(() =>
                {
                    var allDevices = LivePacketDevice.AllLocalMachine.ToArray();

                    _devices = allDevices.AsParallel().Select(d => new DeviceInfo
                    {
                        Name = GetName(d.Name),
                        Description = d.Description,
                        Address = string.Join(",", d.Addresses.
                            Where(a => a.Address.Family == SocketAddressFamily.Internet).
                            Select(a => a.Address.ToString().Split(' ')[1]).
                            ToArray()),
                        Mac = GetMac(d),
                        Device = d
                    }).OrderByDescending(a => a.Address).ToArray();
                });

                Log($"Found {_devices.Length} interfaces");

                lstDevices.SetObjects(_devices);
                lstDevices.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                Log(ex);
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

        private async Task LoadFile(bool fromClipboard)
        {
            var packets = new List<Packet>();

            if (!fromClipboard)
            {
                var file = txtPath.Text;
                if (!File.Exists(file))
                {
                    throw new Exception("File not found - " + file);
                }

                Log("Loading packets from file " + file);

                var ext = Path.GetExtension(file);
                if (ext == ".pcap" || ext == ".pcapng")
                {
                    var dumpFile = new OfflinePacketDevice(file);

                    await Task.Run(() =>
                    {
                        using (var communicator =
                            dumpFile.Open(65536,
                                PacketDeviceOpenAttributes.None,
                                1000))
                        {
                            while (true)
                            {
                                try
                                {
                                    communicator.ReceivePacket(out var packet);
                                    if (packet == null)
                                    {
                                        break;
                                    }

                                    packets.Add(packet);
                                }
                                catch (Exception e)
                                {
                                    Log(e);
                                }
                            }
                        }
                    });
                }
                else
                {
                    packets = new List<Packet>
                    {
                        new Packet(File.ReadAllBytes(file), DateTime.Now, DataLinkKind.Ethernet)
                    };
                }
            }
            else
            {
                string txt = null;

                try
                {
                    txt = Clipboard.GetText();
                }
                catch
                {
                    // ignored
                }

                if (string.IsNullOrEmpty(txt))
                {
                    throw new Exception("Clipboard is empty");
                }

                foreach (var line in txt.Split(new [] {'\n'}, StringSplitOptions.RemoveEmptyEntries).Select(l => l.Trim()))
                {
                    var bytes = Enumerable.Range(0, line.Length)
                        .Where(x => x % 2 == 0)
                        .Select(x => Convert.ToByte(txt.Substring(x, 2), 16))
                        .ToArray();

                    Log($"Loading packet from clipboard ({bytes.Length}) bytes)");

                    packets.Add(new Packet(bytes, DateTime.Now, DataLinkKind.Ethernet));
                }
            }

            _packets = packets.Select((p, i) => new PacketInfo
            {
                Num = i + 1,
                TimeStamp = p.Timestamp,
                Length = p.Length,
                Kind = p.DataLink.Kind,
                Protocol = GetPacketProto(p).ToString(),
                Packet = p
            }).ToArray();

            lstPackets.SetObjects(_packets);

            lstPackets.AutoResizeColumns();

            SetColumnWidth(lstPackets, "Length", 80);
            SetColumnWidth(lstPackets, "Protocol", 80);
        }

        private void SetColumnWidth(ListView lst, string title, int width)
        {
            var col = lst.Columns.Cast<OLVColumn>().FirstOrDefault(c => c.Text == title);
            if (col == null)
            {
                throw new Exception("Failed to get column - " + title);
            }

            col.Width = width;
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            LoadFromFile(true);
        }

        private void LoadFromFile(bool pcap)
        {
            try
            {
                using (var dlg = new OpenFileDialog
                {
                    Title = @"Open File",
                    CheckFileExists = true,
                    CheckPathExists = true,
                    Filter = pcap ? @"pcap files (*.pcap;*.pcapng)|*.pcap;*.pcapng" : "",
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

                    OnLoadFile(false);
                }
            }
            catch (Exception ex)
            {
                Log(ex);
            }
        }

        private void UpdateNumPackets(int num)
        {
            tsNum.Text = $@"{num} packets";
            Log($"Showing {num} packets");
        }

        private async void OnLoadFile(bool fromClipboard)
        {
            try
            {
                ToggleBusy(true);

                tsWireshark.Enabled = File.Exists(txtPath.Text);

                await LoadFile(fromClipboard);

                UpdateNumPackets(_packets.Length);

                grpPackets.Enabled = true;
            }
            catch (Exception ex)
            {
                Log(ex);
                grpPackets.Enabled = false;
                txtPath.Text = null;
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
                Log(ex);
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

        private IpV4Protocol GetPacketProto(Packet packet)
        {
            switch (packet.Ethernet.EtherType)
            {
                case EthernetType.IpV6:
                    return packet.Ethernet.IpV6.NextHeader;

                case EthernetType.IpV4:
                    return packet.Ethernet.IpV4.Protocol;

                default:
                    return IpV4Protocol.EtherIp;
            }
        }

        private static void Randomize<T>(IList<T> items)
        {
            var rand = new Random((int) DateTime.Now.Ticks);

            for (var i = 0; i < items.Count - 1; i++)
            {
                var j = rand.Next(i, items.Count);
                var temp = items[i];
                items[i] = items[j];
                items[j] = temp;
            }
        }

        private void SendPacketsImp(IList<PacketInfo> packets,
            DeviceInfo device,
            int delayMs,
            int numTimes,
            bool random,
            string srcMac = null,
            string dstMac = null,
            string srcIp = null,
            string dstIp = null)
        {
            try
            {
                using (var communicator =
                    device.Device.Open(65536, 
                        PacketDeviceOpenAttributes.None,
                        1000))
                {
                    for (var i = 0; i < numTimes; ++i)
                    {
                        if (random)
                        {
                            Randomize<PacketInfo>(packets);
                        }

                        foreach (var p in packets)
                        {
                            var packet = p.Packet;

                            if (chkIpOption.Checked || srcMac != null || dstMac != null || srcIp != null ||  dstIp != null)
                            {
                                var ethernet = (EthernetLayer) packet.Ethernet.ExtractLayer();

                                var layers = new List<ILayer>();

                                if (srcMac != null)
                                {
                                    ethernet.Source = new MacAddress(srcMac);
                                }

                                if (dstMac != null)
                                {
                                    ethernet.Destination = new MacAddress(dstMac);
                                }

                                layers.Add(ethernet);

                                if (ethernet.EtherType == EthernetType.IpV4)
                                {
                                    var ipV4Layer = (IpV4Layer) packet.Ethernet.IpV4.ExtractLayer();
                                    if (srcIp != null)
                                    {
                                        ipV4Layer.Source = new IpV4Address(srcIp);
                                    }

                                    if (dstIp != null)
                                    {
                                        ipV4Layer.CurrentDestination = new IpV4Address(dstIp);
                                    }

                                    if (chkIpOption.Checked)
                                    {
                                        ipV4Layer.Options = new IpV4Options(new IpV4OptionBasicSecurity());
                                    }

                                    var payload = (PayloadLayer) packet.Ethernet.IpV4.Payload.ExtractLayer();

                                    ipV4Layer.HeaderChecksum = null;

                                    layers.Add(ipV4Layer);
                                    layers.Add(payload);
                                }
                                else
                                {
                                    var payload = (PayloadLayer) packet.Ethernet.Payload.ExtractLayer();
                                    layers.Add(payload);
                                }

                                var packetTimestamp = packet.Timestamp;

                                packet = new PacketBuilder(layers.ToArray()).Build(packetTimestamp);
                            }

                            communicator.SendPacket(packet);

                            if (delayMs > 0)
                            {
                                Thread.Sleep(delayMs);
                            }
                        }

                        Log($"Sent {packets.Count} packets on {device.Description} ({device.Address})");
                    }
                }
            }
            catch (Exception e)
            {
                Log(e);
            }
        }

        private void Log(Exception ex)
        {
            Log(ex.Message, true);
        }

        private void Log(string message, bool error = false)
        {
            try
            {
                if (InvokeRequired)
                {
                    BeginInvoke((Action)(() => Log(message, error)));
                    return;
                }

                var msg = new LogMessage
                {
                    Time = DateTime.Now.ToString("HH:mm:ss"),
                    Message = message
                };

                lstLog.AddObject(msg);

                if (error)
                {
                    lstLog.Items[lstLog.Items.Count - 1].ForeColor = Color.Red;
                }

                lstLog.AutoResizeColumns();

                SetColumnWidth(lstLog, "Message", 400);
            }
            catch
            {
                // ignored
            }
        }

        private void btnSendAll_Click(object sender, EventArgs e)
        {
            try
            {
                SendPackets(_packets);
            }
            catch (Exception ex)
            {
                Log(ex);
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
                Log(ex);
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
                Log(ex);
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

            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void lnkDelay_Click(object sender, EventArgs e)
        {
            ShowLink(@"Delay", @"Add delay between packet sending (in milliseconds)");
        }

        private void lnkIpOptions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLink(@"IP Options", @"Add IP Options to sent packets (Security - 3)");
        }

        private void lnkSend_Click(object sender, EventArgs e)
        {
            ShowLink(@"Send Packets", "Send all packets in pcap file.\nRight click packet(s) to send individually");
        }

        private async Task SendMail()
        {
            try
            {
                await Task.Run(() =>
                {
                    Log("Sending mail..");

                    const string Subject = "Feedback from Player";
                    const string Mail = "inbar.rotem@gmail.com";
                    var mail = $"mailto:{Mail}?subject={Subject}";
                    Process.Start(mail);
                });
            }
            catch (Exception ex)
            {
                Log(ex);
            }
        }

        private async void tsFeedback_Click(object sender, EventArgs e)
        {
            await SendMail();
        }

        private void fromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFromFile(false);
        }

        private void fromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnLoadFile(true);
        }

        private void lnkLoad_Click(object sender, EventArgs e)
        {
            ShowLink(@"Load Packet", @"Load packet bytes from file or from clipboard (as hex string)");
        }

        private void chkSrcMac_CheckedChanged(object sender, EventArgs e)
        {
            chkSrcInterfaceMac.Enabled = txtSrcMac.Enabled = chkSrcMac.Checked;
        }

        private void chkInterfaceMac_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtSrcMac.Enabled = !chkSrcInterfaceMac.Checked;
                if (chkSrcInterfaceMac.Checked)
                {
                    txtSrcMac.Text = null;
                }
            }
            catch (Exception ex)
            {
                Log(ex);
            }
        }

        private void chkDstMac_CheckedChanged(object sender, EventArgs e)
        {
            chkDstInterfaceMac.Enabled = txtDstMac.Enabled = chkDstMac.Checked;
        }

        private void chkDstInterfaceMac_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtDstMac.Enabled = !chkDstInterfaceMac.Checked;
                if (chkDstInterfaceMac.Checked)
                {
                    txtDstMac.Text = null;
                }
            }
            catch (Exception ex)
            {
                Log(ex);
            }
        }

        private void lnkNumTimes_Click(object sender, EventArgs e)
        {
            ShowLink(@"Num Times", @"Send the specified packets X times (-1 for infinite)");
        }

        private void txtNumTimes_Click(object sender, EventArgs e)
        {
            txtNumTimes.BackColor = string.IsNullOrEmpty(txtNumTimes.Text) ? Color.White : Color.GreenYellow;
        }

        private void chkSrcInterfaceIp_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtSrcIp.Enabled = !chkSrcInterfaceIp.Checked;
                if (chkSrcInterfaceIp.Checked)
                {
                    txtSrcIp.Text = null;
                }
            }
            catch (Exception ex)
            {
                Log(ex);
            }
        }

        private void chkSrcIp_CheckedChanged(object sender, EventArgs e)
        {
            chkSrcInterfaceIp.Enabled = txtSrcIp.Enabled = chkSrcIp.Checked;
        }

        private void chkDstIp_CheckedChanged(object sender, EventArgs e)
        {
            chkDstInterfaceIp.Enabled = txtDstIp.Enabled = chkDstIp.Checked;
        }

        private void chkDstInterfaceIp_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtDstIp.Enabled = !chkDstInterfaceIp.Checked;
                if (chkDstInterfaceIp.Checked)
                {
                    txtDstIp.Text = null;
                }
            }
            catch (Exception ex)
            {
                Log(ex);
            }
        }

        private void lnkChangeFields_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLink(@"Change Fields", 
                     "Change specified fields in the packets before sending.\n" + 
                    "As Interface - will set the field as the corresponding value from the sending interface");
        }

        private static void ShowLink(string title, string msg)
        {
            MessageBox.Show(
                msg,
                title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }

    public class PacketInfo
    {
        public int Num;
        public DateTime TimeStamp;
        public int Length;
        public DataLinkKind Kind;
        public string Protocol;
        public Packet Packet;
    }

    public class DeviceInfo
    {
        public string Description;
        public string Address;
        public string Mac;
        public string Name;
        public LivePacketDevice Device;
    }

    public class LogMessage
    {
        public string Time;
        public string Message;
    }
}
