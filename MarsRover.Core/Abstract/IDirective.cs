using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Abstract
{
    public interface IDirective
    {
        public Queue<Command> Commands { get; set; }
    }

    public enum Command
    {
        M = 'M',
        L = 'L',
        R = 'R'
    }
}
