using MarsRoverTracking.Domain;
using MarsRoverTracking.Domain.RequestObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverTracking.Business.Interfaces
{
    public interface IRoverBusiness
    {
        Position GetRoverPosition(string id);
        UpdateRoverResponseObject UpdateRover(UpdateRoverRequestObject requestObject);
    }
}
