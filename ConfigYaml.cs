using MQTTnet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace MqttJs {
	public enum ServerState {
		已断开, 正在连接, 已连接, 正在断开
	}
	public class MqttInfo {
		public ServerState State = ServerState.已断开;

		public IMqttClient? Client {
			get;
			internal set;
		}
	}
	public class MqttSubscribe {
		[YamlMember(Alias = "name")]
		public string Name {
			get;set;
		}
		[YamlMember(Alias = "topic")]
		public string Topic {
			get; set;
		}
		[YamlMember(Alias = "qos")]
		public int Qos {
			get; set;
		}
		[YamlMember(Alias = "enabled")]
		public bool Enabled {
			get; set;
		} = true;
		[YamlMember(Alias = "color")]
		public int Color {
			get; set;
		} = 0;
		public MqttSubscribe() {
			Name = string.Empty;
			Topic = string.Empty;
			Qos = 0;
		}
	}
	public class MqttServer {
		[YamlMember(Alias = "name")]
		public string Name {
			get; set;
		}
		[YamlMember(Alias = "ip")]
		public string Ip {
			get; set;
		}
		[YamlMember(Alias = "port")]
		public int Port {
			get; set;
		}
		[YamlMember(Alias = "username")]
		public string Username {
			get; set;
		}
		[YamlMember(Alias = "password")]
		public string Password {
			get; set;
		}
		[YamlMember(Alias = "subscribe_list")]
		public List<MqttSubscribe> SubscribeList {
			get; set;
		}
		[YamlIgnore]
		public MqttInfo Mqtt {
			get; set;
		}
		public MqttServer() {
			Name = string.Empty;
			Ip = string.Empty;
			Port = 0;
			Username = string.Empty;
			Password = string.Empty;
			SubscribeList = [];
			Mqtt = new MqttInfo();
		}
		public void AddSubscribe(MqttSubscribe scribe) {
			SubscribeList.Add(scribe);
		}
		public void RemoveSubscribe(MqttSubscribe scribe) {
			SubscribeList.Remove(scribe);
		}
		public void RemoveSubscribe(int index) {
			SubscribeList.RemoveAt(index);
		}
		public MqttSubscribe? FindSubscribe(string topic) {
			foreach (MqttSubscribe sub in SubscribeList) {
				if (sub.Topic == topic)
					return sub;
			}
			return null;
		}
	}
	public class Rectangle {
		public int x, y, width, height = 0;
		public Rectangle() {
		}
		public Rectangle(int x, int y, int w, int h) {
			this.x = x;
			this.y = y;
			this.width = w;
			this.height = h;
		}
		public void SetValue(int x, int y, int w, int h) {
			this.x = x;
			this.y = y;
			this.width = w;
			this.height = h;
		}
		public void SetValue(Point location, Size size) {
			this.x = location.X;
			this.y = location.Y;
			this.width = size.Width;
			this.height = size.Height;
		}
		public Size Size() {
			return new Size(width, height);
		}
		public Point Location() {
			return new Point(x, y);
		}
	}
	public class UIState {
		[YamlMember(Alias = "form_rect")]
		public Rectangle FormRect;
		[YamlMember(Alias = "auto_json")]
		public bool AutoJson;
		public UIState() {
			FormRect = new Rectangle(300, 200, 800, 500);
			AutoJson = true;
		}
	}
	internal class ConfigYaml {
		private static readonly string confFile = "conf.yaml";
		private static ConfigYaml? instance;

		[YamlMember(Alias = "ui_state")]
		public UIState UIState;
		[YamlMember(Alias = "server_list")]
		public List<MqttServer> ServerList {
			get; set;
		}

		public ConfigYaml() {
			UIState = new UIState();
			ServerList = [];
		}
		public void AddServer(MqttServer server) {
			ServerList.Add(server);
		}
		public void RemoveServer(int index) {
			ServerList.RemoveAt(index);
		}
		public void RemoveServer(MqttServer server) {
			ServerList.Remove(server);
		}
		internal MqttServer GetServer(int index) {
			return ServerList[index];
		}
		public static void Save() {
			if (instance == null) {
				return;
			}
			var serializer = new SerializerBuilder().Build();
			using var writer = new StreamWriter(confFile);
			serializer.Serialize(writer, instance);
		}

		private static ConfigYaml Load() {
			if (!File.Exists(confFile)) {
				return new ConfigYaml();
			}

			var deserializer = new DeserializerBuilder().Build();
			try {
				using var reader = new StreamReader(confFile);
				instance = deserializer.Deserialize<ConfigYaml>(reader);
				return instance;

			} catch (Exception e) {
				MessageBox.Show(e.Message);
			}
			return new ConfigYaml();
		}
		public static ConfigYaml GetInstance() {
			instance ??= Load();
			return instance;
		}

	}
}
