using System;
using System.IO;

namespace CodeRunner
{
    class Program
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

        public static object RunProgram(string program)
        {
            throw new NotImplementedException();
        }
    }
}
