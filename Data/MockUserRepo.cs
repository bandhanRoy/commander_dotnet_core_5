using System.Collections.Generic;
using Commander.Entities;

namespace Commander.Data
{
    public class MockUserRepo : IUserRepo
    {
        public IEnumerable<User> GetAllUsers()
        {
            throw new System.NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}