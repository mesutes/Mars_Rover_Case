using MarsRover.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using MarsRover.Core.Exceptions;
using MarsRover.Exceptions;

namespace MarsRover.Busines
{
    public class RoverController
    {

        public List<Rover> Rovers;


        public RoverController()
        {
            Rovers = new List<Rover>();
        }

        public void LandNewRover(string LandingPosition, IPlateau plateau)
        {

            if (string.IsNullOrEmpty(LandingPosition))
            {
                throw new InvalidLandingPositionError("Geçerli olmayan pozisyon bilgisi");
            }

            Regex regex = new Regex(@"^(?i)(?<x>[1-65535]+) (?<y>[1-65535])+ (?<direction>[wnes])$");
            Match match = regex.Match(LandingPosition);

            if (match.Success)
            {

                ushort x;
                ushort y;
                Direction direction;

                if (!ushort.TryParse(match.Groups["x"].ToString(), out x))
                {
                    throw new InvalidLandingPositionError("Geçerli olmayan x pozisyon bilgisi");
                }
                if (!ushort.TryParse(match.Groups["y"].ToString(), out y))
                {
                    throw new InvalidLandingPositionError("Geçerli olmayan y pozisyon bilgisi");
                }

                direction = Directions.DirectionList.Find(x => x.Key == Convert.ToChar(match.Groups["direction"].Value.ToUpper()));

                Coordinate coordinate = new Coordinate() { x = x, y = y };

                Rover rover = new Rover();
                Rovers.Add(rover);

                rover.Land(coordinate, plateau, direction);


            }
            else
            {
                throw new InvalidLandingPositionError("Geçerli formatta olmayan pozisyon bilgisi");
            }


        }


        public void ExploreMars(string commands)
        {

            if (Rovers.Count == 0)
            {
                throw new RoverNotFoundException("Keşif görevi için herhangi bir rover bulunamadı");
            }

            Rover rover = Rovers[Rovers.Count - 1];
            IDirective directive = new Directive(commands.ToUpper());
            var result = rover.Explore(directive);

            if (!result.IsSucceeded)
            {
                throw new OutofPlateuSquareException(result.Message);
            }

        }

        public void ReturnToBase() 
        {
            if (Rovers.Count == 0)
            {
                throw new RoverNotFoundException("Keşif görevi için herhangi bir rover bulunamadı");
            }

            Rover rover = Rovers[Rovers.Count - 1];

            rover.GoBackToStartedPosition();
        }


    }
}
