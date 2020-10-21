using MarsRoverTracking.Domain;
using MarsRoverTracking.Domain.RequestObjects;
using MarsRoverTracking.Domain.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverTracking.Business.Interfaces
{
    public interface IRoverBusiness
    {
        GetRoverPositionResponseObject GetRoverPosition(GetRoverPositionRequestObject requestObject);
        UpdateRoverResponseObject UpdateRover(UpdateRoverRequestObject requestObject);
    }
}
