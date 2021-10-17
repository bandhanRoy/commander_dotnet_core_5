using System.Collections.Generic;
using Commander.Entities;
using Commander.Interfaces;
using Commander.Models;

namespace Commander.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepoSitory;
        private readonly IJwtHelper _jwtHelper;

        public UserService(IUserRepo userRepo, IJwtHelper jwtHelper)
        {
            this._userRepoSitory = userRepo;
            this._jwtHelper = jwtHelper;
        }

        public ReturnResult<AuthResponse> Authenticate(AuthRequest authReq)
        {
            var user = _userRepoSitory.LoginUser(authReq);
            // TODO: Handle success = false
            if (!user.success) return null;
            return new ReturnResult<AuthResponse> { success = true, data = new AuthResponse(user.data, _jwtHelper.generateJwtToken(user.data)) };
        }

        public ReturnResult<IEnumerable<User>> GetAllUsers()
        {
            throw new System.NotImplementedException();
        }

        public ReturnResult<User> GetUserById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}