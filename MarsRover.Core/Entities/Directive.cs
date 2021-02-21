using MarsRover.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MarsRover
{
    public class Directive:IDirective
    {

        public Queue<Command> Commands { get; set; }

        public Directive(string commands)
       {

            Commands = new Queue<Command>();
            foreach (var item in commands )
            {
                Command command;
                Enum.TryParse<Command>(item.ToString(), out command);
                Commands.Enqueue(command);
            }
        }      
    }
}
