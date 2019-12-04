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

        #nullable enable
        public static List<Point> FindIntersections(
            List<string> wire1, List<string> wire2) {
            
            var wire1Points = ConvertRoute(wire1);
            var wire2Points = ConvertRoute(wire2);

            var segments_w1 = ConvertToSegments(wire1Points);
            var segments_w2 = ConvertToSegments(wire2Points);

            var intersects = new List<Point>();
            foreach (var s1 in segments_w1) {
                foreach (var s2 in segments_w2) {
                    Point? i = s1.GetInsersect(s2);
                    if (i != null) {
                        intersects.Add(i);
                    }
                }
            }

            return intersects;
        }

        private static List<Segment> ConvertToSegments(List<Point> points)
        {
            List<Segment> segments = new List<Segment>();
            Point pLast = new Point();

            foreach(var p in points)
            {
                segments.Add( new Segment(pLast, p));
                pLast = p;
            }

            return segments;
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
