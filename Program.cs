using System;
using System.IO;

namespace advent_of_code_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = args[0];
            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Can't work without input!");
            }

            int sum = 0;
            using (var inputReader = new StreamReader(
                File.Open(inputFile, FileMode.Open))
            )
            {
                while (!inputReader.EndOfStream)
                {            
                    int mass = Int32.Parse(inputReader.ReadLine().Trim());
                    int fuel = CalculateFuel(mass);
                    //Console.WriteLine($"Fuel for Mass({mass}): {fuel}");

                    sum += fuel;
                }
            }

            Console.WriteLine($"Fuel Sum: {sum}");
        }

        private static int CalculateFuel(int moduleMass)
        {
            int fuel = moduleMass / 3 - 2;
            if (fuel > 0) {
                return fuel + CalculateFuel(fuel);
            } else {
                return 0;
            }
        }
    }
}
