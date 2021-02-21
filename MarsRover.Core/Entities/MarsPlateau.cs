using MarsRover.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class MarsPlateau:IPlateau
    {

        public int Width { get; private set; }
        public int Height { get; private set; }

        public MarsPlateau(int width, int height) 
        {
            this.Width = width;
            this.Height = height;
        }

    }
}
