using MarsRover.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Abstract
{

    // Extend edilebilirliği sağlamak için farklı tipte uzay araçlarının hareketlerini modelleyen bir şablon
    public interface IMoveAble
    {

        public bool IsLanded { get; }

        public Direction Direction {get;}
        public Coordinate Coordinate { get;}
        public IPlateau Plateau { get; }

        void RotateLeft( int count);
        void RotateRight(int count); 
        Result Forward(int count);   

        Result Land(Coordinate coordinate, IPlateau plateau, Direction direction);
        Result GoBackToStartedPosition();



    }
}
