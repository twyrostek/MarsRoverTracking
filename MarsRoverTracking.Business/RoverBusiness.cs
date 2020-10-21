using MarsRoverTracking.Business.Interfaces;
using MarsRoverTracking.Domain;
using MarsRoverTracking.Domain.RequestObjects;
using MarsRoverTracking.Domain.ResponseObjects;
using MarsRoverTracking.Repository;
using MarsRoverTracking.Repository.Infrastructure;

namespace MarsRoverTracking.Business
{
    public class RoverBusiness : IRoverBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly RoverRepository roverRepository;

        public RoverBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            roverRepository = new RoverRepository(_unitOfWork);
        }

        public GetRoverPositionResponseObject GetRoverPosition(GetRoverPositionRequestObject requestObject)
        {
            GetRoverPositionResponseObject responseObject = new GetRoverPositionResponseObject();
            Position position = new Position();
            if (!requestObject.IsValid())
            {
                responseObject.Message = "The request body was invalid";
                return responseObject;
            }
            Rover rover = roverRepository.SingleOrDefault(m => m.Id == requestObject.RoverId);
            if (rover != null)
            {
                position.PosX = rover.PosX;
                position.PosY = rover.PosY;
                responseObject.CurrentPosition = position.getResponseString();
                responseObject.Message = "Your rover was found";
            }
            else
            {
                responseObject.Message = "The requested RoverId does not exist";
            }
            return responseObject;
        }

        public UpdateRoverResponseObject UpdateRover(UpdateRoverRequestObject requestObject)
        {

            UpdateRoverResponseObject responseObject = new UpdateRoverResponseObject();
            Position startPoint = new Position();
            Position endPoint = new Position();
            Rover rover = roverRepository.SingleOrDefault(m => m.Id == requestObject.RoverId);
            if (!requestObject.IsValid())
            {
                responseObject.Message = "The request body was invalid";
                return responseObject;
                
            }
            if (rover != null)
            {
                startPoint.Orientation = (Orientation)rover.Orientation;
                startPoint.PosX = rover.PosX;
                startPoint.PosY = rover.PosY;
                endPoint = ProcessMovementInstruction(startPoint, requestObject.MovementInstruction);
                rover.Orientation = (int)endPoint.Orientation;
                rover.PosX = endPoint.PosX;
                rover.PosY = endPoint.PosY;
                roverRepository.Update(rover);
                responseObject.CurrentPosition = endPoint.getResponseString();
                responseObject.Message = "A rover with this RoverId was found. Its position has been updated";
            }
            else
            {
                rover = new Rover();
                rover.Id = requestObject.RoverId;
                startPoint.Orientation = (Orientation)rover.Orientation;
                startPoint.PosX = rover.PosX;
                startPoint.PosY = rover.PosY;
                endPoint = ProcessMovementInstruction(startPoint, requestObject.MovementInstruction);
                rover.Orientation = (int)endPoint.Orientation;
                rover.PosX = endPoint.PosX;
                rover.PosY = endPoint.PosY;
                roverRepository.Insert(rover);
                responseObject.CurrentPosition = endPoint.getResponseString();
                responseObject.Message = "A rover with this RoverId was not found, a new rover has been created with RoverId:" + requestObject.RoverId;
            }
            return responseObject;
        }

        private Position ProcessMovementInstruction(Position startPoint, string movementInstruction)
        {
            foreach(char c in movementInstruction)
            {
                switch (c)
                {
                    case 'M':
                        startPoint.Move();
                        break;
                    case 'R':
                        startPoint.TurnRight();
                        break;
                    case 'L':
                        startPoint.TurnLeft();
                        break;

                }
            }
            return startPoint;
        }
    }
}
