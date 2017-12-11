using AccountSystem.Data;
using AccountSystem.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSystem.Services.impl
{
    class PositionService : IPositionService
    {
        private IUnitOfWork _unitOfWork;

        public PositionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeletePosition(Position position)
        {
            _unitOfWork.PositionRepository.Delete(position.Id);
            _unitOfWork.Save();
        }

        public void SavePosition(Position position)
        {
            ValidatePosition(position);

            _unitOfWork.PositionRepository.Add(position);
            _unitOfWork.Save();
        }

        public List<Position> SearchPosition(string name)
        {
            return _unitOfWork.PositionRepository.SearchPosition(name).ToList();
        }

        public void UpdatePosition(Position position)
        {
            ValidatePosition(position);

            _unitOfWork.PositionRepository.Update(position);
            _unitOfWork.Save();
        }

        private void ValidatePosition(Position position)
        {
        }
    }
}
