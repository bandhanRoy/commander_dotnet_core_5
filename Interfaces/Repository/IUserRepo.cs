using System.Collections.Generic;
using Commander.Entities;

namespace Commander.Data
{
    public interface IUserRepo
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
    }
}