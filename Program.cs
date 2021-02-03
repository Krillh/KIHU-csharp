using System;
using System.Collections.Generic;
using System.Linq;

namespace KIHU_csharp
{
    class Program
    { 
        static void Main(string[] args)
        {
            var me = new MyConsole();
            me.Run();            
        }
    }

    public static class globals {
        public static String arg = "";
    };

    public class MyConsole {

        private IDictionary<string, Action> actions;
        public MyConsole() {
            actions = new Dictionary<string, Action>() {
                {"test", this.test},
                {"encode", this.encode},
                {"decode", this.decode}
            };
        }


        public void Run() {
            while (true) {
                Console.Write("> ");
                string line = Console.ReadLine();
                string[] parts = line.Split('~');
                string args = parts[1].ToString();
                globals.arg = args;
                if (this.actions.TryGetValue(parts[0], out var a)) {
                    a();
                } else {
                    Console.WriteLine(line);
                }
            }
        }

        private void test() {
            Console.WriteLine("all good");
        }
        private void encode() {
            string inMsg = globals.arg;
            string symb = " abcdefghijklmnopqrstuvwxyz,.?!-+=:'1234567890()$/";
            string encs = "HvDTlVMnwqTpJaRS&zXmNBcPQOWLAghEiIdYuyxjGfsFryUoI$";
            string outMsg = "";
            for (int i = 0; i < inMsg.Length; i++) {
                int index = Array.IndexOf(symb.ToArray(), inMsg[i]);
                outMsg += encs[index];
            }
            Console.WriteLine(outMsg);
        }
        private void decode() {
            string inMsg = globals.arg;
            string symb = " abcdefghijklmnopqrstuvwxyz,.?!-+=:'1234567890()$/";
            string encs = "HvDTlVMnwqtpJaRS&zXmNBcPQOWLAghEiIdYuyxjGfsFryUoI$";
            string outMsg = "";
            for (int i = 0; i < inMsg.Length; i++) {
                int index = Array.IndexOf(encs.ToArray(), inMsg[i]);
                outMsg += symb[index];
            }
            Console.WriteLine(outMsg);
        }
    }
}
