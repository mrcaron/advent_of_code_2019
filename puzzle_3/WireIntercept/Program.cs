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
            
            var wire1path = new Path(ConvertRoute(wire1));
            var wire2path = new Path(ConvertRoute(wire2));
            
            var intersections = wire1path.GetIntersectionsWith(wire2path);
            
            if (args.Length > 1 && args[1] == "closest") {
                var top = intersections.ConvertAll( p => Math.Abs(p.X) + Math.Abs(p.Y) );
                top.Sort();
                Console.Out.WriteLine(top.First());
            } else {
                // find shortest path to points
                var steps = FindShortestPathTo(intersections, wire1path, wire2path);
            }
        }

        public static int FindShortestPathTo(List<Point> intersections, Path path1, Path path2)
        {
            foreach (var p in intersections) 
            {
                // p is an intersection
            }
            throw new NotImplementedException();
        }

        private static Dictionary<char,Func<Point,int,Point>> PlotNext = 
            new Dictionary<char,Func<Point,int,Point>> {
                { 'R', (p,i) => new Point(p.X + i, p.Y) },
                { 'L', (p,i) => new Point(p.X - i, p.Y) },
                { 'D', (p,i) => new Point(p.X, p.Y - i) },
                { 'U', (p,i) => new Point(p.X, p.Y + i) }
        };

        public static List<Point> ConvertRoute(List<string> route) {
            List<Point> points = new List<Point>();
            
            foreach(var r in route)
            {
                Point p = points.DefaultIfEmpty(new Point()).LastOrDefault();
                points.Add( ConvertPoint(p, r) );
            }

            return points;
        }

        public static Point ConvertPoint(Point previous, string route) {
            char direction = route.First();
            int length = Int32.Parse( route.Substring(1) );
            
            return PlotNext[direction](previous,length);
        }
    }

}
