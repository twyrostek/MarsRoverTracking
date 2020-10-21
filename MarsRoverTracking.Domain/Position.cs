using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverTracking.Domain
{
    public enum Orientation
    {
        North = 0,
        East = 1,
        South = 2,
        West = 3
    };
    public class Position
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public Orientation Orientation { get; set; }

        public string getResponseString()
        {
            string responseString = "(" + PosX.ToString() + "," + PosY.ToString() + ")";
            return responseString;
        }

        public void Move()
        {
            switch (Orientation)
            {
                case Orientation.North:
                    PosY++;
                    break;
                case Orientation.East:
                    PosX++;
                    break;
                case Orientation.South:
                    PosY--;
                    break;
                case Orientation.West:
                    PosX--;
                    break;
            }
        }

        public void TurnRight()
        {
            switch (Orientation)
            {
                case Orientation.North:
                    Orientation = Orientation.East;
                    break;
                case Orientation.East:
                    Orientation = Orientation.South;
                    break;
                case Orientation.South:
                    Orientation = Orientation.West;
                    break;
                case Orientation.West:
                    Orientation = Orientation.North;
                    break;
            }
        }

        public void TurnLeft()
        {
            switch (Orientation)
            {
                case Orientation.North:
                    Orientation = Orientation.West;
                    break;
                case Orientation.East:
                    Orientation = Orientation.North;
                    break;
                case Orientation.South:
                    Orientation = Orientation.East;
                    break;
                case Orientation.West:
                    Orientation = Orientation.South;
                    break;
            }
        }
    }
}
