using System;

using RedNode.Utils;
using RedNode.Networking.Packets;

namespace RedNode.Networking
{
    class PacketHandler
    {
        public static void HandlePacket(Node node)
        {
            Utils.RedBuffer redbuf = new Utils.RedBuffer(node.Buffer);

            int PacketId = 0;
            redbuf.ReadInt32(ref PacketId);
            Log.D("Received packet with ID: " + PacketId.ToString());
            switch(PacketId)
            {
                case 1: //Hello
                    Log.L("Received HELLO packet");

                    break;

                case 2: //Welcome
                    Log.L("Received WELCOME packet");
                    
                    break;

                default:
                    Log.L("Received UNKNOWN packet");
                    break;
            }

        }


    }
}
