using MarsRover.Abstract;
using MarsRover.Entities;
using MarsRover.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover
{
    public class Rover : IMoveAble
    {

        public Coordinate Coordinate { get; private set; }
        public IPlateau Plateau { get; private set; }
        public Direction Direction { get; private set; }
        public Guid Guid { get; private set; } = Guid.NewGuid();
        public bool IsLanded { get; private set; }
        private Stack<Command> CommandHistory { get; set; } = new Stack<Command>();
        public Direction LandedDirection { get; private set; }
        public Coordinate LandedCoordinate { get; private set; }

        public Result Land(Coordinate coordinate, IPlateau plateau, Direction direction)
        {
            var result = new Result();

            if (plateau == null)
            {
                result.IsSucceeded = false;
                result.Message = "Plato bilgisi boş geçilemez";
                return result;
            }

            if (IsLanded)
            {
                result.IsSucceeded = false;
                result.Message = "İniş daha önce zaten gerçekleştirildi.";
                return result;
            }


            Plateau = plateau;
            IsLanded = true;
            Direction = direction;
            Coordinate = coordinate;
            LandedCoordinate = coordinate;
            LandedDirection = direction;
            result.IsSucceeded = true;

            return result;

        }

        public Result Explore(IDirective directive)
        {
            var result = new Result();
            int count = 0;

            if (!IsLanded)
            {
                result.IsSucceeded = false;
                result.Message = "Öncelikle iniş yapmalısınız";
                return result;
            }

            while (directive.Commands.Count > 0)
            {

                Command cmd = directive.Commands.Dequeue();
                count++;

                while (directive.Commands.Any() && cmd == directive.Commands.Peek())
                {
                    directive.Commands.Dequeue();
                    count++;
                }

                switch (cmd)
                {
                    case Command.L:
                        RotateLeft(count);
                        break;
                    case Command.R:
                        RotateRight(count);
                        break;
                    case Command.M:
                        result = Forward(count);
                        if (!result.IsSucceeded)
                        {
                            return result;
                        }
                        break;
                }

                while (count > 0)
                {
                    CommandHistory.Push(cmd);
                    count--;
                }
            }


            result.IsSucceeded = true;
            return result;

        }


        public Result Forward(int count)
        {
            var result = new Result();

            if (!IsLanded)
            {
                result.Message = "İniş yapılmadı henüz";
                result.IsSucceeded = false;
                return result;
            }

            var coordinate = new Coordinate() { x = (Coordinate.x + Direction.AxisX * count), y = (Coordinate.y + Direction.AxisY * count) };

            if (!ValidateIsCurrentLocationSuitable(coordinate))
            {
                result.Message = "Başka boyuta geçtin";
                result.IsSucceeded = false;
                return result;
            }

            //roverlerın rotaları kesişiyorsa

            Coordinate = coordinate;
            result.IsSucceeded = true;
            return result;


        }

        public void RotateLeft(int count)
        {
            Rotate(-90 * count);
        }

        public void RotateRight(int count)
        {
            Rotate(90 * count);
        }

        public void Rotate(Direction direction)
        {
            if (direction == Direction)
            {
                return;
            }

            int rotationCount = (direction.Angle - Direction.Angle) / 90;


            if (rotationCount > 0)
            {
                RotateRight(Math.Abs(rotationCount));
            }
            else if (rotationCount < 0)
            {
                RotateLeft(Math.Abs(rotationCount));
            }
        }
        private Result Rotate(int angle)
        {
            var result = new Result();

            if (!IsLanded)
            {
                result.Message = "İniş yapılmadı henüz";
                result.IsSucceeded = false;
                return result;
            }

            var direction = Directions.DirectionList.FirstOrDefault(x => x.Angle == ((360 + (Direction.Angle + angle)) % 360));

            if (direction == null)
            {
                result.Message = "geçersiz angle";
                result.IsSucceeded = false;
                return result;
            }

            Direction = direction;

            result.IsSucceeded = true;
            return result;

        }

        private bool ValidateIsCurrentLocationSuitable(Coordinate coordinate)
        {
            return coordinate.x <= Plateau.Width && coordinate.y <= Plateau.Height && coordinate.x >= 0 && coordinate.y >= 0;
        }

        public Result GoBackToStartedPosition()
        {

            var result = new Result();

            int xDistance = LandedCoordinate.x - Coordinate.x;
            int yDistance = LandedCoordinate.y - Coordinate.y;


            if (xDistance != 0)
            {

                Direction exceptedDirection;
                if (xDistance < 0)
                {
                    exceptedDirection = Directions.DirectionList.Find(x => x.AxisX == -1 && x.AxisY == 0);
                }
                else
                {
                    exceptedDirection = Directions.DirectionList.Find(x => x.AxisX == 1 && x.AxisY == 0);
                }

                Rotate(exceptedDirection);

                result = Forward(Math.Abs(xDistance));

                if (!result.IsSucceeded)
                {
                    return result;
                }
            }

            if (yDistance != 0)
            {

                Direction exceptedDirection;
                if (yDistance < 0)
                {
                    exceptedDirection = Directions.DirectionList.Find(x => x.AxisY == -1 && x.AxisX == 0);
                }
                else
                {
                    exceptedDirection = Directions.DirectionList.Find(x => x.AxisY == 1 && x.AxisX == 0);
                }

                Rotate(exceptedDirection);

                result = Forward(Math.Abs(yDistance));

                if (!result.IsSucceeded)
                {
                    return result;
                }
            }

            Rotate(LandedDirection);

            result.IsSucceeded = true;
            return result;

        }

    }
}
