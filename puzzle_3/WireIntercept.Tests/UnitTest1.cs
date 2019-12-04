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
                s1.GetInsersect(s2)
            );
        }
    }
}
