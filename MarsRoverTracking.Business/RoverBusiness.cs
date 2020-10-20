﻿using MarsRoverTracking.Business.Interfaces;
using MarsRoverTracking.Domain;
using MarsRoverTracking.Domain.RequestObjects;
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

        public Position GetRoverPosition(string RoverId)
        {
            Position position = new Position();

            Rover rover = roverRepository.SingleOrDefault(m => m.Id == RoverId);

            position.PosX = rover.PosX;
            position.PosY = rover.PosY;
            
            return position;
        }

        public UpdateRoverResponseObject UpdateRover(UpdateRoverRequestObject requestObject)
        {
            UpdateRoverResponseObject responseObject = new UpdateRoverResponseObject();
            Position startPoint = new Position();
            Position endPoint = new Position();
            Rover rover = roverRepository.SingleOrDefault(m => m.Id == requestObject.RoverId);

            if(rover != null)
            {
                responseObject.Message = "A rover with this RoverId was found. Its position has been updated";
                startPoint.Orientation = (Orientation)rover.Orientation;
                startPoint.PosX = rover.PosX;
                startPoint.PosY = rover.PosY;
                endPoint = ProcessMovementInstruction(startPoint, requestObject.MovementInstruction);
                rover.Orientation = (int)endPoint.Orientation;
                rover.PosX = endPoint.PosX;
                rover.PosY = endPoint.PosY;
                roverRepository.Update(rover);
                responseObject.CurrentPosition = endPoint.PositionResponseString;
            }
            else
            {
                rover = new Rover();
                responseObject.Message = "A rover with this RoverId does not exist, a new rover has been created with RoverId:" + requestObject.RoverId;
                rover.Id = requestObject.RoverId;
                endPoint = ProcessMovementInstruction(startPoint, requestObject.MovementInstruction);
                roverRepository.Insert(rover);
                responseObject.CurrentPosition = endPoint.PositionResponseString;
            }
            return responseObject;
        }

        private Position ProcessMovementInstruction(Position startPoint, string movementInstruction)
        {
            startPoint.PositionResponseString = "(1,1)";
            return startPoint;
        }
    }
}
