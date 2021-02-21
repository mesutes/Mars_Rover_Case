using MarsRover;
using MarsRover.Busines;
using MarsRover.Core.Exceptions;
using System;
using Xunit;
namespace MarsRoverTest
{
    public class RoverTest
    {

        [Fact]
        public void ProductMarsRover()
        {
            Rover testRover = new Rover();
            Assert.NotNull(testRover);
        }

        [Fact]
        public void PlateauTest()
        {
            MarsPlateau marsPlateau = new MarsPlateau(4, 5);
            Assert.NotNull(marsPlateau);
            Assert.Equal("4", marsPlateau.Width.ToString());
            Assert.Equal("5", marsPlateau.Height.ToString());
        }

        [Fact]
        public void RoverLandingAndExplorationTest()
        {
            Rover testRover = new Rover();
            testRover.Land(new Coordinate { x = 3, y = 5 }, new MarsPlateau(5, 5), Directions.East);


            Assert.Equal(3, testRover.Coordinate.x);
            Assert.Equal(5, testRover.Coordinate.y);
            Assert.Equal('E', testRover.Direction.Key);

            var result = testRover.Explore(new Directive("MM"));

            Assert.True(result.IsSucceeded);

            testRover.GoBackToStartedPosition();

            Assert.Equal(3, testRover.Coordinate.x);
            Assert.Equal(5, testRover.Coordinate.y);
            Assert.Equal(Directions.East, testRover.Direction);

        }

        [Fact]
        public void IsPointHasValidFormatPlateau_CorrectFormatGiven_ReturnsTrue()
        {
            PlateauGenerator generator =  new PlateauGenerator("4, 5");
            Assert.NotNull(generator.Plateau);
         }

        [Fact]

        public void IsPointHasValidFormatPlateau_WrongFormatGiven_ReturnsFalse()
        {

            PlateauGenerator generator;

            Assert.Throws<PlateauSizeValidationException>(() => generator = new PlateauGenerator("0 0"));

        }

        [Fact]
        public void IsPointHasValidFormatPlateau_WrongFormatGiven_ReturnsFalse_2()
        {
            PlateauGenerator generator;

            Assert.Throws<PlateauSizeValidationException>(() => generator = new PlateauGenerator("0 a0"));
        }
    }

}
