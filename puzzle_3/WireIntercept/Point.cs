using System;
using System.Collections.Generic;

namespace puzzle_3
{
    public class Point 
    {
        #nullable enable

        public int X {get;set;}
        public int Y {get;set;}

        public Point() => (X,Y) = (0,0);
        public Point(int x, int y) => (X,Y) = (x,y);        

        public override bool Equals(object? obj) {
            if (obj is null || ! (obj is Point))
            {
                return false;
            } else
            {
                return ((Point)obj).X == this.X && 
                       ((Point)obj).Y == this.Y;
            }
        }

        public override int GetHashCode() {
            return X ^ Y;
        }
    }
}