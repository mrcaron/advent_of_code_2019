using System;
using System.IO;

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

            // run the program
            var output = RunProgram(program);

            Console.WriteLine(output);
        }

        public static string RunProgram(string program)
        {
            var opcodeList = program.Split(',');
            for (int i = 0; i != 99 && i < opcodeList.Length; i+=4) 
            {

            }

            return String.Join(',',opcodeList);
        }
    }
}
