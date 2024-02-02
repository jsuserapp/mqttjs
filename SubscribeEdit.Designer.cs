namespace MqttJs {
	partial class SubscribeEdit {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubscribeEdit));
			btnOk = new Button();
			label1 = new Label();
			btnCancel = new Button();
			label5 = new Label();
			tbTopic = new TextBox();
			labError = new Label();
			label2 = new Label();
			tbName = new TextBox();
			qosBtn2 = new RadioButton();
			qosBtn1 = new RadioButton();
			qosBtn0 = new RadioButton();
			cbDisabled = new CheckBox();
			label3 = new Label();
			labColor = new Label();
			colorDlg = new ColorDialog();
			SuspendLayout();
			// 
			// btnOk
			// 
			btnOk.DialogResult = DialogResult.OK;
			btnOk.Location = new Point(227, 240);
			btnOk.Name = "btnOk";
			btnOk.Size = new Size(72, 34);
			btnOk.TabIndex = 7;
			btnOk.Text = "确定";
			btnOk.UseVisualStyleBackColor = true;
			btnOk.Click += BtnOk_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(44, 116);
			label1.Name = "label1";
			label1.Size = new Size(33, 17);
			label1.TabIndex = 5;
			label1.Text = "QoS";
			// 
			// btnCancel
			// 
			btnCancel.DialogResult = DialogResult.Cancel;
			btnCancel.Location = new Point(33, 240);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(72, 34);
			btnCancel.TabIndex = 6;
			btnCancel.Text = "取消";
			btnCancel.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(21, 70);
			label5.Name = "label5";
			label5.Size = new Size(56, 17);
			label5.TabIndex = 11;
			label5.Text = "订阅主题";
			// 
			// tbTopic
			// 
			tbTopic.Location = new Point(130, 66);
			tbTopic.Name = "tbTopic";
			tbTopic.Size = new Size(169, 23);
			tbTopic.TabIndex = 1;
			// 
			// labError
			// 
			labError.AutoSize = true;
			labError.ForeColor = Color.FromArgb(192, 0, 0);
			labError.Location = new Point(44, 202);
			labError.Name = "labError";
			labError.Size = new Size(43, 17);
			labError.TabIndex = 12;
			labError.Text = "label6";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(45, 28);
			label2.Name = "label2";
			label2.Size = new Size(32, 17);
			label2.TabIndex = 14;
			label2.Text = "名称";
			// 
			// tbName
			// 
			tbName.Location = new Point(130, 25);
			tbName.Name = "tbName";
			tbName.Size = new Size(169, 23);
			tbName.TabIndex = 0;
			// 
			// qosBtn2
			// 
			qosBtn2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			qosBtn2.AutoSize = true;
			qosBtn2.Location = new Point(266, 112);
			qosBtn2.Name = "qosBtn2";
			qosBtn2.Size = new Size(33, 21);
			qosBtn2.TabIndex = 4;
			qosBtn2.Text = "2";
			qosBtn2.UseVisualStyleBackColor = true;
			// 
			// qosBtn1
			// 
			qosBtn1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			qosBtn1.AutoSize = true;
			qosBtn1.Location = new Point(197, 112);
			qosBtn1.Name = "qosBtn1";
			qosBtn1.Size = new Size(33, 21);
			qosBtn1.TabIndex = 3;
			qosBtn1.Text = "1";
			qosBtn1.UseVisualStyleBackColor = true;
			// 
			// qosBtn0
			// 
			qosBtn0.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			qosBtn0.AutoSize = true;
			qosBtn0.Checked = true;
			qosBtn0.Location = new Point(130, 112);
			qosBtn0.Name = "qosBtn0";
			qosBtn0.Size = new Size(33, 21);
			qosBtn0.TabIndex = 2;
			qosBtn0.TabStop = true;
			qosBtn0.Text = "0";
			qosBtn0.UseVisualStyleBackColor = true;
			// 
			// cbDisabled
			// 
			cbDisabled.AutoSize = true;
			cbDisabled.Location = new Point(248, 154);
			cbDisabled.Name = "cbDisabled";
			cbDisabled.Size = new Size(51, 21);
			cbDisabled.TabIndex = 5;
			cbDisabled.Text = "禁用";
			cbDisabled.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(45, 158);
			label3.Name = "label3";
			label3.Size = new Size(32, 17);
			label3.TabIndex = 15;
			label3.Text = "颜色";
			// 
			// labColor
			// 
			labColor.Location = new Point(130, 156);
			labColor.Name = "labColor";
			labColor.Size = new Size(23, 23);
			labColor.TabIndex = 16;
			labColor.Click += LabColor_Click;
			// 
			// SubscribeEdit
			// 
			AcceptButton = btnOk;
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = btnCancel;
			ClientSize = new Size(311, 292);
			Controls.Add(labColor);
			Controls.Add(label3);
			Controls.Add(cbDisabled);
			Controls.Add(qosBtn2);
			Controls.Add(qosBtn1);
			Controls.Add(qosBtn0);
			Controls.Add(label2);
			Controls.Add(tbName);
			Controls.Add(labError);
			Controls.Add(label5);
			Controls.Add(tbTopic);
			Controls.Add(btnCancel);
			Controls.Add(label1);
			Controls.Add(btnOk);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			Name = "SubscribeEdit";
			StartPosition = FormStartPosition.CenterParent;
			Text = "订阅";
			FormClosing += ServerEdit_FormClosing;
			Load += SubscribeEdit_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnOk;
		private Label label1;
		private Button btnCancel;
		private Label label5;
		private TextBox tbTopic;
		private Label labError;
		private Label label2;
		private TextBox tbName;
		private RadioButton qosBtn2;
		private RadioButton qosBtn1;
		private RadioButton qosBtn0;
		private CheckBox cbDisabled;
		private Label label3;
		private Label labColor;
		private ColorDialog colorDlg;
	}
}