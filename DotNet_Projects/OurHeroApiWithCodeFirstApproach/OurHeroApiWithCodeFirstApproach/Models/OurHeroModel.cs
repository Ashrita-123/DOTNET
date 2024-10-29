using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OurHeroApiWithCodeFirstApproach.Models
{
    [Table("tblOurHero")]
    public class OurHeroModel
    {
        [Key]
        public int Id;

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public bool isActive { get; set; }

    }
}
