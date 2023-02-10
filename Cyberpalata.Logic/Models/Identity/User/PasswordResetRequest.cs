using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.Logic.Models.Identity.User
{
    public class PasswordResetRequest
    {
        [RegularExpression("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$")]
        public string Email { get; set; } = String.Empty;
        [DataType(DataType.Password)]
        public string Password { get; set; } = String.Empty;
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirm { get; set; } = String.Empty;
    }
}
