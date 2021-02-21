using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.Exceptions
{
   public class RoverNotFoundException:Exception
    {
        public RoverNotFoundException(string mesage) : base(mesage)
        {

        }
    }
}
