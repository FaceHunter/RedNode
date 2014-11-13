using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedNode.Networking.Packets
{
    class Welcome : Packet
    {
        public string name = "WELCOME";
        public int ID = 2;
        public byte[] Data = new byte[]{}; //NetworkId

    }
}
