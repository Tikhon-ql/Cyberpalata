using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.ViewModel.Request.Identity
{
    public class AuthenticateViewModel
    {
        [Required]
        [RegularExpression("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$")]
        public string Email { get; set;}
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set;}
    }
}
