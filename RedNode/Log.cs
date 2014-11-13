using System;
using System.Runtime.InteropServices;

namespace RedNode
{
    class Log
    {
        public static void L(string s)
        {
            Console.WriteLine(s);
        }

        public static void D(string s)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(s);
            Console.ResetColor();
        }
    }
}
