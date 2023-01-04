using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Models.Identity
{
    public class AuthorizationRequest
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Surname { get; set; }
        [Required]
        //[RegularExpression("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$")]
        public MailAddress? Email { get; set; }
        [Required]
        [RegularExpression("^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$")]
        public string? Phone { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
