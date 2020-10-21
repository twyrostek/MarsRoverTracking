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
            if (!r.IsMatch(RoverId))
            {
                isValid = false;
            }
            if (RoverId.Count() > 10)
            {
                isValid = false;
            }
            return isValid;
        }
    }
}
