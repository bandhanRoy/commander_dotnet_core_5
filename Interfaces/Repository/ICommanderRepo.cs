using System.Collections.Generic;
using Commander.Entities;

namespace Commander.Interfaces
{
    public interface ICommanderRepo
    {

        bool SaveChanges();

        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommand(Command command);
        void UpdateCommand(Command command);
    }
}