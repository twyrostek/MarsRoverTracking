using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarsRoverTracking.Domain.RequestObjects
{
    public class GetRoverPositionRequestObject
    {
        public string RoverId { get; set; }
        public bool IsValid()
        {
            bool isValid = true;
            Regex r = new Regex("^[a-zA-Z0-9]*$");
            if (RoverId == null || RoverId.Count() > 10 || !r.IsMatch(RoverId))
            {
                isValid = false;
            }
            return isValid;
        }
    }
}
