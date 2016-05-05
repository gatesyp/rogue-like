using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    // location class which holds x,y coordinates
    public class Loc
    {

        public int x;
        public int y;
        // set default location for all elements
        public Loc()
        {
            x = 0;
            y = 0;
        }
        // set the location
        public void Is(int first, int second)
        {
            x = first;
            y = second;
        }
        // pretty print function for debugging purposes
        public void Print()
        {
            Console.Write("(" + x + ", " + y + ")");
        }
        // overload equality operators to test for equality
        public static bool operator ==(Loc obj1, Loc obj2)
        {
            return (obj1.x == obj2.x && obj1.y == obj2.y);
        }
        public static bool operator !=(Loc obj1, Loc obj2)
        {
            return !(obj1.x == obj2.x && obj1.y == obj2.y);
        }
    }
}
