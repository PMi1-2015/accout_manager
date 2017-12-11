using AccountSystem.Data.models;
using System;
using System.Collections.Generic;

namespace AccountSystem.Services
{
    public interface IPositionService
    {
        void SavePosition(Position position);

        void UpdatePosition(Position position);

        void DeletePosition(Position position);

        List<Position> SearchPosition(String name);
    }
}
