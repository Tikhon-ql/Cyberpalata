using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.ViewModel.Request.Identity
{
    public class UserCreateViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [RegularExpression("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$")]
        public string Email { get; set; }
        [Required]
        [RegularExpression("^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$")]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
    }
    public class UserCreateViewModelValidator : AbstractValidator<UserCreateViewModel>
    {
        public UserCreateViewModelValidator()
        {
            RuleFor(x => x.Password)
                    .NotEmpty().WithMessage("Your password cannot be empty")
                    .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                    .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
                    .Matches(@"[A-Z]+").WithMessage("Password must contain uppercase letter.")
                    .Matches(@"[a-z]+").WithMessage("Password must contain lowercase letter.")
                    .Matches(@"[0-9]+").WithMessage("Password must contain number.");
        }
    }
}
