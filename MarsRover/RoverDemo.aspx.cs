using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RoverLibrary;

namespace MarsRover
{
    public partial class RoverDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int X = 0;
                int Y = 0;
                string direction = "N";
                RoverDirection rd = RoverDirection.N;
                Position roverPosition = new Position(X, Y);
                Plateau marsPlateau = new Plateau( new Position(X,Y));
                int platSizeW = 1;
                int platSizeL = 1;
                if (Request["txtPlateauDimension"] != null)
                {
                    if (Request["txtPlateauDimension"] != "")
                    {
                        string initSize = Request["txtPlateauDimension"];
                        string[] sizeArray = initSize.Split(' ');
                        if (sizeArray.Length == 2)
                        {
                            int.TryParse(sizeArray[0], out platSizeW);
                            int.TryParse(sizeArray[1], out platSizeL);
                            marsPlateau.PlateauPosition.X = platSizeW;
                            marsPlateau.PlateauPosition.Y = platSizeL;
                        }
                    }
                }
                if (Request["txtInitRover"] != null)
                {
                    if (Request["txtInitRover"] != "")
                    {
                        string initPos = Request["txtInitRover"];
                        string[] posArray = initPos.Split(' ');
                        if (posArray.Length == 3)
                        {
                            int.TryParse(posArray[0], out X);
                            int.TryParse(posArray[1], out Y);
                            roverPosition.X = X;
                            roverPosition.Y = Y;
                            switch (posArray[2])
                            {
                                case "N":
                                    rd = RoverDirection.N;
                                    break;
                                case "E":
                                    rd = RoverDirection.E;
                                    break;
                                case "S":
                                    rd = RoverDirection.S;
                                    break;
                                case "W":
                                    rd = RoverDirection.W;
                                    break;
                            }
                        }
                    }
                }
                Rover rover = new Rover(roverPosition, rd, marsPlateau);
                string retval = rover.Process(Request["txtCommands"]);
                Response.Write(retval);
            }

        }
    }
}