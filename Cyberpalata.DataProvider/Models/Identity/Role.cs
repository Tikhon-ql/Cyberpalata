using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.DataProvider.Models.Identity
{
    public class Role : BaseEntity
    {
        [MaxLength(30)]
        public string Name { get;set; }
    }
}
