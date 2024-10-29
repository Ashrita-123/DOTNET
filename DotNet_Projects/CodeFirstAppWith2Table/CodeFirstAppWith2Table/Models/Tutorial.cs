using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstAppWith2Table.Models
{
    [Table("tblTutorial")]
    public class Tutorial
    {

        //[Key]
        //public int Id { get; set; }
        public int TutorialId { get; set; }
        [RegularExpression( @"^[a-zA-Z-_]*$", ErrorMessage = "please enter text")]
        [Required]
        [Display(Name = "Tutorial Name")]
        public string? TutorialName { get; set; }
        [Required]
        [Display(Name = "Tutorial Description")]
        public string? Description { get; set; }
        //Relationship
        //public List<Article> Articles { get; set; }
        //public int ArticleId { get; set; }
        public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}
