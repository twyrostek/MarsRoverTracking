using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverTracking.Domain.ResponseObjects
{
    public class GetRoverPositionResponseObject
    {
        public string Message { get; set; }
        public string CurrentPosition { get; set; }
    }
}
