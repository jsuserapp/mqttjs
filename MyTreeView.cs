using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Core.Tokens;
using static System.ComponentModel.Design.ObjectSelectorEditor;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MqttJs {
	internal class MyTreeView : TreeView {
		private int _clickCount = 0;
		private List<MqttServer>? servers;
		private ContextMenuStrip? menu, subMenu;
		protected override CreateParams CreateParams {
			//防闪烁
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x02000000;
				return cp;
			}
		}
		#region 禁用双击展开/折叠
		protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e) {
			base.OnNodeMouseClick(e);
			if (e.Button == MouseButtons.Right) {
				SelectedNode = e.Node;
			}
		}
		protected override void OnMouseDown(MouseEventArgs e) {
			base.OnMouseDown(e);
			if(e.Button == MouseButtons.Left) {
				_clickCount = e.Clicks;
			}
		}
		protected override void OnBeforeCollapse(TreeViewCancelEventArgs e) {
			base.OnBeforeCollapse(e);
			if (SelectedNode == null)
				return;
			if (_clickCount > 1)
				e.Cancel = true;
			else
				e.Cancel = false;
		}
		protected override void OnBeforeExpand(TreeViewCancelEventArgs e) {
			base.OnBeforeExpand(e);
			if (SelectedNode == null)
				return;
			if (_clickCount > 1)
				e.Cancel = true;
			else
				e.Cancel = false;
		}
		#endregion
		public void LoadNodes(ContextMenuStrip menu, ContextMenuStrip subMenu) {
			var conf = ConfigYaml.GetInstance();
			servers = conf.ServerList;
			this.menu = menu;
			this.subMenu = subMenu;
			foreach (MqttServer server in servers) {
				AddServerNode(server);
			}
		}
		public MqttServer? GetSelectedServer() {
			if (SelectedNode == null) {
				return null;
			}
			if (SelectedNode.Parent != null) {
				//如果当前选中节点是订阅节点，使用它的父节点。
				return (MqttServer)SelectedNode.Parent.Tag;
			} else {
				return (MqttServer)SelectedNode.Tag;
			}
		}
		private static void SetServerNodeState(TreeNode node) {
			if (node.Tag is MqttServer server) {
				if (server.Mqtt.Client != null) {
					node.ForeColor = Color.Green;
					node.ImageIndex = 1;
					node.SelectedImageIndex = 1;
				} else {
					node.ForeColor = Color.Gray;
					node.ImageIndex = 0;
					node.SelectedImageIndex = 0;
				}
			}
		}
		private static void SetSubscribeNodeState(TreeNode sNode) {
			if (sNode.Tag is MqttSubscribe sub) {
				if (sub.Enabled) {
					sNode.ForeColor = Color.Green;
					sNode.ImageIndex = 3;
					sNode.SelectedImageIndex = 3;
				} else {
					sNode.ForeColor = Color.Gray;
					sNode.ImageIndex = 2;
					sNode.SelectedImageIndex = 2;
				}
			}
		}
		public void RefreshSubscribeNode() {
			var node = SelectedNode;
			if (node.Parent == null) {
				return;
			}
			if (node.Tag is MqttSubscribe sub) {
				node.Text = sub.Name == "" ? sub.Topic : sub.Name;
			}
			SetSubscribeNodeState(node);
		}
		public void RefreshServerNode() {
			var node = SelectedNode;
			if (node.Parent != null) {
				return;
			}
			if(node.Tag is MqttServer server) {
				node.Text = server.Name;
			}
			SetServerNodeState(node);
		}
		public void SetNodeState() {
			foreach(TreeNode node in Nodes) {
				SetServerNodeState(node);
				foreach (TreeNode sNode in node.Nodes) {
					SetSubscribeNodeState(sNode);
				}
			}
		}
		public bool DeleteServer() {
			var node = SelectedNode;
			if (node == null) {
				return false;
			}
			if (node.Parent != null) {
				node = node.Parent;
			}
			var server = (MqttServer)node.Tag;
			DialogResult dialogResult = MessageBox.Show($"您确定要删除 {server.Name} 吗?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (dialogResult == DialogResult.Yes) {
				Nodes.Remove(node);
				servers?.Remove(server);
				ConfigYaml.Save();
				return true;
			}
			return false;
		}
		public void AddServerNode(MqttServer server) {
			var node = new TreeNode(server.Name) {
				Tag = server,
				ContextMenuStrip = menu,
			};
			SetServerNodeState(node);
			foreach (var sub in server.SubscribeList) {
				AddSubscribeNode(node, sub);
			}
			Nodes.Add(node);
		}
		public void AddServer(MqttServer server) {
			servers?.Add(server);
			AddServerNode(server);
		}
		public MqttSubscribe? GetSelectedSubscribe() {
			if (SelectedNode == null || SelectedNode.Parent == null) {
				return null;
			}
			return (MqttSubscribe)SelectedNode.Tag;
		}
		public void AddSubscribe(MqttSubscribe sub) {
			var node = SelectedNode;
			if (node == null) {
				return;
			}
			if (node.Parent != null) {
				node = node.Parent;
			}
			var server = node.Tag as MqttServer;
			server?.SubscribeList.Add(sub);
			AddSubscribeNode(node, sub);
		}
		public void AddSubscribeNode(TreeNode node, MqttSubscribe sub) {
			var name = sub.Name;
			if (name == "") {
				name = sub.Topic;
			}
			var subNode = new TreeNode(name) {
				Tag = sub,
				ContextMenuStrip = subMenu,
			};
			SetSubscribeNodeState(subNode);
			node.Nodes.Add(subNode);
		}
		public bool DeleteSubscribe() {
			var node = SelectedNode;
			if (node == null || node.Parent == null) {
				return false;
			}
			var server = (MqttServer)node.Parent.Tag;
			var sub = (MqttSubscribe)node.Tag;
			DialogResult dialogResult = MessageBox.Show($"您确定要删除 {node.Text} 吗?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (dialogResult == DialogResult.Yes) {
				Nodes.Remove(node);
				server.SubscribeList.Remove(sub);
				ConfigYaml.Save();
				return true;
			}
			return false;
		}
	}
}
