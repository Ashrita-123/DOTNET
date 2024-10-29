using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstAppWith2Table.Models
{
    public class TutorialDbContext : DbContext
    {

        public TutorialDbContext(DbContextOptions<TutorialDbContext> options) : base(options)
        { }
         public DbSet <Tutorial> Tutorials { get; set; }
          public DbSet<Article> Articles { get; set; }

    }
}
