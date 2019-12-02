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
            if (args.Length < 2 || !File.Exists(args[0]))
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

            //int NOUN = Int32.Parse(args[1]);
            //int VERB = Int32.Parse(args[2]);

            int result = 0;
            int wanted = Int32.Parse(args[1]);
            int i=0,j=0;
            for(i=0; i<=99 && result != wanted; i++) {
                for(j=0; j<=99 && result != wanted; j++) {
                    Console.WriteLine($"Trying NOUN:{i},VERB:{j}");
                    result = RunProgram(opcodes.ToList(), i, j);
                }
            }
            // run the program
            //int result = RunProgram(opcodes, NOUN, VERB);

            Console.WriteLine($"NOUN:{i} ,VERB:{j}");
        }

        public static List<Func<int,int,int>> ops = new List<Func<int,int,int>>{
            null,
            (x,y) =>  x + y ,
            (x,y) =>  x * y 
        };
        public static int RunProgram(List<int> opcodes, int NOUN, int VERB)
        {
            opcodes[1] = NOUN;
            opcodes[2] = VERB;            

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

            return opcodes[0];
        }
    }
}
