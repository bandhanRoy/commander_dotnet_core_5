using System.ComponentModel.DataAnnotations;
using Commander.Helper;

namespace Commander.Dtos
{
    public class CommandUpdateDto
    {
        [ConditionallyRequireAttribute]
        [MaxLength(250)]
        public string howTo { get; set; }

        [ConditionallyRequireAttribute]
        public string line { get; set; }

        [ConditionallyRequireAttribute]
        public string platform { get; set; }
    }
}