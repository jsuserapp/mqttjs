
using MQTTnet.Client;
using MQTTnet;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using System.Text.RegularExpressions;
using System.Text.Json;
using MQTTnet.Server;
using System.ComponentModel;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MqttJs {
	public partial class FormMain : Form {
		private readonly SynchronizationContext? uiTask;
		private readonly MqttFactory factory = new();
		public FormMain() {
			InitializeComponent();
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			uiTask = SynchronizationContext.Current;
		}

		private async void FormMain_FormClosing(object sender, FormClosingEventArgs e) {
			var conf = ConfigYaml.GetInstance();
			conf.UIState.FormRect.SetValue(Location, Size);
			conf.UIState.AutoJson = cbAutoJson.Checked;
			ConfigYaml.Save();
			foreach (MqttServer server in conf.ServerList) {
				await DisconnectMqttAsync(server);
			}
		}

		private void FormMain_Load(object sender, EventArgs e) {
			var conf = ConfigYaml.GetInstance();

			var rect  = conf.UIState.FormRect;
			Size = rect.Size();
			Location = rect.Location();
			cbAutoJson.Checked = conf.UIState.AutoJson;

			ServerList.LoadNodes(mqttServerMenu, subscribeMenu);
			ServerList.SetNodeState();
		}
		private void QosBtn_CheckedChanged(object sender, EventArgs e) {
			if (sender is RadioButton radioButton) {
				if (radioButton.Checked) {
					if (radioButton == qosBtn) {
					} else if (radioButton == qosBtn1) {
					} else if (radioButton == qosBtn2) {
					}
				}
			}
		}
		private void CheckPersident_CheckedChanged(object sender, EventArgs e) {

		}
		private void BtnClearMessage_Click(object sender, EventArgs e) {
			MsgBox.Text = string.Empty;
		}
		private void BtnClearSend_Click(object sender, EventArgs e) {
			sendBox.Text = string.Empty;
		}
		private void BtnAddServer_Click(object sender, EventArgs e) {
			var server = ServerEdit.ShowNewServer();
			if (server != null) {
				ServerList.AddServer(server);
				ConfigYaml.Save();
			}
		}
		private void BtnConn_Click(object sender, EventArgs e) {
			ServerControl();
		}

		private void MenuItemEditServer_Click(object sender, EventArgs e) {
			var server = ServerList.GetSelectedServer();
			if (server == null) {
				return;
			}
			server = ServerEdit.ShowEditServer(server);
			if (server != null) {
				ServerList.RefreshServerNode();
				ConfigYaml.Save();
			}
		}
		private void MenuItemDeleteServer_Click(object sender, EventArgs e) {
			ServerList.DeleteServer();
		}
		private void MenuItemAddSubscribe_Click(object sender, EventArgs e) {
			var sub = SubscribeEdit.ShowNewSubscribe();
			if (sub != null) {
				ServerList.AddSubscribe(sub);
				ConfigYaml.Save();
			}
		}
		private void MenuItemDeleteSubscribe_Click(object sender, EventArgs e) {
			ServerList.DeleteSubscribe();
		}
		private void MenuItemEditSubscribe_Click(object sender, EventArgs e) {
			var sub = ServerList.GetSelectedSubscribe();
			if (sub == null) {
				return;
			}
			sub = SubscribeEdit.ShowEditSubscribe(sub);
			if (sub != null) {
				ServerList.RefreshSubscribeNode();
				ConfigYaml.Save();
			}
		}
		private void MenuItemServerControl(object sender, EventArgs e) {
			ServerControl();
		}
		private void MenuItemSubscribeEnable(object sender, EventArgs e) {
			SubscribeEnable();
		}

		private void ServerControl() {
			var server = ServerList.GetSelectedServer();
			if (server != null) {
				if (server.Mqtt.Client != null) {
					server.Mqtt.State = ServerState.正在断开;
					_ = DisconnectMqttAsync(server);
				} else {
					server.Mqtt.State = ServerState.正在连接;
					_ = ConnectMqttAsync(server);
				}
				SetServerState(server, false);
			}
		}
		private void SubscribeEnable() {
			var server = ServerList.GetSelectedServer();
			var sub = ServerList.GetSelectedSubscribe();
			if (sub != null && server != null) {
				sub.Enabled = !sub.Enabled;
				ServerList.RefreshSubscribeNode();
				if (server.Mqtt.Client != null) {
					if (sub.Enabled) {
						SubscribeTopic(server.Mqtt.Client, sub.Topic, sub.Qos);
					} else {
						UnscribeTopic(server.Mqtt.Client, sub.Topic);
					}
				}
			}
		}
		private void ServerList_AfterSelect(object sender, TreeViewEventArgs e) {
			var server = ServerList.GetSelectedServer();
			SetServerState(server, false);
		}
		private void SetServerState(MqttServer? server, bool refreshTree) {
			if (refreshTree) {
				ServerList.SetNodeState();
			}
			var curServ = ServerList.GetSelectedServer();
			if (server == null || curServ != server) {
				//如果server不是当前的，忽略
				return;
			}
			var state = server.Mqtt.State;
			if (state == ServerState.已断开) {
				labServer.ForeColor = Color.Red;
				btnConn.Enabled = true;
				btnConn.Text = "连接";
			} else if (state == ServerState.已连接) {
				labServer.ForeColor = Color.Green;
				btnConn.Enabled = true;
				btnConn.Text = "断开";
			} else if (state == ServerState.正在连接) {
				labServer.ForeColor = Color.Orange;
				btnConn.Enabled = false;
				btnConn.Text = "断开";
			} else if (state == ServerState.正在断开) {
				labServer.ForeColor = Color.Orange;
				btnConn.Enabled = false;
				btnConn.Text = "连接";
			}
			labServer.Text = $"{server.Name} {server.Ip}:{server.Port}({state})";
		}
		private static readonly JsonSerializerOptions jsonOption = new() {
			WriteIndented = true,
			Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
		};
		public async Task<bool> ConnectMqttAsync(MqttServer? server) {
			if (server == null) {
				return false;
			}
			var mqttClient = factory.CreateMqttClient();
			var optionsBuilder = new MqttClientOptionsBuilder()
				.WithTcpServer(server.Ip, server.Port);
			if (!string.IsNullOrEmpty(server.Username)) {
				optionsBuilder = optionsBuilder.WithCredentials(server.Username, server.Password);
			}
			var options = optionsBuilder.Build();
			try {
				await mqttClient.ConnectAsync(options);
				server.Mqtt.State = ServerState.已连接;
				server.Mqtt.Client = mqttClient;
				mqttClient.ApplicationMessageReceivedAsync += e => {
					OnMqttMessage(server, e.ApplicationMessage.Topic, Lib.SegmentToArray(e.ApplicationMessage.PayloadSegment));
					return Task.CompletedTask;
				};
				uiTask?.Post(_ => {
					SetServerState(server, true);
				}, null);
				foreach (MqttSubscribe sub in server.SubscribeList) {
					if (!sub.Enabled) {
						continue;
					}
					await mqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic(sub.Topic)
						.WithQualityOfServiceLevel((MQTTnet.Protocol.MqttQualityOfServiceLevel)sub.Qos)
						.Build());
				}
				return true;
			} catch (Exception e) {
				server.Mqtt.State = ServerState.已断开;
				uiTask?.Post(_ => {
					SetServerState(server, true);
				}, null);
				Debug.WriteLine(e.ToString());
				return false;
			}
		}
		private void OnMqttMessage(MqttServer server, string topic, byte[] data) {
			var str = "";
			var code = "";
			if (Lib.IsGB2312(data)) {
				Encoding gb2312 = Encoding.GetEncoding("gb2312");
				str = gb2312.GetString(data);
				code = "gb2312";
			} else if (Lib.IsUTF8Bytes(data)) {
				str = System.Text.Encoding.UTF8.GetString(data);
				code = "utf8";
			} else {
				str = BitConverter.ToString(data).Replace("-", "");
				code = "hex";
			}
			var sub = server.FindSubscribe(topic);
			if (sub == null) {
				return;
			}
			Color textColor = Color.Black;
			if (sub.Color != 0) {
				textColor = Color.FromArgb(sub.Color);
			} else {
				textColor = Color.FromArgb(Lib.StringToDarkColor(sub.Topic));
			}
			DateTime now = DateTime.Now;
			string date = now.ToString("yyyy-MM-dd HH:mm:ss.fff");
			string txt = "";
			if (cbAutoJson.Checked) {
				try {
					txt = JsonSerializer.Serialize(JsonSerializer.Deserialize<JsonElement>(str), jsonOption) + "\r\n";
					code += " | json";
				}catch(Exception) {
					txt = str + "\r\n";
				}
			} else {
				txt = str + "\r\n";
			}
			string title = $"[{date} | {sub.Topic} | {code}]";
			uiTask?.Post(_ => {
				AppendToMsgBox(title, textColor, true);
				AppendToMsgBox(txt, textColor, false);
			}, null);
		}
		private static Font? BoldFont, NormalFont;
		private void AppendToMsgBox(string str, Color color, bool bold, bool leftAlign = true) {
			MsgBox.SelectionStart = MsgBox.TextLength;
			MsgBox.SelectionLength = 0;

			MsgBox.SelectionColor = color;
			if (leftAlign) {
				MsgBox.SelectionAlignment = HorizontalAlignment.Left;
			} else {
				MsgBox.SelectionAlignment = HorizontalAlignment.Right;
			}
			if (bold) {
				BoldFont ??= new Font(MsgBox.Font, FontStyle.Bold);
				NormalFont ??= new Font(MsgBox.Font, FontStyle.Regular);
				MsgBox.SelectionFont = BoldFont;
				MsgBox.AppendText(str + "\r\n");
				MsgBox.SelectionFont = NormalFont;
			} else {
				MsgBox.AppendText(str + "\r\n");
			}
		}

		public async Task DisconnectMqttAsync(MqttServer server) {
			var mqttClient = server.Mqtt.Client;
			if (mqttClient != null && mqttClient.IsConnected) {
				await mqttClient.DisconnectAsync();
				server.Mqtt.Client = null;
				server.Mqtt.State = ServerState.已断开;
				uiTask?.Post(_ => {
					SetServerState(server, true);
				}, null);
			}
		}
		private static async void UnscribeTopic(MQTTnet.Client.IMqttClient mqttClient, string topic) {
			try {
				await mqttClient.UnsubscribeAsync(topic);
			} catch (Exception) {
			}
		}
		private static async void SubscribeTopic(MQTTnet.Client.IMqttClient mqttClient, string topic, int qos) {
			try {
				await mqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic(topic)
					.WithQualityOfServiceLevel((MQTTnet.Protocol.MqttQualityOfServiceLevel)qos)
					.Build());
			} catch (Exception) {
			}
		}

		private void ServerList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				if (e.Node.Parent != null) {
					//subscribe
					SubscribeEnable();
				} else {
					//server
					ServerControl();
				}
			}
		}

		private void CopyMenuItem_Click(object sender, EventArgs e) {
			if (TextBoxMenu.SourceControl is RichTextBox richTextBox) {
				richTextBox.Copy();
			}
		}
		private void PasteMenuItem_Click(object sender, EventArgs e) {
			if (TextBoxMenu.SourceControl is RichTextBox richTextBox) {
				richTextBox.Paste();
			}
		}
		private void CutMenuItem_Click(object sender, EventArgs e) {
			if (TextBoxMenu.SourceControl is RichTextBox richTextBox) {
				richTextBox.Cut();
			}
		}

		private void TextBoxMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
			bool hasSelectedText = TextBoxMenu.SourceControl is RichTextBox richTextBox && !string.IsNullOrEmpty(richTextBox.SelectedText);
			CutMenuItem.Enabled = hasSelectedText;
			CopyMenuItem.Enabled = hasSelectedText;

			PasteMenuItem.Enabled = Clipboard.ContainsText();
		}
	}
}
