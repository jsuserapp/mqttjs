namespace MqttJs {
	partial class FormMain {
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			MsgBox = new RichTextBox();
			BtnAddServer = new Button();
			groupServer = new GroupBox();
			ServerList = new MyTreeView();
			treeImages = new ImageList(components);
			groupMessage = new GroupBox();
			btnConn = new Button();
			labServer = new Label();
			checkPersident = new CheckBox();
			qosBtn2 = new RadioButton();
			qosBtn1 = new RadioButton();
			qosBtn = new RadioButton();
			BtnClearMessage = new Button();
			BtnSend = new Button();
			BtnClearSend = new Button();
			splitMessage = new SplitContainer();
			sendBox = new RichTextBox();
			toolTip = new ToolTip(components);
			mqttServerMenu = new ContextMenuStrip(components);
			toolStripMenuItem1 = new ToolStripMenuItem();
			toolStripSeparator1 = new ToolStripSeparator();
			编辑ToolStripMenuItem = new ToolStripMenuItem();
			删除ToolStripMenuItem = new ToolStripMenuItem();
			toolStripMenuItem4 = new ToolStripSeparator();
			连接断开ToolStripMenuItem = new ToolStripMenuItem();
			subscribeMenu = new ContextMenuStrip(components);
			toolStripMenuItem2 = new ToolStripMenuItem();
			编辑订阅ToolStripMenuItem = new ToolStripMenuItem();
			删除订阅ToolStripMenuItem = new ToolStripMenuItem();
			toolStripMenuItem3 = new ToolStripSeparator();
			启用禁用ToolStripMenuItem = new ToolStripMenuItem();
			groupServer.SuspendLayout();
			groupMessage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitMessage).BeginInit();
			splitMessage.Panel1.SuspendLayout();
			splitMessage.Panel2.SuspendLayout();
			splitMessage.SuspendLayout();
			mqttServerMenu.SuspendLayout();
			subscribeMenu.SuspendLayout();
			SuspendLayout();
			// 
			// MsgBox
			// 
			MsgBox.BackColor = Color.White;
			MsgBox.BorderStyle = BorderStyle.FixedSingle;
			MsgBox.Dock = DockStyle.Fill;
			MsgBox.Location = new Point(0, 0);
			MsgBox.Name = "MsgBox";
			MsgBox.ReadOnly = true;
			MsgBox.Size = new Size(672, 274);
			MsgBox.TabIndex = 0;
			MsgBox.Text = "";
			// 
			// BtnAddServer
			// 
			BtnAddServer.ImageAlign = ContentAlignment.MiddleLeft;
			BtnAddServer.ImageIndex = 0;
			BtnAddServer.Location = new Point(6, 35);
			BtnAddServer.Name = "BtnAddServer";
			BtnAddServer.Size = new Size(56, 34);
			BtnAddServer.TabIndex = 2;
			BtnAddServer.Text = "添加";
			toolTip.SetToolTip(BtnAddServer, "添加新的 MQTT 服务器");
			BtnAddServer.UseVisualStyleBackColor = true;
			BtnAddServer.Click += BtnAddServer_Click;
			// 
			// groupServer
			// 
			groupServer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			groupServer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			groupServer.Controls.Add(ServerList);
			groupServer.Controls.Add(BtnAddServer);
			groupServer.Location = new Point(12, 12);
			groupServer.Name = "groupServer";
			groupServer.Size = new Size(310, 712);
			groupServer.TabIndex = 5;
			groupServer.TabStop = false;
			groupServer.Text = "MQTT 服务器";
			// 
			// ServerList
			// 
			ServerList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			ServerList.Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 134);
			ServerList.ImageIndex = 0;
			ServerList.ImageList = treeImages;
			ServerList.Location = new Point(6, 90);
			ServerList.Name = "ServerList";
			ServerList.SelectedImageIndex = 0;
			ServerList.Size = new Size(298, 607);
			ServerList.TabIndex = 5;
			ServerList.AfterSelect += ServerList_AfterSelect;
			ServerList.NodeMouseDoubleClick += ServerList_NodeMouseDoubleClick;
			// 
			// treeImages
			// 
			treeImages.ColorDepth = ColorDepth.Depth32Bit;
			treeImages.ImageStream = (ImageListStreamer)resources.GetObject("treeImages.ImageStream");
			treeImages.TransparentColor = Color.Transparent;
			treeImages.Images.SetKeyName(0, "disconnected-24.png");
			treeImages.Images.SetKeyName(1, "connected-24.png");
			treeImages.Images.SetKeyName(2, "subscribe-disable.png");
			treeImages.Images.SetKeyName(3, "subscribe-16.png");
			// 
			// groupMessage
			// 
			groupMessage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			groupMessage.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			groupMessage.Controls.Add(btnConn);
			groupMessage.Controls.Add(labServer);
			groupMessage.Controls.Add(checkPersident);
			groupMessage.Controls.Add(qosBtn2);
			groupMessage.Controls.Add(qosBtn1);
			groupMessage.Controls.Add(qosBtn);
			groupMessage.Controls.Add(BtnClearMessage);
			groupMessage.Controls.Add(BtnSend);
			groupMessage.Controls.Add(BtnClearSend);
			groupMessage.Controls.Add(splitMessage);
			groupMessage.Location = new Point(328, 12);
			groupMessage.Name = "groupMessage";
			groupMessage.Size = new Size(684, 712);
			groupMessage.TabIndex = 6;
			groupMessage.TabStop = false;
			groupMessage.Text = "消息";
			// 
			// btnConn
			// 
			btnConn.Enabled = false;
			btnConn.Location = new Point(6, 41);
			btnConn.Name = "btnConn";
			btnConn.Size = new Size(47, 28);
			btnConn.TabIndex = 15;
			btnConn.Text = "连接";
			btnConn.UseVisualStyleBackColor = true;
			btnConn.Click += BtnConn_Click;
			// 
			// labServer
			// 
			labServer.AutoSize = true;
			labServer.Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 134);
			labServer.Location = new Point(59, 39);
			labServer.Name = "labServer";
			labServer.Size = new Size(0, 30);
			labServer.TabIndex = 14;
			// 
			// checkPersident
			// 
			checkPersident.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			checkPersident.AutoSize = true;
			checkPersident.Location = new Point(448, 671);
			checkPersident.Name = "checkPersident";
			checkPersident.Size = new Size(51, 21);
			checkPersident.TabIndex = 11;
			checkPersident.Text = "保留";
			toolTip.SetToolTip(checkPersident, "消息被保留，订阅时间晚于消息发送时间的订阅者仍然可以收到消息");
			checkPersident.UseVisualStyleBackColor = true;
			checkPersident.CheckedChanged += CheckPersident_CheckedChanged;
			// 
			// qosBtn2
			// 
			qosBtn2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			qosBtn2.AutoSize = true;
			qosBtn2.Location = new Point(345, 670);
			qosBtn2.Name = "qosBtn2";
			qosBtn2.Size = new Size(74, 21);
			qosBtn2.TabIndex = 10;
			qosBtn2.Text = "Qos = 2";
			qosBtn2.UseVisualStyleBackColor = true;
			qosBtn2.CheckedChanged += QosBtn_CheckedChanged;
			// 
			// qosBtn1
			// 
			qosBtn1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			qosBtn1.AutoSize = true;
			qosBtn1.Location = new Point(265, 670);
			qosBtn1.Name = "qosBtn1";
			qosBtn1.Size = new Size(74, 21);
			qosBtn1.TabIndex = 9;
			qosBtn1.Text = "Qos = 1";
			qosBtn1.UseVisualStyleBackColor = true;
			qosBtn1.CheckedChanged += QosBtn_CheckedChanged;
			// 
			// qosBtn
			// 
			qosBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			qosBtn.AutoSize = true;
			qosBtn.Checked = true;
			qosBtn.Location = new Point(185, 670);
			qosBtn.Name = "qosBtn";
			qosBtn.Size = new Size(74, 21);
			qosBtn.TabIndex = 8;
			qosBtn.TabStop = true;
			qosBtn.Text = "Qos = 0";
			qosBtn.UseVisualStyleBackColor = true;
			qosBtn.CheckedChanged += QosBtn_CheckedChanged;
			// 
			// BtnClearMessage
			// 
			BtnClearMessage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			BtnClearMessage.ImageAlign = ContentAlignment.MiddleLeft;
			BtnClearMessage.ImageKey = "delete.png";
			BtnClearMessage.Location = new Point(621, 35);
			BtnClearMessage.Name = "BtnClearMessage";
			BtnClearMessage.Size = new Size(56, 34);
			BtnClearMessage.TabIndex = 7;
			BtnClearMessage.Text = "清空";
			toolTip.SetToolTip(BtnClearMessage, "清空消息");
			BtnClearMessage.UseVisualStyleBackColor = true;
			BtnClearMessage.Click += BtnClearMessage_Click;
			// 
			// BtnSend
			// 
			BtnSend.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BtnSend.ImageAlign = ContentAlignment.MiddleLeft;
			BtnSend.ImageKey = "delete.png";
			BtnSend.Location = new Point(621, 663);
			BtnSend.Name = "BtnSend";
			BtnSend.Size = new Size(56, 34);
			BtnSend.TabIndex = 6;
			BtnSend.Text = "发送";
			toolTip.SetToolTip(BtnSend, "发送消息");
			BtnSend.UseVisualStyleBackColor = true;
			// 
			// BtnClearSend
			// 
			BtnClearSend.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BtnClearSend.ImageAlign = ContentAlignment.MiddleLeft;
			BtnClearSend.ImageIndex = 0;
			BtnClearSend.Location = new Point(99, 663);
			BtnClearSend.Name = "BtnClearSend";
			BtnClearSend.Size = new Size(56, 34);
			BtnClearSend.TabIndex = 5;
			BtnClearSend.Text = "清空";
			toolTip.SetToolTip(BtnClearSend, "清空输入");
			BtnClearSend.UseVisualStyleBackColor = true;
			BtnClearSend.Click += BtnClearSend_Click;
			// 
			// splitMessage
			// 
			splitMessage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			splitMessage.Cursor = Cursors.SizeNS;
			splitMessage.FixedPanel = FixedPanel.Panel2;
			splitMessage.Location = new Point(6, 90);
			splitMessage.Name = "splitMessage";
			splitMessage.Orientation = Orientation.Horizontal;
			// 
			// splitMessage.Panel1
			// 
			splitMessage.Panel1.Controls.Add(MsgBox);
			// 
			// splitMessage.Panel2
			// 
			splitMessage.Panel2.Controls.Add(sendBox);
			splitMessage.Size = new Size(672, 567);
			splitMessage.SplitterDistance = 274;
			splitMessage.SplitterWidth = 8;
			splitMessage.TabIndex = 1;
			// 
			// sendBox
			// 
			sendBox.Dock = DockStyle.Fill;
			sendBox.Location = new Point(0, 0);
			sendBox.Name = "sendBox";
			sendBox.Size = new Size(672, 285);
			sendBox.TabIndex = 0;
			sendBox.Text = "";
			// 
			// mqttServerMenu
			// 
			mqttServerMenu.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripSeparator1, 编辑ToolStripMenuItem, 删除ToolStripMenuItem, toolStripMenuItem4, 连接断开ToolStripMenuItem });
			mqttServerMenu.Name = "mqttServerMenu";
			mqttServerMenu.Size = new Size(130, 104);
			// 
			// toolStripMenuItem1
			// 
			toolStripMenuItem1.Image = Properties.Resources.add_16;
			toolStripMenuItem1.Name = "toolStripMenuItem1";
			toolStripMenuItem1.Size = new Size(129, 22);
			toolStripMenuItem1.Text = "添加订阅";
			toolStripMenuItem1.Click += MenuItemAddSubscribe_Click;
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new Size(126, 6);
			// 
			// 编辑ToolStripMenuItem
			// 
			编辑ToolStripMenuItem.Image = Properties.Resources.edit_16;
			编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
			编辑ToolStripMenuItem.Size = new Size(129, 22);
			编辑ToolStripMenuItem.Text = "编辑";
			编辑ToolStripMenuItem.Click += MenuItemEditServer_Click;
			// 
			// 删除ToolStripMenuItem
			// 
			删除ToolStripMenuItem.Image = Properties.Resources.delete_16;
			删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
			删除ToolStripMenuItem.Size = new Size(129, 22);
			删除ToolStripMenuItem.Text = "删除";
			删除ToolStripMenuItem.Click += MenuItemDeleteServer_Click;
			// 
			// toolStripMenuItem4
			// 
			toolStripMenuItem4.Name = "toolStripMenuItem4";
			toolStripMenuItem4.Size = new Size(126, 6);
			// 
			// 连接断开ToolStripMenuItem
			// 
			连接断开ToolStripMenuItem.Name = "连接断开ToolStripMenuItem";
			连接断开ToolStripMenuItem.Size = new Size(129, 22);
			连接断开ToolStripMenuItem.Text = "连接/断开";
			连接断开ToolStripMenuItem.Click += MenuItemServerControl;
			// 
			// subscribeMenu
			// 
			subscribeMenu.Items.AddRange(new ToolStripItem[] { toolStripMenuItem2, 编辑订阅ToolStripMenuItem, 删除订阅ToolStripMenuItem, toolStripMenuItem3, 启用禁用ToolStripMenuItem });
			subscribeMenu.Name = "subscribeMenu";
			subscribeMenu.Size = new Size(130, 98);
			// 
			// toolStripMenuItem2
			// 
			toolStripMenuItem2.Image = Properties.Resources.add_16;
			toolStripMenuItem2.Name = "toolStripMenuItem2";
			toolStripMenuItem2.Size = new Size(129, 22);
			toolStripMenuItem2.Text = "添加订阅";
			toolStripMenuItem2.Click += MenuItemAddSubscribe_Click;
			// 
			// 编辑订阅ToolStripMenuItem
			// 
			编辑订阅ToolStripMenuItem.Image = Properties.Resources.edit_16;
			编辑订阅ToolStripMenuItem.Name = "编辑订阅ToolStripMenuItem";
			编辑订阅ToolStripMenuItem.Size = new Size(129, 22);
			编辑订阅ToolStripMenuItem.Text = "编辑订阅";
			编辑订阅ToolStripMenuItem.Click += MenuItemEditSubscribe_Click;
			// 
			// 删除订阅ToolStripMenuItem
			// 
			删除订阅ToolStripMenuItem.Image = Properties.Resources.delete_16;
			删除订阅ToolStripMenuItem.Name = "删除订阅ToolStripMenuItem";
			删除订阅ToolStripMenuItem.Size = new Size(129, 22);
			删除订阅ToolStripMenuItem.Text = "删除订阅";
			删除订阅ToolStripMenuItem.Click += MenuItemDeleteSubscribe_Click;
			// 
			// toolStripMenuItem3
			// 
			toolStripMenuItem3.Name = "toolStripMenuItem3";
			toolStripMenuItem3.Size = new Size(126, 6);
			// 
			// 启用禁用ToolStripMenuItem
			// 
			启用禁用ToolStripMenuItem.Name = "启用禁用ToolStripMenuItem";
			启用禁用ToolStripMenuItem.Size = new Size(129, 22);
			启用禁用ToolStripMenuItem.Text = "启用/禁用";
			启用禁用ToolStripMenuItem.Click += MenuItemSubscribeEnable;
			// 
			// FormMain
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1024, 736);
			Controls.Add(groupMessage);
			Controls.Add(groupServer);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(2);
			Name = "FormMain";
			Text = "Mqtt Js 1.0";
			FormClosing += FormMain_FormClosing;
			Load += FormMain_Load;
			groupServer.ResumeLayout(false);
			groupMessage.ResumeLayout(false);
			groupMessage.PerformLayout();
			splitMessage.Panel1.ResumeLayout(false);
			splitMessage.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitMessage).EndInit();
			splitMessage.ResumeLayout(false);
			mqttServerMenu.ResumeLayout(false);
			subscribeMenu.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private RichTextBox MsgBox;
		private Button BtnAddServer;
		private GroupBox groupServer;
		private GroupBox groupMessage;
		private SplitContainer splitMessage;
		private RichTextBox sendBox;
		private Button BtnClearMessage;
		private Button BtnSend;
		private Button BtnClearSend;
		private RadioButton qosBtn;
		private ToolTip toolTip;
		private RadioButton qosBtn2;
		private RadioButton qosBtn1;
		private CheckBox checkPersident;
		private MyTreeView ServerList;
		private ContextMenuStrip mqttServerMenu;
		private ToolStripMenuItem 编辑ToolStripMenuItem;
		private ToolStripMenuItem 删除ToolStripMenuItem;
		private ContextMenuStrip subscribeMenu;
		private ToolStripMenuItem toolStripMenuItem1;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripMenuItem 编辑订阅ToolStripMenuItem;
		private ToolStripMenuItem 删除订阅ToolStripMenuItem;
		private ToolStripMenuItem toolStripMenuItem2;
		private ImageList treeImages;
		private Label labServer;
		private Button btnConn;
		private ToolStripSeparator toolStripMenuItem4;
		private ToolStripMenuItem 连接断开ToolStripMenuItem;
		private ToolStripSeparator toolStripMenuItem3;
		private ToolStripMenuItem 启用禁用ToolStripMenuItem;
	}
}
