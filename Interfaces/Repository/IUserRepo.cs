using System.Collections.Generic;
using Commander.Entities;
using Commander.Models;

namespace Commander.Interfaces
{
    public interface IUserRepo
    {
        ReturnResult<IEnumerable<User>> GetAllUsers();
        ReturnResult<User> GetUserById(int id);

        ReturnResult<User> LoginUser(AuthRequest authReq);
    }
}