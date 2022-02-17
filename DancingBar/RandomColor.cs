using System;
using System.Drawing;

namespace DancingBar
{
    public class RandomColor
    {
        public static Color GetColor()
        {
            var rnd = new Random();
            int r = rnd.Next(0, 256);
            int g = rnd.Next(0, 256);
            int b = rnd.Next(0, 256);
            return Color.FromArgb(r, g, b);
        }
    }
}
