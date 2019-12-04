using System.Collections.Generic;

namespace puzzle_3 {
    public class Path {
        private List<Point> points;
        public Path(List<Point> points) => this.points = points;

        private List<Segment> _segments = null;
        public List<Segment> Segments {
            get {
                if (_segments == null) {
                    _segments = new List<Segment>();
                    Point pLast = new Point();

                    foreach(var p in points)
                    {
                        _segments.Add( new Segment(pLast, p));
                        pLast = p;
                    }
                }
                return _segments;
            }
        }

        #nullable enable
        public List<Point> GetIntersectionsWith(Path path) {
            
            var intersects = new List<Point>();
            foreach (var s1 in this.Segments) {
                foreach (var s2 in path.Segments) {
                    Point? i = s1.GetInsersect(s2);
                    if (i != null) {
                        intersects.Add(i);
                    }
                }
            }

            return intersects;
        }
    }
}