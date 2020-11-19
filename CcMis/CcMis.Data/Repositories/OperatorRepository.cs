using System;
using CcMis.Models;
using CcMis.Data.Interfaces;

namespace CcMis.Data.Repositories
{
    public class OperatorRepository : IOperatorRepository
    {
        private HotelContext _dbContext = null;

        public OperatorRepository(HotelContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
