using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models.Identity
{
    public class Role : BaseEntity
    {
        [MaxLength(30)]
        public string Name { get;set; }
    }
}
