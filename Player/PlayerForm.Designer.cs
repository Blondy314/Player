using BrightIdeasSoftware;

namespace Player
{
    partial class PlayerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerForm));
            this.lstPackets = new BrightIdeasSoftware.ObjectListView();
            this.lstDevices = new BrightIdeasSoftware.ObjectListView();
            this.grpPackets = new System.Windows.Forms.GroupBox();
            this.chkRandom = new System.Windows.Forms.CheckBox();
            this.lnkIpOptions = new System.Windows.Forms.LinkLabel();
            this.chkIpOption = new System.Windows.Forms.CheckBox();
            this.tsPackets = new System.Windows.Forms.ToolStrip();
            this.tsNum = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsSendAll = new System.Windows.Forms.ToolStripButton();
            this.lnkSend = new System.Windows.Forms.ToolStripLabel();
            this.tsFilterGo = new System.Windows.Forms.ToolStripButton();
            this.tsBpf = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.txtDelay = new System.Windows.Forms.ToolStripTextBox();
            this.lnkDelay = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.txtNumTimes = new System.Windows.Forms.ToolStripTextBox();
            this.lnkNumTimes = new System.Windows.Forms.ToolStripLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsNumInterfaces = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtPath = new System.Windows.Forms.ToolStripTextBox();
            this.tsChoose = new System.Windows.Forms.ToolStripButton();
            this.tsWireshark = new System.Windows.Forms.ToolStripButton();
            this.tsFeedback = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tsProg = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.fromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lnkLoad = new System.Windows.Forms.ToolStripLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstLog = new BrightIdeasSoftware.ObjectListView();
            this.chkSrcMac = new System.Windows.Forms.CheckBox();
            this.txtSrcMac = new System.Windows.Forms.TextBox();
            this.chkSrcInterfaceMac = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkDstInterfaceMac = new System.Windows.Forms.CheckBox();
            this.txtDstMac = new System.Windows.Forms.TextBox();
            this.chkDstMac = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.chkDstInterfaceIp = new System.Windows.Forms.CheckBox();
            this.txtDstIp = new System.Windows.Forms.TextBox();
            this.chkDstIp = new System.Windows.Forms.CheckBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.chkSrcInterfaceIp = new System.Windows.Forms.CheckBox();
            this.txtSrcIp = new System.Windows.Forms.TextBox();
            this.chkSrcIp = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lnkChangeFields = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.lstPackets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstDevices)).BeginInit();
            this.grpPackets.SuspendLayout();
            this.tsPackets.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstLog)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lstPackets
            // 
            this.lstPackets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstPackets.FullRowSelect = true;
            this.lstPackets.GridLines = true;
            this.lstPackets.HideSelection = false;
            this.lstPackets.Location = new System.Drawing.Point(0, 0);
            this.lstPackets.Name = "lstPackets";
            this.lstPackets.ShowGroups = false;
            this.lstPackets.Size = new System.Drawing.Size(724, 274);
            this.lstPackets.TabIndex = 3;
            this.lstPackets.UseCompatibleStateImageBehavior = false;
            this.lstPackets.UseExplorerTheme = true;
            this.lstPackets.View = System.Windows.Forms.View.Details;
            // 
            // lstDevices
            // 
            this.lstDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDevices.FullRowSelect = true;
            this.lstDevices.GridLines = true;
            this.lstDevices.HideSelection = false;
            this.lstDevices.Location = new System.Drawing.Point(0, 0);
            this.lstDevices.Name = "lstDevices";
            this.lstDevices.ShowGroups = false;
            this.lstDevices.Size = new System.Drawing.Size(1308, 201);
            this.lstDevices.TabIndex = 5;
            this.lstDevices.UseCompatibleStateImageBehavior = false;
            this.lstDevices.View = System.Windows.Forms.View.Details;
            // 
            // grpPackets
            // 
            this.grpPackets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPackets.Controls.Add(this.chkRandom);
            this.grpPackets.Controls.Add(this.lnkIpOptions);
            this.grpPackets.Controls.Add(this.chkIpOption);
            this.grpPackets.Controls.Add(this.tsPackets);
            this.grpPackets.Controls.Add(this.panel1);
            this.grpPackets.Enabled = false;
            this.grpPackets.Location = new System.Drawing.Point(12, 41);
            this.grpPackets.Name = "grpPackets";
            this.grpPackets.Size = new System.Drawing.Size(737, 359);
            this.grpPackets.TabIndex = 7;
            this.grpPackets.TabStop = false;
            this.grpPackets.Text = "Packets";
            // 
            // chkRandom
            // 
            this.chkRandom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkRandom.AutoSize = true;
            this.chkRandom.Location = new System.Drawing.Point(174, 332);
            this.chkRandom.Name = "chkRandom";
            this.chkRandom.Size = new System.Drawing.Size(176, 21);
            this.chkRandom.TabIndex = 9;
            this.chkRandom.Text = "Send In Random Order";
            this.chkRandom.UseVisualStyleBackColor = true;
            // 
            // lnkIpOptions
            // 
            this.lnkIpOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkIpOptions.AutoSize = true;
            this.lnkIpOptions.Location = new System.Drawing.Point(134, 332);
            this.lnkIpOptions.Name = "lnkIpOptions";
            this.lnkIpOptions.Size = new System.Drawing.Size(16, 17);
            this.lnkIpOptions.TabIndex = 8;
            this.lnkIpOptions.TabStop = true;
            this.lnkIpOptions.Text = "?";
            this.lnkIpOptions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkIpOptions_LinkClicked);
            // 
            // chkIpOption
            // 
            this.chkIpOption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIpOption.AutoSize = true;
            this.chkIpOption.Location = new System.Drawing.Point(7, 332);
            this.chkIpOption.Name = "chkIpOption";
            this.chkIpOption.Size = new System.Drawing.Size(124, 21);
            this.chkIpOption.TabIndex = 7;
            this.chkIpOption.Text = "Add IP Options";
            this.chkIpOption.UseVisualStyleBackColor = true;
            // 
            // tsPackets
            // 
            this.tsPackets.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsPackets.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsNum,
            this.toolStripSeparator1,
            this.tsSendAll,
            this.lnkSend,
            this.tsFilterGo,
            this.tsBpf,
            this.toolStripLabel2,
            this.toolStripSeparator2,
            this.toolStripLabel4,
            this.txtDelay,
            this.lnkDelay,
            this.toolStripLabel6,
            this.txtNumTimes,
            this.lnkNumTimes});
            this.tsPackets.Location = new System.Drawing.Point(3, 18);
            this.tsPackets.Name = "tsPackets";
            this.tsPackets.Size = new System.Drawing.Size(731, 27);
            this.tsPackets.TabIndex = 6;
            this.tsPackets.Text = "toolStrip3";
            // 
            // tsNum
            // 
            this.tsNum.Name = "tsNum";
            this.tsNum.Size = new System.Drawing.Size(44, 24);
            this.tsNum.Text = "Num:";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tsSendAll
            // 
            this.tsSendAll.Image = global::Player.Properties.Resources.play;
            this.tsSendAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSendAll.Name = "tsSendAll";
            this.tsSendAll.Size = new System.Drawing.Size(88, 24);
            this.tsSendAll.Text = "Send All";
            this.tsSendAll.Click += new System.EventHandler(this.btnSendAll_Click);
            // 
            // lnkSend
            // 
            this.lnkSend.IsLink = true;
            this.lnkSend.Name = "lnkSend";
            this.lnkSend.Size = new System.Drawing.Size(16, 24);
            this.lnkSend.Text = "?";
            this.lnkSend.Click += new System.EventHandler(this.lnkSend_Click);
            // 
            // tsFilterGo
            // 
            this.tsFilterGo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsFilterGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsFilterGo.Image = global::Player.Properties.Resources.go;
            this.tsFilterGo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFilterGo.Name = "tsFilterGo";
            this.tsFilterGo.Size = new System.Drawing.Size(29, 24);
            this.tsFilterGo.Text = "Go";
            this.tsFilterGo.Click += new System.EventHandler(this.tsFilterGo_Click);
            // 
            // tsBpf
            // 
            this.tsBpf.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsBpf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tsBpf.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tsBpf.Name = "tsBpf";
            this.tsBpf.Size = new System.Drawing.Size(100, 27);
            this.tsBpf.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tsBpf_KeyDown);
            this.tsBpf.TextChanged += new System.EventHandler(this.tsBpf_TextChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(36, 24);
            this.toolStripLabel2.Text = "BPF:";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(83, 24);
            this.toolStripLabel4.Text = "Delay (ms):";
            // 
            // txtDelay
            // 
            this.txtDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDelay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDelay.Name = "txtDelay";
            this.txtDelay.Size = new System.Drawing.Size(30, 27);
            // 
            // lnkDelay
            // 
            this.lnkDelay.IsLink = true;
            this.lnkDelay.Name = "lnkDelay";
            this.lnkDelay.Size = new System.Drawing.Size(16, 24);
            this.lnkDelay.Text = "?";
            this.lnkDelay.Click += new System.EventHandler(this.lnkDelay_Click);
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(87, 24);
            this.toolStripLabel6.Text = "Num Times:";
            // 
            // txtNumTimes
            // 
            this.txtNumTimes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumTimes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNumTimes.Name = "txtNumTimes";
            this.txtNumTimes.Size = new System.Drawing.Size(50, 27);
            this.txtNumTimes.TextChanged += new System.EventHandler(this.txtNumTimes_Click);
            // 
            // lnkNumTimes
            // 
            this.lnkNumTimes.IsLink = true;
            this.lnkNumTimes.Name = "lnkNumTimes";
            this.lnkNumTimes.Size = new System.Drawing.Size(16, 24);
            this.lnkNumTimes.Text = "?";
            this.lnkNumTimes.Click += new System.EventHandler(this.lnkNumTimes_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lstPackets);
            this.panel1.Location = new System.Drawing.Point(7, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(724, 274);
            this.panel1.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.toolStrip1);
            this.groupBox2.Location = new System.Drawing.Point(9, 406);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1320, 260);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Interfaces";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.lstDevices);
            this.panel2.Location = new System.Drawing.Point(6, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1308, 201);
            this.panel2.TabIndex = 7;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsRefresh,
            this.tsNumInterfaces});
            this.toolStrip1.Location = new System.Drawing.Point(3, 230);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1314, 27);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsRefresh
            // 
            this.tsRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsRefresh.Image")));
            this.tsRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsRefresh.Name = "tsRefresh";
            this.tsRefresh.Size = new System.Drawing.Size(82, 24);
            this.tsRefresh.Text = "Refresh";
            this.tsRefresh.Click += new System.EventHandler(this.BtnInterfaces_Click);
            // 
            // tsNumInterfaces
            // 
            this.tsNumInterfaces.Name = "tsNumInterfaces";
            this.tsNumInterfaces.Size = new System.Drawing.Size(88, 24);
            this.tsNumInterfaces.Text = "0 Interfaces.";
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtPath,
            this.tsChoose,
            this.tsWireshark,
            this.tsFeedback,
            this.toolStripLabel3,
            this.tsProg,
            this.toolStripDropDownButton1,
            this.lnkLoad});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1344, 32);
            this.toolStrip2.TabIndex = 13;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(70, 29);
            this.toolStripLabel1.Text = "Pcap File:";
            // 
            // txtPath
            // 
            this.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(400, 32);
            // 
            // tsChoose
            // 
            this.tsChoose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsChoose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsChoose.ForeColor = System.Drawing.Color.Navy;
            this.tsChoose.Image = ((System.Drawing.Image)(resources.GetObject("tsChoose.Image")));
            this.tsChoose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsChoose.Name = "tsChoose";
            this.tsChoose.Size = new System.Drawing.Size(96, 29);
            this.tsChoose.Text = "... [ALT + C]";
            this.tsChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // tsWireshark
            // 
            this.tsWireshark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsWireshark.Enabled = false;
            this.tsWireshark.Image = global::Player.Properties.Resources.wireshark;
            this.tsWireshark.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsWireshark.Name = "tsWireshark";
            this.tsWireshark.Size = new System.Drawing.Size(173, 29);
            this.tsWireshark.Text = "Open With &Wireshark";
            this.tsWireshark.Click += new System.EventHandler(this.tsWireshark_Click);
            // 
            // tsFeedback
            // 
            this.tsFeedback.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsFeedback.Image = global::Player.Properties.Resources.mail;
            this.tsFeedback.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFeedback.Name = "tsFeedback";
            this.tsFeedback.Size = new System.Drawing.Size(96, 29);
            this.tsFeedback.Text = "Feedback";
            this.tsFeedback.Click += new System.EventHandler(this.tsFeedback_Click);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(114, 29);
            this.toolStripLabel3.Text = "© Inbar Rotem";
            // 
            // tsProg
            // 
            this.tsProg.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsProg.Name = "tsProg";
            this.tsProg.Size = new System.Drawing.Size(100, 29);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromFileToolStripMenuItem,
            this.fromClipboardToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::Player.Properties.Resources.add;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(122, 29);
            this.toolStripDropDownButton1.Text = "Load Packet";
            // 
            // fromFileToolStripMenuItem
            // 
            this.fromFileToolStripMenuItem.Image = global::Player.Properties.Resources.file;
            this.fromFileToolStripMenuItem.Name = "fromFileToolStripMenuItem";
            this.fromFileToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.fromFileToolStripMenuItem.Text = "From File";
            this.fromFileToolStripMenuItem.Click += new System.EventHandler(this.fromFileToolStripMenuItem_Click);
            // 
            // fromClipboardToolStripMenuItem
            // 
            this.fromClipboardToolStripMenuItem.Image = global::Player.Properties.Resources.clipboard;
            this.fromClipboardToolStripMenuItem.Name = "fromClipboardToolStripMenuItem";
            this.fromClipboardToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.fromClipboardToolStripMenuItem.Text = "From Clipboard";
            this.fromClipboardToolStripMenuItem.Click += new System.EventHandler(this.fromClipboardToolStripMenuItem_Click);
            // 
            // lnkLoad
            // 
            this.lnkLoad.IsLink = true;
            this.lnkLoad.Name = "lnkLoad";
            this.lnkLoad.Size = new System.Drawing.Size(16, 29);
            this.lnkLoad.Text = "?";
            this.lnkLoad.Click += new System.EventHandler(this.lnkLoad_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lstLog);
            this.groupBox3.Location = new System.Drawing.Point(755, 41);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(577, 359);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Log";
            // 
            // lstLog
            // 
            this.lstLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLog.FullRowSelect = true;
            this.lstLog.GridLines = true;
            this.lstLog.HideSelection = false;
            this.lstLog.Location = new System.Drawing.Point(3, 18);
            this.lstLog.Name = "lstLog";
            this.lstLog.ShowGroups = false;
            this.lstLog.Size = new System.Drawing.Size(571, 338);
            this.lstLog.TabIndex = 4;
            this.lstLog.UseCompatibleStateImageBehavior = false;
            this.lstLog.UseExplorerTheme = true;
            this.lstLog.View = System.Windows.Forms.View.Details;
            // 
            // chkSrcMac
            // 
            this.chkSrcMac.AutoSize = true;
            this.chkSrcMac.Location = new System.Drawing.Point(11, 8);
            this.chkSrcMac.Name = "chkSrcMac";
            this.chkSrcMac.Size = new System.Drawing.Size(81, 21);
            this.chkSrcMac.TabIndex = 15;
            this.chkSrcMac.Text = "Src Mac";
            this.chkSrcMac.UseVisualStyleBackColor = true;
            this.chkSrcMac.CheckedChanged += new System.EventHandler(this.chkSrcMac_CheckedChanged);
            // 
            // txtSrcMac
            // 
            this.txtSrcMac.Enabled = false;
            this.txtSrcMac.Location = new System.Drawing.Point(104, 8);
            this.txtSrcMac.Name = "txtSrcMac";
            this.txtSrcMac.Size = new System.Drawing.Size(148, 22);
            this.txtSrcMac.TabIndex = 16;
            // 
            // chkSrcInterfaceMac
            // 
            this.chkSrcInterfaceMac.AutoSize = true;
            this.chkSrcInterfaceMac.Enabled = false;
            this.chkSrcInterfaceMac.Location = new System.Drawing.Point(258, 8);
            this.chkSrcInterfaceMac.Name = "chkSrcInterfaceMac";
            this.chkSrcInterfaceMac.Size = new System.Drawing.Size(105, 21);
            this.chkSrcInterfaceMac.TabIndex = 17;
            this.chkSrcInterfaceMac.Text = "As Interface";
            this.chkSrcInterfaceMac.UseVisualStyleBackColor = true;
            this.chkSrcInterfaceMac.CheckedChanged += new System.EventHandler(this.chkInterfaceMac_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.chkSrcInterfaceMac);
            this.panel3.Controls.Add(this.txtSrcMac);
            this.panel3.Controls.Add(this.chkSrcMac);
            this.panel3.Location = new System.Drawing.Point(13, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(380, 40);
            this.panel3.TabIndex = 19;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.chkDstInterfaceMac);
            this.panel4.Controls.Add(this.txtDstMac);
            this.panel4.Controls.Add(this.chkDstMac);
            this.panel4.Location = new System.Drawing.Point(399, 25);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(380, 40);
            this.panel4.TabIndex = 20;
            // 
            // chkDstInterfaceMac
            // 
            this.chkDstInterfaceMac.AutoSize = true;
            this.chkDstInterfaceMac.Enabled = false;
            this.chkDstInterfaceMac.Location = new System.Drawing.Point(258, 8);
            this.chkDstInterfaceMac.Name = "chkDstInterfaceMac";
            this.chkDstInterfaceMac.Size = new System.Drawing.Size(105, 21);
            this.chkDstInterfaceMac.TabIndex = 17;
            this.chkDstInterfaceMac.Text = "As Interface";
            this.chkDstInterfaceMac.UseVisualStyleBackColor = true;
            this.chkDstInterfaceMac.CheckedChanged += new System.EventHandler(this.chkDstInterfaceMac_CheckedChanged);
            // 
            // txtDstMac
            // 
            this.txtDstMac.Enabled = false;
            this.txtDstMac.Location = new System.Drawing.Point(104, 8);
            this.txtDstMac.Name = "txtDstMac";
            this.txtDstMac.Size = new System.Drawing.Size(148, 22);
            this.txtDstMac.TabIndex = 16;
            // 
            // chkDstMac
            // 
            this.chkDstMac.AutoSize = true;
            this.chkDstMac.Location = new System.Drawing.Point(11, 8);
            this.chkDstMac.Name = "chkDstMac";
            this.chkDstMac.Size = new System.Drawing.Size(81, 21);
            this.chkDstMac.TabIndex = 15;
            this.chkDstMac.Text = "Dst Mac";
            this.chkDstMac.UseVisualStyleBackColor = true;
            this.chkDstMac.CheckedChanged += new System.EventHandler(this.chkDstMac_CheckedChanged);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.chkDstInterfaceIp);
            this.panel5.Controls.Add(this.txtDstIp);
            this.panel5.Controls.Add(this.chkDstIp);
            this.panel5.Location = new System.Drawing.Point(399, 71);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(380, 40);
            this.panel5.TabIndex = 22;
            // 
            // chkDstInterfaceIp
            // 
            this.chkDstInterfaceIp.AutoSize = true;
            this.chkDstInterfaceIp.Enabled = false;
            this.chkDstInterfaceIp.Location = new System.Drawing.Point(258, 8);
            this.chkDstInterfaceIp.Name = "chkDstInterfaceIp";
            this.chkDstInterfaceIp.Size = new System.Drawing.Size(105, 21);
            this.chkDstInterfaceIp.TabIndex = 17;
            this.chkDstInterfaceIp.Text = "As Interface";
            this.chkDstInterfaceIp.UseVisualStyleBackColor = true;
            this.chkDstInterfaceIp.CheckedChanged += new System.EventHandler(this.chkDstInterfaceIp_CheckedChanged);
            // 
            // txtDstIp
            // 
            this.txtDstIp.Enabled = false;
            this.txtDstIp.Location = new System.Drawing.Point(104, 8);
            this.txtDstIp.Name = "txtDstIp";
            this.txtDstIp.Size = new System.Drawing.Size(148, 22);
            this.txtDstIp.TabIndex = 16;
            // 
            // chkDstIp
            // 
            this.chkDstIp.AutoSize = true;
            this.chkDstIp.Location = new System.Drawing.Point(11, 8);
            this.chkDstIp.Name = "chkDstIp";
            this.chkDstIp.Size = new System.Drawing.Size(67, 21);
            this.chkDstIp.TabIndex = 15;
            this.chkDstIp.Text = "Dst IP";
            this.chkDstIp.UseVisualStyleBackColor = true;
            this.chkDstIp.CheckedChanged += new System.EventHandler(this.chkDstIp_CheckedChanged);
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.chkSrcInterfaceIp);
            this.panel6.Controls.Add(this.txtSrcIp);
            this.panel6.Controls.Add(this.chkSrcIp);
            this.panel6.Location = new System.Drawing.Point(13, 71);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(380, 40);
            this.panel6.TabIndex = 21;
            // 
            // chkSrcInterfaceIp
            // 
            this.chkSrcInterfaceIp.AutoSize = true;
            this.chkSrcInterfaceIp.Enabled = false;
            this.chkSrcInterfaceIp.Location = new System.Drawing.Point(258, 8);
            this.chkSrcInterfaceIp.Name = "chkSrcInterfaceIp";
            this.chkSrcInterfaceIp.Size = new System.Drawing.Size(105, 21);
            this.chkSrcInterfaceIp.TabIndex = 17;
            this.chkSrcInterfaceIp.Text = "As Interface";
            this.chkSrcInterfaceIp.UseVisualStyleBackColor = true;
            this.chkSrcInterfaceIp.CheckedChanged += new System.EventHandler(this.chkSrcInterfaceIp_CheckedChanged);
            // 
            // txtSrcIp
            // 
            this.txtSrcIp.Enabled = false;
            this.txtSrcIp.Location = new System.Drawing.Point(104, 8);
            this.txtSrcIp.Name = "txtSrcIp";
            this.txtSrcIp.Size = new System.Drawing.Size(148, 22);
            this.txtSrcIp.TabIndex = 16;
            // 
            // chkSrcIp
            // 
            this.chkSrcIp.AutoSize = true;
            this.chkSrcIp.Location = new System.Drawing.Point(11, 8);
            this.chkSrcIp.Name = "chkSrcIp";
            this.chkSrcIp.Size = new System.Drawing.Size(67, 21);
            this.chkSrcIp.TabIndex = 15;
            this.chkSrcIp.Text = "Src IP";
            this.chkSrcIp.UseVisualStyleBackColor = true;
            this.chkSrcIp.CheckedChanged += new System.EventHandler(this.chkSrcIp_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.lnkChangeFields);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panel6);
            this.groupBox1.Location = new System.Drawing.Point(9, 672);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(794, 124);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Change Fields";
            // 
            // lnkChangeFields
            // 
            this.lnkChangeFields.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkChangeFields.AutoSize = true;
            this.lnkChangeFields.Location = new System.Drawing.Point(116, 0);
            this.lnkChangeFields.Name = "lnkChangeFields";
            this.lnkChangeFields.Size = new System.Drawing.Size(16, 17);
            this.lnkChangeFields.TabIndex = 9;
            this.lnkChangeFields.TabStop = true;
            this.lnkChangeFields.Text = "?";
            this.lnkChangeFields.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkChangeFields_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Player.Properties.Resources.play;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(865, 684);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(151, 112);
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // PlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 808);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.grpPackets);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.Name = "PlayerForm";
            this.Text = "Player";
            this.Load += new System.EventHandler(this.PlayerForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PlayerForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.lstPackets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstDevices)).EndInit();
            this.grpPackets.ResumeLayout(false);
            this.grpPackets.PerformLayout();
            this.tsPackets.ResumeLayout(false);
            this.tsPackets.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstLog)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ObjectListView lstPackets;
        private ObjectListView lstDevices;
        private System.Windows.Forms.GroupBox grpPackets;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsRefresh;
        private System.Windows.Forms.ToolStripLabel tsNumInterfaces;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtPath;
        private System.Windows.Forms.ToolStripButton tsChoose;
        private System.Windows.Forms.ToolStripProgressBar tsProg;
        private System.Windows.Forms.ToolStripButton tsWireshark;
        private System.Windows.Forms.ToolStrip tsPackets;
        private System.Windows.Forms.ToolStripButton tsSendAll;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox tsBpf;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStripButton tsFilterGo;
        private System.Windows.Forms.ToolStripLabel tsNum;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox txtDelay;
        private System.Windows.Forms.CheckBox chkIpOption;
        private System.Windows.Forms.ToolStripLabel lnkDelay;
        private System.Windows.Forms.LinkLabel lnkIpOptions;
        private System.Windows.Forms.ToolStripLabel lnkSend;
        private System.Windows.Forms.ToolStripButton tsFeedback;
        private ObjectListView lstLog;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem fromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel lnkLoad;
        private System.Windows.Forms.CheckBox chkSrcMac;
        private System.Windows.Forms.TextBox txtSrcMac;
        private System.Windows.Forms.CheckBox chkSrcInterfaceMac;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox chkDstInterfaceMac;
        private System.Windows.Forms.TextBox txtDstMac;
        private System.Windows.Forms.CheckBox chkDstMac;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStripTextBox txtNumTimes;
        private System.Windows.Forms.ToolStripLabel lnkNumTimes;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox chkDstInterfaceIp;
        private System.Windows.Forms.TextBox txtDstIp;
        private System.Windows.Forms.CheckBox chkDstIp;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.CheckBox chkSrcInterfaceIp;
        private System.Windows.Forms.TextBox txtSrcIp;
        private System.Windows.Forms.CheckBox chkSrcIp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel lnkChangeFields;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox chkRandom;
    }
}

