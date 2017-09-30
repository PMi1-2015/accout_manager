using AccountSystem.Data.models;

namespace AccountSystem.Data.impl
{
    class PositionRepository : GenericRepository<Position>, IPositionRepository
    {
        public PositionRepository(AccountSystemContext context) : base(context) { }
    }
}
