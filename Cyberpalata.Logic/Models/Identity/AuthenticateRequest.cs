using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.Logic.Models.Identity
{
    public class AuthenticateRequest
    {
        [Required]
        [RegularExpression("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$")]
        public string Email { get; set;}
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set;}
    }
}
