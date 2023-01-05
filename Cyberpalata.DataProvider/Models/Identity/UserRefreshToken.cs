using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models.Identity
{
    public class UserRefreshToken
    {
        [Key] public Guid Id { get; set; }
        [Required] public string? UserEmail { get; set; }
        [Required] public string? RefreshToken { get; set; }
    }
}
