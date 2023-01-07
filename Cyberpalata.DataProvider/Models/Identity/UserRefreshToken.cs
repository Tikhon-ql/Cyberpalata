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
        [Required] public ApiUser User { get; set; }
        [Required] public byte[] RefreshToken { get; set; }
        [Required] public DateTime Expiration { get; set; }
    }
}
