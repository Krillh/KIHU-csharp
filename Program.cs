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

    public static class Globals
    {


        public static class Errors
        {
            public const string BadInputError = "ERROR: that command dosen't exist";
        }
    };

    public class MyConsole
    {

        private IDictionary<string, Action<string[]>> actions;
        public MyConsole()
        {
            actions = new Dictionary<string, Action<string[]>>() {
                {"test", this.Test},
                {"encode", this.Encode},
                {"decode", this.Decode},
                {"listcodechars", this.ListCodeChars},
                {"clearconsole", this.ClearConsole},
                {"playmover", this.PlayMover}
            };
        }


        public void Run()
        {
            while (true)
            {
                Console.Write("> ");
                string line = Console.ReadLine();
                string[] parts = line.Split(' ');
                var args = parts.Skip(1).ToArray();
                if (this.actions.TryGetValue(parts[0], out var a))
                {
                    a(args);
                }
                else
                {
                    Console.Error.WriteLine(Globals.Errors.BadInputError);
                }
            }
        }

        private void Test(string[] arg)
        {
            Console.WriteLine("all good");
        }
        private void Encode(string[] arg)
        {
            var argString = string.Join(' ', arg).ToLowerInvariant();
            string symb = " abcdefghijklmnopqrstuvwxyz,.?!-+=:'1234567890()$/";
            string encs = "HvDTlVMnwqTpJaRS&zXmNBcPQOWLAghEiIdYuyxjGfsFryUoI$";
            string outMsg = "";
            for (int i = 0; i < argString.Length; i++)
            {
                int index = Array.IndexOf(symb.ToArray(), argString[i]);
                outMsg += encs[index];
            }
            Console.WriteLine(outMsg);
        }
        private void Decode(string[] arg)
        {
            var inMsg = arg;
            string symb = " abcdefghijklmnopqrstuvwxyz,.?!-+=:'1234567890()$/";
            string encs = "HvDTlVMnwqtpJaRS&zXmNBcPQOWLAghEiIdYuyxjGfsFryUoI$";
            string outMsg = "";
            for (int i = 0; i < inMsg.Length; i++)
            {
                int index = Array.IndexOf(encs.ToArray(), inMsg[i]);
                outMsg += symb[index];
            }
            Console.WriteLine(outMsg);
        }
        private void ListCodeChars(string[] arg)
        {
            string symb = " abcdefghijklmnopqrstuvwxyz,.?!-+=:'1234567890()$/";
            var list = "'" + string.Join("','", symb.ToCharArray()) + "'";
            Console.WriteLine(list);
        }
        private void ClearConsole(string[] a)
        {
            Console.Clear();
        }
        private void PlayMover(string[] a) {
            var pixels = "";
            int[] playerPos = {1,1};
            var isPlaying = true;
            for (var i = 0; i < 100; i++) {
                pixels += "0";
            }
            while (isPlaying) {
                for (var i = 0; i < 10; i++) {
                    var row = "";
                    for (var o = 0; o < 10; o++) {
                        row += pixels[i*o];
                    }
                    Console.WriteLine(row);
                }
                var key = Console.ReadKey(true);
                Console.WriteLine(key.ToString());
            }
        }
    }
}
