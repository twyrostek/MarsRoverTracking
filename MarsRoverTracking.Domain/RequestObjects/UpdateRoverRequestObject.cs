using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarsRoverTracking.Domain.RequestObjects
{
    public class UpdateRoverRequestObject
    {
        public string RoverId { get; set; }
        public string MovementInstruction { get; set; }

        public bool IsValid()
        {
            bool isValid = true;
            Regex r = new Regex("^[a-zA-Z0-9]*$");
            if (RoverId == null || RoverId.Count() > 10 || RoverId.Count() < 1 || !r.IsMatch(RoverId))
            {
                isValid = false;
            }
            Regex s = new Regex("^[MRL]*$");
            if (MovementInstruction == null || MovementInstruction.Count() > 10 || MovementInstruction.Count() < 1 || !r.IsMatch(MovementInstruction))
            {
                isValid = false;
            }
            return isValid;
        }
    }
}
