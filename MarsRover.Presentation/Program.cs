using MarsRover.Busines;
using System;

namespace MarsRoverApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Console.WriteLine("Plato boyutunu giriniz:");

                var PlateauSize = Console.ReadLine();

                PlateauGenerator plateauGenerator = new PlateauGenerator(PlateauSize);

                RoverController roverController = new RoverController();

                while (true) 
                {

                    Console.WriteLine("Rover posizyonunu ve iniş yönünü belirtiniz");
                    string landedPosition = Console.ReadLine();
                    roverController.LandNewRover(landedPosition, plateauGenerator.Plateau);

                    Console.WriteLine("Komut dizisini belirtiniz");
                    string commands = Console.ReadLine();
                    roverController.ExploreMars(commands);

                   // roverController.ReturnToBase();

                    Console.WriteLine("Yeni bir rover indirmek istiyor musunuz? (E/H)");
                    var addRoverInput = Console.ReadLine();

                    if (addRoverInput.Equals("H", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                }


                foreach (var item in roverController.Rovers)
                {
                    Console.WriteLine(item.Guid + " : " + item.Coordinate.x + " , " + item.Coordinate.y + " , " + item.Direction.Name);
                }


                Console.Write("çıkış için enter tuşuna basınız");
                Console.ReadLine();



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }

}









