using System.Collections.Generic;
using Commander.Entities;
using Commander.Models;

namespace Commander.Interfaces
{
    public interface IUserService
    {

        ReturnResult<IEnumerable<User>> GetAllUsers();
        ReturnResult<User> GetUserById(int id);
        ReturnResult<AuthResponse> Authenticate(AuthRequest authReq);
    }
}