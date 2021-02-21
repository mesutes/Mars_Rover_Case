using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public static class Directions
    {
        public static Direction South = new Direction() { Key = 'S', Name = "South", Angle = 270, AxisX = 0, AxisY = -1 };
        public static Direction West = new Direction() { Key = 'W', Name = "West", Angle = 0, AxisX = -1, AxisY = 0 };
        public static Direction North = new Direction() { Key = 'N', Name = "North", Angle = 90, AxisX = 0, AxisY = 1 };
        public static Direction East = new Direction() { Key = 'E', Name = "East", Angle = 180, AxisX = 1, AxisY = 0 };
        

        public static List<Direction> DirectionList = new List<Direction>(4) { West, North, East, South };
    }
}
