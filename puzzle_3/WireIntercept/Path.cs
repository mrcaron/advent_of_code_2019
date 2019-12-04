using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace puzzle_3 {
    public class Path : IEnumerable {
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

        public int GetStepsTo(Point point)
        {
            var e1 = GetEnumerator();
            int steps1 = 0;
            while (! point.Equals(e1.Current)) {
                e1.MoveNext();
                steps1++;
            }
            return steps1;
        }

        public IEnumerator GetEnumerator()
        {
            return new PathEnumerator(points);
        }
    }

    public class PathEnumerator : IEnumerator
    {
        private int idx = -1;
        private Point? _currentP;
        private Segment? _currentSegment;
        private Point[] _points;

        public PathEnumerator(List<Point> points) => _points = points.ToArray();

        public object? Current => _currentP;

        public bool MoveNext()
        {
            if (idx < 0) {
                idx++;
                _currentP = new Point();
                _currentSegment = new Segment(_currentP, _points[idx]);
            }

            if ( _points[idx].Equals(_currentP)) {
                if (idx == _points.Count() - 1)
                {
                    _currentP = null;
                    return false;
                }
                idx++;
                _currentSegment = new Segment(_currentP, _points[idx]);
            }

            var nextPt = _points[idx];

            if (_currentSegment!.isVertical) {
                if (nextPt.Y > 0)
                    _currentP!.Y++;
                else
                     _currentP!.Y--;
            }
            else {
                if (nextPt.X > 0)
                    _currentP!.X++;
                else
                    _currentP!.X--;
            }

            return true;
        }

        public void Reset()
        {
            idx = -1;
            _currentP = null;
            _currentSegment = null;
        }
    }
}