using MarsRoverTracking.Business;
using MarsRoverTracking.Business.Interfaces;
using MarsRoverTracking.Domain;
using MarsRoverTracking.Domain.RequestObjects;
using MarsRoverTracking.Domain.ResponseObjects;
using System;
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
            GetRoverPositionResponseObject responseObject = new GetRoverPositionResponseObject();
            try
            {
                GetRoverPositionRequestObject requestObject = new GetRoverPositionRequestObject();
                requestObject.RoverId = RoverId;
                responseObject = business.GetRoverPosition(requestObject);
            }
            catch (Exception e)
            {
                responseObject.Message = "Something unexpected happened: " + e.Message;
            }
            return Ok(responseObject);
        }

        // POST
        public IHttpActionResult Post([FromBody] UpdateRoverRequestObject requestObject)
        {
            UpdateRoverResponseObject responseObject = new UpdateRoverResponseObject();
            try
            {
                responseObject = business.UpdateRover(requestObject);
            }
            catch (Exception e) 
            {
                responseObject.Message = "Something unexpected happened: " + e.Message;
            }
            return Ok(responseObject);

        }
    }
}