using Cyberpalata.Common;
using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.ViewModel.Request.Identity
{
    public class PasswordResetViewModel
    {
        [Required]
        [RegularExpression("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$")]
        public string Email { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirm { get; set; } = string.Empty;
    }
    public class PasswordResetViewModelValidator : AbstractValidator<PasswordResetViewModel>
    {
        public PasswordResetViewModelValidator()
        {
            RuleFor(x => x.Password).Password();
            RuleFor(x => x.PasswordConfirm).Password();
        }
    }
}
