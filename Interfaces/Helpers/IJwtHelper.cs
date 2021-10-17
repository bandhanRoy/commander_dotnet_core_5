using Commander.Entities;

namespace Commander.Interfaces
{
    public interface IJwtHelper
    {
        string generateJwtToken(User user);
    }
}