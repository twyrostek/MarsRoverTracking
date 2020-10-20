using MarsRoverTracking.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverTracking.Repository
{
    public class RoverRepository : BaseRepository<Rover>
    {
        public RoverRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
