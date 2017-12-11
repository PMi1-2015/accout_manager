using System.Collections.Generic;
using System.Linq;
using AccountSystem.Data.models;

namespace AccountSystem.Data.impl
{
    class PositionRepository : GenericRepository<Position>, IPositionRepository
    {
        public PositionRepository(AccountSystemContext context) : base(context) { }

        public IEnumerable<Position> SearchPosition(string name)
        {
            return _dbSet.Where(pr => pr.Name.ToLower().Contains(name.ToLower()));                  
        }
    }
}
