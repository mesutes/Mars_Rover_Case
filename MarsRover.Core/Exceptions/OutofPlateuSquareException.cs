using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Exceptions
{
    public class OutofPlateuSquareException : Exception
    {
        public OutofPlateuSquareException(string mesage) : base(mesage)
        {

        }
    }

}
