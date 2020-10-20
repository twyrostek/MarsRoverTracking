using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverTracking.Domain.RequestObjects
{
    public class UpdateRoverRequestObject
    {
        public string RoverId { get; set; }
        public string MovementInstruction { get; set; }
    }
}
