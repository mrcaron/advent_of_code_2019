using System;
using System.IO;

namespace advent_of_code_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculateFuel(args[0]);
        }

        private static void CalculateFuel(string inputFile)
        {
            if (! File.Exists(inputFile))
            {
                Console.WriteLine("Can't work without input!");
            }

            using (var inputReader = new StreamReader(
                File.Open(inputFile, FileMode.Open))
            )
            {
                while(!inputReader.EndOfStream) 
                {
                    int mass = Int32.Parse(inputReader.ReadLine().Trim());
                    
                    int fuel = mass / 3 - 2;

                    Console.WriteLine($"Fuel for Mass({mass}): {fuel}");
                }
            }
        }
    }
}
