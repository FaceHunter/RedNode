using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace RedNode.Networking
{
    class Listener
    {
        Global global;
        private static ManualResetEvent MRE = new ManualResetEvent(false);

        public void Initialize(Global global)
        {
            this.global = global;

            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(IPAddress.Any, Properties.Settings.Default.ListenPort));
            listener.Listen(2014);

            listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
            
        }

        public void AcceptCallback(IAsyncResult result)
        {
            Socket listener = (Socket)result.AsyncState;
            Socket sock = listener.EndAccept(result);
            Log.D("Accepted!");

            Node newnode = new Node();
            newnode.Address = (IPEndPoint)sock.RemoteEndPoint;
            newnode.Socket = sock;
            this.global.NodeManager.AddNode(newnode);
            Log.D("Added node");

            Log.L(String.Format("Accepted node from {0}:{1}", newnode.Address.Address, newnode.Address.Port));
            newnode.Socket.BeginReceive(newnode.Buffer, 0, newnode.Buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), newnode);

            listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
        }

        public void ReceiveCallback(IAsyncResult result)
        {
            Node node = (Node)result.AsyncState;
            node.Socket.EndReceive(result);

            PacketHandler.HandlePacket(node);
        }
    }
}
