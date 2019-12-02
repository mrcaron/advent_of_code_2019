using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeRunner
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0 || !File.Exists(args[0]))
            {
                Console.WriteLine("Please provide a file input");
            }

            // read in the program
            string program = "";
            using( var reader = new StreamReader(
                File.Open(args[0], FileMode.Open)
            )) {
                program = reader.ReadToEnd();
            }

            var opcodesStr = program.Split(',').ToList();
            List<int> opcodes = opcodesStr.ConvertAll( x => Int32.Parse(x));

            // run the program
            RunProgram(opcodes);

            Console.WriteLine(String.Join(',',opcodes));
        }

        public static List<Func<int,int,int>> ops = new List<Func<int,int,int>>{
            null,
            (x,y) =>  x + y ,
            (x,y) =>  x * y 
        };
        public static void RunProgram(List<int> opcodes)
        {
            for (int i = 0; i < opcodes.Count && opcodes[i] != 99; i+=4) 
            {
                var f = ops[ opcodes[i] ];
                var arg1slot = opcodes[i+1];
                var arg2slot = opcodes[i+2];
                var resultslot = opcodes[i+3];

                var arg1 = opcodes[arg1slot];
                var arg2 = opcodes[arg2slot];

                opcodes[resultslot] = f(arg1,arg2);
            }
        }
    }
}
