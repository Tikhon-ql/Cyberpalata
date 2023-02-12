using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.DataProvider.Models
{
    public class BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        //A.K.: May be you will need IsNew property soon to check whether to add or to update entity
        //it could be done either with Guid? Id or with Id==Guid.Empty
    }
}
