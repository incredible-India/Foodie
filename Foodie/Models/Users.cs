using System.ComponentModel.DataAnnotations;

namespace Foodie.Models
{
    public class Users
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? Address { get; set; }

        [Required]
        public string? UType { get; set; } = "User";

    }

}
