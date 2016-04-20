using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverLibrary
{
    public interface IPosition
    {
        int X { get; set; }
        int Y { get; set; }
        string ToString();
    }

    public class Position : IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", X, Y);
        }
    }

    public interface IPlateau
    {
        Position PlateauPosition { get; }
    }

    public class Plateau : IPlateau
    {
        public Position PlateauPosition { get; private set; }

        public Plateau(Position position)
        {
            PlateauPosition = position;
        }
    }

    public enum RoverDirection
    {
        [Utils.StringValueAttribute("N")]
        N = 1,
        [Utils.StringValueAttribute("E")]
        E = 2,
        [Utils.StringValueAttribute("S")]
        S = 3,
        [Utils.StringValueAttribute("W")]
        W = 4
    }

    public interface IRover
    {
        IPosition RoverPosition { get; set; }
        RoverDirection DirectionOfRover { get; set; }
        IPlateau MarsPlateau { get; set; }
        bool IsRoverInsideBoundaries { get; }
        string Process(string commandsToFollow);
        string PrintRoverPosition();

    }

    public class Rover : IRover
    {
        public IPosition RoverPosition { get; set; }
        public RoverDirection DirectionOfRover { get; set; }
        public IPlateau MarsPlateau { get; set; }


        public Rover(IPosition roverPosition, RoverDirection roverDirection, IPlateau marsPlateau)
        {
            RoverPosition = roverPosition;
            DirectionOfRover = roverDirection;
            MarsPlateau = marsPlateau;
        }

        public string Process(string commands)
        {
            StringBuilder retval = new StringBuilder();
            retval.AppendLine("Movement of Rover..");
            foreach (var command in commands)
            {
                switch (command)
                {
                    case ('L'):
                        TurnLeft();
                        retval.AppendLine("Rover has turned Left");
                        break;
                    case ('R'):
                        TurnRight();
                        retval.AppendLine("Rover has turned Right");
                        break;
                    case ('M'):
                        Move();
                        retval.AppendLine("Rover has moved forward 1 unit");
                        break;
                    default:
                        throw new ArgumentException(string.Format("Invalid value: {0}", command));
                }
            }
            return retval.ToString();
        }

        public bool IsRoverInsideBoundaries
        {
            get
            {
                bool isInsideBoundaries = false;
                if (RoverPosition.X > MarsPlateau.PlateauPosition.X || RoverPosition.Y > MarsPlateau.PlateauPosition.Y)
                    isInsideBoundaries = true;
                return isInsideBoundaries;
            }
        }

        private void TurnLeft()
        {
            DirectionOfRover = (DirectionOfRover - 1) < RoverDirection.N ? RoverDirection.W : DirectionOfRover - 1;
        }

        private void TurnRight()
        {
            DirectionOfRover = (DirectionOfRover + 1) > RoverDirection.W ? RoverDirection.N : DirectionOfRover + 1;
        }

        private void Move()
        {
            if (DirectionOfRover == RoverDirection.N)
            {
                RoverPosition.Y++;
            }
            else if (DirectionOfRover == RoverDirection.E)
            {
                RoverPosition.X++;
            }
            else if (DirectionOfRover == RoverDirection.S)
            {
                RoverPosition.Y--;
            }
            else if (DirectionOfRover == RoverDirection.W)
            {
                RoverPosition.X--;
            }
        }

        public string PrintRoverPosition()
        {
            string printedRoverPosition = string.Format("{0} {1}", RoverPosition.X, RoverPosition.Y);
            if (IsRoverInsideBoundaries)
                printedRoverPosition =
                    string.Format("Rover outside the plateau, Rover position: {0} , plateau limit {1}",
                                  printedRoverPosition, MarsPlateau.PlateauPosition.ToString());

            return printedRoverPosition;


        }

    }
}
