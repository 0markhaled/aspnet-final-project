using Microsoft.EntityFrameworkCore;
namespace Final_Project.Models;

public class ProjectContext : DbContext
{
   public ProjectContext(DbContextOptions<ProjectContext> options) //empty constructor
       : base(options)
   {
   }
   public DbSet<Member> Member { get; set; } = default!;
   public DbSet<Pet> Pets { get; set; } = default!;
}
