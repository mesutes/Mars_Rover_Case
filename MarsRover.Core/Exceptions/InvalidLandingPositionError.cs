using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.Exceptions
{
   public class InvalidLandingPositionError:Exception
    {
        public InvalidLandingPositionError(string mesage) : base(mesage)
        {

        }

    }
}
