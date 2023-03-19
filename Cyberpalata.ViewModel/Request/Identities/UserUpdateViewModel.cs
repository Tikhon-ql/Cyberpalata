using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.ViewModel.Request.Identity
{
    public class UserUpdateRequest
    {
        public Guid UserId { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Surname { get; set; } = string.Empty;
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        [RegularExpression(pattern: "^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$")]
        public string Phone { get; set; } = string.Empty;
    }
}
