using System.Collections.Generic;
using System.Linq;
using Commander.Entities;
using Commander.Interfaces;
using Commander.Models;

namespace Commander.Data
{
    public class MockUserRepo : IUserRepo
    {
        private List<User> _users = new List<User> {
                new User{Id=1, FirstName="Bandhan", LastName="Roy",  Username="bandhanRoy", Password="123456"}
            };
        public ReturnResult<IEnumerable<User>> GetAllUsers()
        {
            return new ReturnResult<IEnumerable<User>> { success = true, data = _users };
        }

        public ReturnResult<User> GetUserById(int id)
        {
            ReturnResult<User> result = new ReturnResult<User> { success = false, data = _users.FirstOrDefault(x => x.Id == id) };
            if (result.data != null)
            {
                result.success = true;
            }
            return result;
        }

        public ReturnResult<User> LoginUser(AuthRequest authReq)
        {
            ReturnResult<User> result = new ReturnResult<User> { success = false, data = _users.FirstOrDefault(user => user.Username == authReq.Username && user.Password == authReq.Password) };
            if (result.data != null)
            {
                result.success = true;
            }
            return result;
        }
    }
}