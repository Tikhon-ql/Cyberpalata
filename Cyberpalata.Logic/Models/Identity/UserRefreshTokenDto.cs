﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Models.Identity
{
    public class UserRefreshTokenDto
    {
        [Required] public string? UserEmail { get; set; }
        [Required] public string? RefreshToken { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
