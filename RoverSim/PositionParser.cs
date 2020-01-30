using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RoverSim
{
    public class PositionParser
    {
        public static Point ParsePosition(string input, out Direction direction)
        {

            if (input == null || input.Trim().Length == 0)
                throw new ArgumentException("Input can not be null or empty");

            var parts = input.Split(' ');

            if(parts.Length != 3)
            {
                throw new ArgumentException("Input string contains invalid arguments");
            }

            int northing = 0;
            int easting = 0;

            if(!Int32.TryParse(parts[0].Trim(), out easting) || !Int32.TryParse(parts[1].Trim(), out northing))
            {
                throw new ArgumentException("Input string contains invalid arguments");
            }

            var match = parts[2].Trim().ToUpper().IndexOfAny("NESW".ToCharArray()) != -1;

            if(!match)
            {
                throw new ArgumentException("Input string contains invalid arguments");
            }

            Point upperCorner = new Point(easting, northing);
            direction = (Direction) parts[2].Trim().ToUpper()[0];
            return upperCorner;

        }

        public static Point ParseUperBound(string input)
        {

            if (input == null || input.Trim().Length == 0)
                throw new ArgumentException("Input can not be null or empty");

            var parts = input.Split(' ');

            if (parts.Length != 2)
            {
                throw new ArgumentException("Input string contains invalid arguments");
            }

            int northing = 0;
            int easting = 0;

            if (!Int32.TryParse(parts[0].Trim(), out easting) || !Int32.TryParse(parts[1].Trim(), out northing))
            {
                throw new ArgumentException("Input string contains invalid arguments");
            }

            Point upperCorner = new Point(easting, northing);
            return upperCorner;

        }
    }
}
