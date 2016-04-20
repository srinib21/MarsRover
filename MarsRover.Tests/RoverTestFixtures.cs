using System;
using NUnit.Framework;
using Moq;
using RoverLibrary;

namespace MarsRover.Tests
{
    [TestFixture]
    public class RoverTestFixtures
    {
        private Mock<IPosition> _position = null;
        private Mock<IPlateau> _plateau = null;
        private IRover _rover = null;

        [SetUp]
        private void SetupRover()
        {
            _plateau = new Mock<IPlateau>();
            _position = new Mock<IPosition>();
            _position.SetupProperty(x => x.X, 1);
            _position.SetupProperty(x => x.Y, 2);
            _plateau.Setup(x => x.PlateauPosition).Returns(new Position(5, 5));
            _rover = new Rover(_position.Object, RoverDirection.N, _plateau.Object);
        }

        [Test]
        public void Move_Rover_Outside_Plateau_Boundaries()
        {
            //Arrange  (Setup the rover)
            SetupRover();

            //Act (Process command)
            _rover.Process("MMRRMMRRRMRRMMMMRRRM");

            //Assert
            Console.WriteLine(_rover.PrintRoverPosition());
            Assert.IsTrue(_rover.PrintRoverPosition().Contains("Rover outside the plateau"));
        }

        [Test]
        public void Move_RoverOne_Check_Output()
        {
            //Arrange (Setuup the rover)
            SetupRover();

            //Act (Process command)
            _rover.Process("LMLMLMLMM");

            //Assert
            Console.WriteLine(_rover.PrintRoverPosition());
            Assert.AreEqual(_rover.PrintRoverPosition(), "1 3 N");
        }
    }
}
