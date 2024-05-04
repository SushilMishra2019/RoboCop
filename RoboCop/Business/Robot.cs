using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoboCop.Interface;
using RoboCop.Utility;

namespace RoboCop.Business
{
    public class Robot : IRobot
    {
        private readonly int _xAxis;
        private readonly int _yAxis;

        public Robot(int xAxis = 5, int yAxis = 5)
        {
            _xAxis = xAxis;
            _yAxis = yAxis;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public string Facing { get; set; }

        public void Place(int x, int y, string direction)
        {
            if (IsValid(x, y, direction))
            {
                X = x;
                Y = y;
                Facing = direction;
            }
        }

        public void Move()
        {
            if (IsValid(X, Y, Facing))
            {
                if (Facing == Direction.NORTH && IsValid(X, Y + 1, Facing)) Y += 1;
                if (Facing == Direction.EAST && IsValid(X + 1, Y, Facing)) X += 1;
                if (Facing == Direction.SOUTH && IsValid(X, Y - 1, Facing)) Y -= 1;
                if (Facing == Direction.WEST && IsValid(X - 1, Y, Facing)) X -= 1;
            }

        }

        public void Left()
            => Facing = Facing.IsValid() && IsValid(X, Y, Facing) ? Facing.RotateLeft() : null;

        public void Right()
            => Facing = Facing.IsValid() && IsValid(X, Y, Facing) ? Facing.RotateRight() : null;

        public string Report()
            => IsValid(X, Y, Facing) ? $"{X},{Y},{Facing}" : null;

        private bool IsValid(int? x, int? y, string direction)
        {
            var xIsValid = x >= 0 && x < _xAxis;
            var yIsValid = y >= 0 && y < _yAxis;
            var response = xIsValid && yIsValid && direction.IsValid();
            return response;
        }

    }
}
