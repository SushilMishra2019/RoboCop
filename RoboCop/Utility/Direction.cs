using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboCop.Utility
{
    public static class Direction
    {
        public const string NORTH = "NORTH";
        public const string EAST = "EAST";
        public const string SOUTH = "SOUTH";
        public const string WEST = "WEST";

        private static readonly LinkedList<string> _directions
            = new LinkedList<string>(new[] { NORTH, EAST, SOUTH, WEST });

        public static bool IsValid(this string direction)
            => _directions.Contains(direction);

        public static string RotateLeft(this string direction)
        {
            var current = _directions.Find(direction);

            if (current == null)
                return null;

            return (current.Previous ?? _directions.Last).Value;
        }

        public static string RotateRight(this string direction)
        {
            var current = _directions.Find(direction);

            if (current == null)
                return null;

            return (current.Next ?? _directions.First).Value;
        }
    }
}
