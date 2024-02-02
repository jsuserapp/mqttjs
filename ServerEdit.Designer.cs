namespace MqttJs {
	partial class ServerEdit {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerEdit));
			btnOk = new Button();
			tbServerIp = new TextBox();
			tbServerPort = new TextBox();
			tbUsername = new TextBox();
			tbPassword = new TextBox();
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			btnCancel = new Button();
			label5 = new Label();
			tbServerName = new TextBox();
			labError = new Label();
			SuspendLayout();
			// 
			// btnOk
			// 
			btnOk.DialogResult = DialogResult.OK;
			btnOk.Location = new Point(219, 295);
			btnOk.Name = "btnOk";
			btnOk.Size = new Size(72, 34);
			btnOk.TabIndex = 6;
			btnOk.Text = "确定";
			btnOk.UseVisualStyleBackColor = true;
			btnOk.Click += BtnOk_Click;
			// 
			// tbServerIp
			// 
			tbServerIp.Location = new Point(122, 56);
			tbServerIp.Name = "tbServerIp";
			tbServerIp.Size = new Size(169, 23);
			tbServerIp.TabIndex = 1;
			// 
			// tbServerPort
			// 
			tbServerPort.Location = new Point(122, 96);
			tbServerPort.Name = "tbServerPort";
			tbServerPort.Size = new Size(169, 23);
			tbServerPort.TabIndex = 2;
			// 
			// tbUsername
			// 
			tbUsername.Location = new Point(122, 136);
			tbUsername.Name = "tbUsername";
			tbUsername.Size = new Size(169, 23);
			tbUsername.TabIndex = 3;
			// 
			// tbPassword
			// 
			tbPassword.Location = new Point(122, 176);
			tbPassword.Name = "tbPassword";
			tbPassword.Size = new Size(169, 23);
			tbPassword.TabIndex = 4;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(25, 60);
			label1.Name = "label1";
			label1.Size = new Size(55, 17);
			label1.TabIndex = 5;
			label1.Text = "服务器IP";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(12, 100);
			label2.Name = "label2";
			label2.Size = new Size(68, 17);
			label2.TabIndex = 6;
			label2.Text = "服务器端口";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(36, 140);
			label3.Name = "label3";
			label3.Size = new Size(44, 17);
			label3.TabIndex = 7;
			label3.Text = "用户名";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(48, 180);
			label4.Name = "label4";
			label4.Size = new Size(32, 17);
			label4.TabIndex = 8;
			label4.Text = "密码";
			// 
			// btnCancel
			// 
			btnCancel.DialogResult = DialogResult.Cancel;
			btnCancel.Location = new Point(25, 295);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(72, 34);
			btnCancel.TabIndex = 5;
			btnCancel.Text = "取消";
			btnCancel.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(13, 18);
			label5.Name = "label5";
			label5.Size = new Size(68, 17);
			label5.TabIndex = 11;
			label5.Text = "服务器命名";
			// 
			// tbServerName
			// 
			tbServerName.Location = new Point(122, 14);
			tbServerName.Name = "tbServerName";
			tbServerName.Size = new Size(169, 23);
			tbServerName.TabIndex = 0;
			// 
			// labError
			// 
			labError.AutoSize = true;
			labError.ForeColor = Color.FromArgb(192, 0, 0);
			labError.Location = new Point(32, 230);
			labError.Name = "labError";
			labError.Size = new Size(43, 17);
			labError.TabIndex = 12;
			labError.Text = "label6";
			// 
			// ServerEdit
			// 
			AcceptButton = btnOk;
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = btnCancel;
			ClientSize = new Size(311, 354);
			Controls.Add(labError);
			Controls.Add(label5);
			Controls.Add(tbServerName);
			Controls.Add(btnCancel);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(tbPassword);
			Controls.Add(tbUsername);
			Controls.Add(tbServerPort);
			Controls.Add(tbServerIp);
			Controls.Add(btnOk);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			Name = "ServerEdit";
			StartPosition = FormStartPosition.CenterParent;
			Text = "MQTT服务器";
			FormClosing += ServerEdit_FormClosing;
			Load += ServerEdit_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnOk;
		private TextBox tbServerIp;
		private TextBox tbServerPort;
		private TextBox tbUsername;
		private TextBox tbPassword;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Button btnCancel;
		private Label label5;
		private TextBox tbServerName;
		private Label labError;
	}
}