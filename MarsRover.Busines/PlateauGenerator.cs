using MarsRover.Abstract;
using MarsRover.Core.Exceptions;
using MarsRover.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MarsRover.Busines
{
    public class PlateauGenerator
    {

        public IPlateau Plateau { get; private set; }


        public PlateauGenerator(string PlateauSize)
        {

            Regex regex = new Regex(@"(?<width>^[1-65535]+) (?<height>[4-65535]+)$");

            Match match = regex.Match(PlateauSize);

            if (match.Success)
            {
                ushort width;
                ushort height;

                if (!ushort.TryParse(match.Groups["width"].ToString(), out width))
                {
                    throw new PlateauSizeValidationException("Geçerli olmayan genişlik bilgisi");
                }
                if (!ushort.TryParse(match.Groups["height"].ToString(), out height))
                {
                    throw new PlateauSizeValidationException("Geçerli olmayan yükseklik bilgisi");
                }

                Plateau = new MarsPlateau(width, height);
            }
            else
            {
                throw new PlateauSizeValidationException("Tanımlanamayan ölçü girişi");
            }

        }
    }
}
