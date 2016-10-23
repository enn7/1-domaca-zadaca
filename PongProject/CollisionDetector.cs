using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igrica
{
    public class CollisionDetector
    {
        public static bool Overlaps(IPhysicalObject2D a, IPhysicalObject2D b)
        {
            if ((a.X > b.X && a.X < b.X + b.Width) && (a.Y > b.Y && a.Y < b.Y + b.Height) || (a.X + a.Width > b.X && a.X + a.Width < b.X + b.Width) && (a.Y + a.Height > b.Y && a.Y + a.Height < b.Y + b.Height))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
