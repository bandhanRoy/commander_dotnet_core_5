using System.ComponentModel.DataAnnotations;

namespace Commander.model
{
    public class AuthRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}