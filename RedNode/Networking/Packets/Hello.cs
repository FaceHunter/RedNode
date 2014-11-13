using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedNode.Networking.Packets
{
    /// <summary>
    /// HELLO
    /// Client->Server
    /// 1
    /// No Data
    /// </summary>
    class Hello : Packet
    {
        public string name = "HELLO";
        public int ID = 1;
        public byte[] Data = new byte[]{}; //None
    }
}
