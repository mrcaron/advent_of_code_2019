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

    public class Segment {

        public Point P1 {get;set;}
        public Point P2 {get;set;}

        public int X_MAX {get;private set;}
        public int X_MIN {get;private set;}
        public int Y_MAX {get;private set;}
        public int Y_MIN {get;private set;}

        public bool isVertical {get;private set;}

        public Segment(Point p1, Point p2) {
            (P1,P2) = (p1,p2);

            var Xminmax = new int[] { p1.X, p2.X };
            var Yminmax = new int[] { p1.Y, p2.Y };

            //Array.Sort(Xminmax);
            //Array.Sort(Yminmax);

            (X_MIN,X_MAX) = p1.X < p2.X ? (p1.X,p2.X) : (p2.X,p1.X);
            (Y_MIN,Y_MAX) = p1.Y < p2.Y ? (p1.Y,p2.Y) : (p2.Y,p1.Y);

            isVertical = p1.Y == p2.Y; 
        } 
        public Point? GetInsersect(Segment s) {
            // No intersection if parallel segements
            if (s.isVertical && this.isVertical && 
                s.P1.X != this.P1.X) 
                return null;
            
            else if (!s.isVertical && !this.isVertical && 
                s.P1.Y != this.P1.Y)
                return null;

            // Case where s is horizontal
            else if (!s.isVertical && 
                this.X_MAX > s.P1.X && s.P1.X > this.X_MIN )
            {
                return new Point(s.P1.X, this.Y_MAX);
            }
            // Case where s is vertical
            else if (s.isVertical && 
                this.Y_MAX > s.P1.Y && s.P1.Y > this.Y_MIN)
            {
                return new Point(this.P1.X,s.P1.Y);
            }

            // there is no intersect
            return null;
        }
    }
}