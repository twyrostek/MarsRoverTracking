using System;
using System.Collections.Generic;
using System.Linq;
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
        public string PositionResponseString { get; set; }
        public Orientation Orientation { get; set; }
    }
}
