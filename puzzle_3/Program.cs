using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace puzzle_3
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1 || !File.Exists(args[0])) {
                Console.WriteLine("puzzle_3 <inputfile>");
            }

            List<string> wire1,wire2;
            using(var reader = new StreamReader(
                File.Open(args[0], FileMode.Open)
            )) {
                wire1 = reader.ReadLine().Split(',').ToList();
                wire2 = reader.ReadLine().Split(',').ToList();
            }

            var intersections = FindIntersections(wire1, wire2);
            
        }
        public static List<string> FindIntersections(List<string> wire1, List<string> wire2) {
            throw new NotImplementedException();
        }
    }

}
