using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sneik
{
    class HitDetection
    {
        public bool DetectHit(Point wormHead, Point treasure)
        {
            RectangleF wormHeadHitBox = new RectangleF(wormHead.X, wormHead.Y, 1, 1);
            RectangleF treasureHitBox = new RectangleF(treasure.X, treasure.Y, 1, 1);
            
            if (wormHeadHitBox.IntersectsWith(treasureHitBox))
            {
                return true;
            }
            
            return false;
        }

    }
}
