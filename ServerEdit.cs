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
	public partial class ServerEdit : Form {
		private bool _cancelClose = false;
		private MqttServer? Server;
		public ServerEdit() {
			InitializeComponent();
			if (Server == null) {
				Text = "添加 MQTT 服务器";
				Server = new MqttServer();
			} else {
				Text = "编辑 MQTT 服务器";
			}
		}

		private void BtnOk_Click(object sender, EventArgs e) {
			if (ValidInput()) {
				this.DialogResult = DialogResult.OK;
				if (Server != null){
					Server.Port = int.Parse(tbServerPort.Text);
					Server.Name = tbServerName.Text;
					Server.Ip = tbServerIp.Text;
					Server.Username = tbUsername.Text;
					Server.Password = tbPassword.Text;
				}
			} else {
				_cancelClose = true;
			}
		}
		private bool ValidInput() {
			if (tbServerName.Text.Length == 0) {
				SetError("请输入名称");
				tbServerName.Focus();
				return false;
			}
			if (tbServerIp.Text.Length == 0) {
				SetError("请输入 MQTT 服务器地址");
				tbServerIp.Focus();
				return false;
			}
			if (!int.TryParse(tbServerPort.Text, out int port) || port == 0) {
				SetError("请输入有效的端口号, 不能为 0");
				tbServerPort.Focus();
				return false;
			}
			return true;
		}
		private void SetError(string err) {
			labError.Text = err;
		}

		private void ServerEdit_Load(object sender, EventArgs e) {
			SetError("");
			if (Server != null) {
				tbServerName.Text = Server.Name;
				tbServerIp.Text = Server.Ip;
				if (Server.Port > 0) {
					tbServerPort.Text = Server.Port.ToString();
				}
				tbUsername.Text = Server.Username;
				tbPassword.Text = Server.Password;
			}
		}

		private void ServerEdit_FormClosing(object sender, FormClosingEventArgs e) {
			if(_cancelClose) {
				e.Cancel = true;
				_cancelClose = false;
			}
		}
		public static MqttServer? ShowEditServer(MqttServer server) {
			ServerEdit dlg = new() {
				Server = server
			};
			var rst = dlg.ShowDialog();
			if(rst == DialogResult.OK) {
				return dlg.Server;
			}
			return null;
		}
		public static MqttServer? ShowNewServer() {
			ServerEdit dlg = new();
			var rst = dlg.ShowDialog();
			if (rst == DialogResult.OK) {
				return dlg.Server;
			}
			return null;
		}
	}
}
