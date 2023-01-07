using Cyberpalata.DataProvider.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Models.Identity
{
    public class UserRefreshTokenDto
    {
        [Required] public byte[] RefreshToken { get; set; }
        [Required] public DateTime Expiration { get; set; }
    }
}
