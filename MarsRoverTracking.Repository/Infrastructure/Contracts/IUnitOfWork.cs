using System;
using System.Data.Entity;

namespace MarsRoverTracking.Repository.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Return the database reference for this UOW
        /// </summary>
        DbContext Db { get; }


    }
}