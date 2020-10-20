using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverTracking.Domain
{

    public class RoverDomainModel
    {
        //public string Id { get; set; } = "";
        //public PositionDomainModel Position { get; set; } = new PositionDomainModel();
        public string Id { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public Orientation Orientation { get; set; } = 0;
    }
}
