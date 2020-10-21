using MarsRoverTracking.Business;
using MarsRoverTracking.Business.Interfaces;
using MarsRoverTracking.Domain;
using MarsRoverTracking.Domain.RequestObjects;
using MarsRoverTracking.Domain.ResponseObjects;
using System.Web.Http;
using System.Web.Mvc;

namespace MarsRoverTracking.Controllers
{

    public class RoverController : ApiController
    {
        private readonly IRoverBusiness business;

        public RoverController(IRoverBusiness _business)
        {
            business = _business;
        }

        // GET 
        public IHttpActionResult Get(string RoverId)
        {
            GetRoverPositionRequestObject requestObject = new GetRoverPositionRequestObject();
            requestObject.RoverId = RoverId;
            GetRoverPositionResponseObject responseObject = business.GetRoverPosition(requestObject);
            return Ok(responseObject);
        }

        // POST
        public IHttpActionResult Post([FromBody] UpdateRoverRequestObject requestObject)
        {
            UpdateRoverResponseObject responseObject = business.UpdateRover(requestObject);
            return Ok(responseObject);

        }
    }
}