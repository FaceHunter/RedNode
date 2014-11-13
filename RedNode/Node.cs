using System;
using System.Net;
using System.Net.Sockets;

namespace RedNode
{
    class Node
    {
        public int NodeID;
        public IPEndPoint Address;
        public Socket Socket;
        public byte[] Buffer = new byte[2048];
        public NodeMode NodeMode;
    }

    enum NodeMode
    {
        None = 0,
        Self = 1

    }
}
