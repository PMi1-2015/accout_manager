using AccountSystem.Data.models;
using System.Collections.Generic;

namespace AccountSystem.Data
{
    public interface IPositionRepository: IRepository<Position>
    {
        IEnumerable<Position> SearchPosition(string name);
    }
}
