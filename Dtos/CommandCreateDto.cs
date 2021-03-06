using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
    public class CommandCreateDto
    {
        
        [Required]
        [MaxLength(250)]
        public string howTo { get; set; }
        
        [Required]
        public string line { get; set; }
        
        [Required]
        public string platform { get; set; }
    }
}

