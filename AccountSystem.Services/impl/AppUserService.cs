using AccountSystem.Data;
using AccountSystem.Data.models;
using DevOne.Security.Cryptography.BCrypt;

namespace AccountSystem.Services.impl
{
    class AppUserService: IAppUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddUser(string username, string password)
        {
            if (AuthenticateUser(username, password))
            {
                throw new System.Exception("Can't add existing user");
            }

            AppUser appUser = new AppUser
            {
                UserName = username,
                PasswordHash = BCryptHelper.HashPassword(password, BCryptHelper.GenerateSalt())
            };

            _unitOfWork.AppUserRepository.Add(appUser);
            _unitOfWork.Save();
        }

        public bool AuthenticateUser(string username, string password)
        {
            AppUser user = _unitOfWork.AppUserRepository.FindByUserName(username);

            if (user == null)
            {
                return false;
            }

            return BCryptHelper.CheckPassword(password, user.PasswordHash);
        }
    }
}
