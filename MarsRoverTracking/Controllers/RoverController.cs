using MarsRoverTracking.Business;
using MarsRoverTracking.Business.Interfaces;
using MarsRoverTracking.Domain;
using MarsRoverTracking.Domain.RequestObjects;
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

            return Ok(business.GetRoverPosition(RoverId));
        }

        // POST
        public IHttpActionResult Post([FromBody] UpdateRoverRequestObject requestObject)
        {
            UpdateRoverResponseObject responseObject = business.UpdateRover(requestObject);
            return Ok(responseObject);

        }
    }
}