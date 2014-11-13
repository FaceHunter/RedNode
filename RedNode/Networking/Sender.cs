using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Collections.Specialized;

using RedNode.Utils;

namespace RedNode.Networking.Sender
{
    class Sender
    {
        Socket sock;
        public void Initialize(Global global)
        {
            this.sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        }

        public void ConnectToNode(Node node)
        {
            //Lets not connect to ourselves
            if (node.NodeMode == NodeMode.Self)
                return;

            Log.L(String.Format("Connecting to {0}:{1}", node.Address.Address, node.Address.Port));
            sock.BeginConnect(node.Address, new AsyncCallback(ConnectCallback), this.sock);
        }

        public void ConnectCallback(IAsyncResult result)
        {
            Socket sock = (Socket)result.AsyncState;
            sock.EndConnect(result);
            
            Packets.Hello hello = new Packets.Hello();
            byte[] buffer = hello.Get();

            sock.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(SendCallback), sock);
        }

        public void SendCallback(IAsyncResult result)
        {
            Socket sock = (Socket)result.AsyncState;

            Log.D(String.Format("Wrote {0} bytes!", sock.EndSendTo(result)));

            Log.L("Authed!");
        }
    }
}
