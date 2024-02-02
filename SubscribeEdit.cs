using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MqttJs {
	public partial class SubscribeEdit : Form {
		private bool _cancelClose = false;
		private MqttSubscribe Subscribe;
		public SubscribeEdit() {
			InitializeComponent();
			if (Subscribe == null) {
				Text = "添加订阅";
				Subscribe = new MqttSubscribe();
			} else {
				Text = "编辑订阅";
			}
		}

		private void BtnOk_Click(object sender, EventArgs e) {
			if (ValidInput()) {
				this.DialogResult = DialogResult.OK;
				if (Subscribe != null) {
					if (qosBtn0.Checked) {
						Subscribe.Qos = 0;
					} else if (qosBtn1.Checked) {
						Subscribe.Qos = 1;
					} else if (qosBtn2.Checked) {
						Subscribe.Qos = 2;
					}
					Subscribe.Name = tbName.Text;
					Subscribe.Topic = tbTopic.Text;
					Subscribe.Enabled = !cbDisabled.Checked;
				}
			} else {
				_cancelClose = true;
			}
		}
		private bool ValidInput() {
			if (tbTopic.Text.Length == 0) {
				SetError("请输入要订阅的主题");
				tbTopic.Focus();
				return false;
			}
			return true;
		}
		private void SetError(string err) {
			labError.Text = err;
		}

		private void SubscribeEdit_Load(object sender, EventArgs e) {
			SetError("");
			if (Subscribe != null) {
				tbName.Text = Subscribe.Name;
				tbTopic.Text = Subscribe.Topic;
				if (Subscribe.Qos == 0) {
					qosBtn0.Checked = true;
				} else if (Subscribe.Qos == 1) {
					qosBtn1.Checked = true;
				} else if (Subscribe.Qos == 2) {
					qosBtn2.Checked = true;
				}
				cbDisabled.Checked = !Subscribe.Enabled;
				if (Subscribe.Color == 0) {
					Subscribe.Color = Lib.StringToDarkColor(Subscribe.Topic);
				}
				labColor.BackColor = Color.FromArgb(Subscribe.Color);
			}
		}

		private void ServerEdit_FormClosing(object sender, FormClosingEventArgs e) {
			if (_cancelClose) {
				e.Cancel = true;
				_cancelClose = false;
			}
		}
		public static MqttSubscribe? ShowEditSubscribe(MqttSubscribe sub) {
			SubscribeEdit dlg = new() {
				Subscribe = sub
			};
			var rst = dlg.ShowDialog();
			if (rst == DialogResult.OK) {
				return dlg.Subscribe;
			}
			return null;
		}
		public static MqttSubscribe? ShowNewSubscribe() {
			SubscribeEdit dlg = new();
			var rst = dlg.ShowDialog();
			if (rst == DialogResult.OK) {
				return dlg.Subscribe;
			}
			return null;
		}

		private void SelectColor() {
			colorDlg.Color = labColor.BackColor;

			if (colorDlg.ShowDialog() == DialogResult.OK) {
				Subscribe.Color = colorDlg.Color.ToArgb();
				labColor.BackColor = colorDlg.Color;
			}
		}

		private void LabColor_Click(object sender, EventArgs e) {
			SelectColor();
		}
	}
}
