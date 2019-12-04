using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using puzzle_3;

namespace WireIntercept.Tests
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void TestConvertPoint()
        {
            var input = "R8";
            var expected = new Point(8,0);
            
            Assert.AreEqual(expected, Program.ConvertPoint(new Point(0,0), input));
        }
        [TestMethod]
        public void TestConvertRoute()
        {
            var input = new List<string> {"R8","U5","L5","D3"};
            var expected = new List<Point> { 
                new Point(8,0), 
                new Point(8,5), 
                new Point(3,5), 
                new Point(3,2) };
            
            CollectionAssert.AreEqual(expected, Program.ConvertRoute(input));
        }

        [TestMethod]
        public void TestIntersection()
        {
            var s1 = new Segment( new Point(0,1), new Point(2,1) );
            var s2 = new Segment( new Point(1,0), new Point(1,2) );
            
            Assert.AreEqual(
                new Point(1,1),
                s1.GetInsersect(s2),
                "(0,1) - (2,1) // (1,0) - (1,2)"
            );

            s1 = new Segment( new Point(6,7), new Point(6,3) );
            s2 = new Segment( new Point(3,5), new Point(8,5) );
            
            Assert.AreEqual(
                new Point(6,5),
                s1.GetInsersect(s2),
                "(6,7) - (6,3) // (3,5) - (8,5)"
            );
        }

        [TestMethod]
        public void TestFindIntersects() 
        {
            var wire1 = new List<string> {
                "R8","U5","L5","D3"
            };
            var wire2 = new List<string> {
                "U7","R6","D4","L4"
            };
            
            var wire1Points = new Path(Program.ConvertRoute(wire1));
            var wire2Points = new Path(Program.ConvertRoute(wire2));

            var segments_w1 = wire1Points.Segments;
            var segments_w2 = wire2Points.Segments;

            List<Point> intsec = wire1Points.GetIntersectionsWith(wire2Points);

            CollectionAssert.AreEquivalent(
                new List<Point> {
                    new Point(3,3),
                    new Point(6,5)
                },
                intsec
            );

        }

        [TestMethod]
        public void TestPathTo() {
            var wire1 = new List<string> {
                "R8","U5","L5","D3"
            };
            var w1 = new Path(Program.ConvertRoute(wire1));
            Assert.AreEqual(1, w1.GetStepsTo(new Point(1,0)));
            Assert.AreEqual(2, w1.GetStepsTo(new Point(2,0)));
            Assert.AreEqual(3, w1.GetStepsTo(new Point(3,0)));
            Assert.AreEqual(4, w1.GetStepsTo(new Point(4,0)));
            Assert.AreEqual(5, w1.GetStepsTo(new Point(5,0)));
            Assert.AreEqual(6, w1.GetStepsTo(new Point(6,0)));
            Assert.AreEqual(7, w1.GetStepsTo(new Point(7,0)));
            Assert.AreEqual(8, w1.GetStepsTo(new Point(8,0)));
            Assert.AreEqual(9, w1.GetStepsTo(new Point(8,1)));
            Assert.AreEqual(10, w1.GetStepsTo(new Point(8,2)));
            Assert.AreEqual(11, w1.GetStepsTo(new Point(8,3)));
            Assert.AreEqual(12, w1.GetStepsTo(new Point(8,4)));
            Assert.AreEqual(13, w1.GetStepsTo(new Point(8,5)));
            Assert.AreEqual(20, w1.GetStepsTo(new Point(3,3)));
        }

        [DataTestMethod]
        [DataRow("R8,U5,L5,D3", "U7,R6,D4,L4", 30)]
        [DataRow("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", 610)]
        [DataRow("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", 410)]
        public void TestShortestPath(string p1, string p2, int result) {
            var wire1 = new List<string>(p1.Split(','));
            var wire2 = new List<string>(p2.Split(','));

            var w1 = new Path(Program.ConvertRoute(wire1));
            var w2 = new Path(Program.ConvertRoute(wire2));

            var ints = w1.GetIntersectionsWith(w2);
            int sp = Program.FindShortestPathTo(ints, w1, w2);

            Assert.AreEqual(result, sp, "shortest path documented");
        }
    }
}
