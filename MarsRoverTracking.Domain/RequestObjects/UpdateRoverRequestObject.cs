﻿using System;
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
            if (!r.IsMatch(RoverId))
            {
                isValid = false;
            }
            if(RoverId.Count() > 10)
            {
                isValid = false;
            }
            Regex s = new Regex("^[MRL]*$");
            if (!s.IsMatch(MovementInstruction))
            {
                isValid = false;
            }
            if(MovementInstruction.Count() > 100)
            {
                isValid = false;
            }
            return isValid;
        }
    }
}
