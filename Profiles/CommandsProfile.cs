using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // source -> target
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>().ForAllMembers(o => o.Condition((source, destination, member) => member != null && member as string != ""));
            CreateMap<Command, CommandUpdateDto>();
        }
    }
}