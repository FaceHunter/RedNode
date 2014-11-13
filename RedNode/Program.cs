using System;
using System.Collections.Generic;

using RedNode.Networking;
using RedNode.Networking.Sender;

namespace RedNode
{
    class Global
    {
        public NodeManager NodeManager;
        public Listener Listener;
        public Sender Sender;
    }
    class Program
    {
        static NodeManager manager;
        static Listener listener;
        static Sender sender;

        static void Main(string[] args)
        {
            Log.L("Welcome to RedNode!");
            manager = new NodeManager();
            listener = new Listener();
            sender = new Sender();

            Global glob = new Global();
            glob.NodeManager = manager;
            glob.Listener = listener;
            glob.Sender = sender;

            listener.Initialize(glob);
            sender.Initialize(glob);
            manager.Initialize(glob);


            Console.ReadKey();
        }
    }
}
