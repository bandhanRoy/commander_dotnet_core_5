using System.Collections.Generic;
using Commander.Entities;
using Commander.Interfaces;
using Commander.Models;

namespace Commander.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepository;
        private readonly IJwtHelper _jwtHelper;

        public UserService(IUserRepo userRepo, IJwtHelper jwtHelper)
        {
            this._userRepository = userRepo;
            this._jwtHelper = jwtHelper;
        }

        public ReturnResult<AuthResponse> Authenticate(AuthRequest authReq)
        {
            var user = _userRepository.LoginUser(authReq);
            // TODO: Handle success = false
            if (!user.success) return null;
            return new ReturnResult<AuthResponse> { success = true, data = new AuthResponse(user.data, _jwtHelper.generateJwtToken(user.data)) };
        }

        public ReturnResult<IEnumerable<User>> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public ReturnResult<User> GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }
    }
}