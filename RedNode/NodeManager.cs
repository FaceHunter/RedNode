using System;
using System.Net;
using System.Collections.Generic;

using RedNode.Utils;
namespace RedNode
{
    class NodeManager
    {
        public Dictionary<int, Node> Nodes = new Dictionary<int, Node> { };
        public NodeManager()
        {

        }

        public void Initialize(Global global)
        {
            Node self = new Node();
            self.Address = new IPEndPoint(Generic.GetOwnIp(), Properties.Settings.Default.ListenPort);
            self.NodeMode = NodeMode.Self;
            this.Nodes.Add(0, self);

            foreach (string str in RedNode.Properties.Settings.Default.InitNodes)
            {
                Node node = new Node();
                string[] strings = str.Split(':');
                IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse(strings[0]), int.Parse(strings[1]));
                node.Address = endpoint;
                global.Sender.ConnectToNode(node);
            }
        }

        public void AddNewNode(Node node)
        {
            foreach(Node _node in this.Nodes.Values)
            {
                if (_node.Address.Address == node.Address.Address)
                    return;
            }
            node.NodeID = CalculateNodeID();
            Log.L(String.Format("Adding node {0} ({1}:{2})", node.NodeID, node.Address.Address, node.Address.Port));
            this.Nodes.Add(node.NodeID, node);
        }

        public void AddNode(Node node)
        {
            foreach (Node _node in this.Nodes.Values)
            {
                if (_node.Address.Address == node.Address.Address)
                    return;
            }
            Log.L(String.Format("Adding node {0} ({1}:{2})", node.NodeID, node.Address.Address, node.Address.Port));
            this.Nodes.Add(node.NodeID, node);
        }

        public int CalculateNodeID()
        {
            for(int i=0;;i++)
            {
                if(!this.Nodes.ContainsKey(i))
                {
                    return i;
                }
            }
        }
    }
}
