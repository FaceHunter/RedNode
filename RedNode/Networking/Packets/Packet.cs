using System;
using System.IO;
using System.Text;
using RedNode.Utils;

namespace RedNode.Networking.Packets
{
    class Packet
    {
        public string name;
        public int ID;
        public byte[] Data = new byte[]{};

        public byte[] Get()
        {
            RedBuffer buffer = new RedBuffer();
            buffer.WriteInt32(this.ID);
            buffer.WriteBlob(this.Data);
            return buffer.GetBuffer();
        }
    }
}
