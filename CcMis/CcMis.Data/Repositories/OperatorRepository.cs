using System;
using CcMis.Models;
using CcMis.Data.Interfaces;

namespace CcMis.Data.Repositories
{
    public class OperatorRepository : IOperatorRepository
    {
        private newhotel_xyjdContext _dbContext = null;

        public OperatorRepository(newhotel_xyjdContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
