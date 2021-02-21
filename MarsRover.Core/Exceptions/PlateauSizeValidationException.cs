using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.Exceptions
{
    public class PlateauSizeValidationException:Exception
    {
        public PlateauSizeValidationException(string mesage) : base(mesage)
        {

        }
    }
}
