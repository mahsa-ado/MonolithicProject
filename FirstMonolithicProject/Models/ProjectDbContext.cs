using FirstMonolithicProject.Models.DomainModels.PersonAggregates;
using FirstMonolithicProject.Models.DomainModels.ProductAggregates;
using Microsoft.EntityFrameworkCore;

namespace FirstMonolithicProject.Models
{
    public class ProjectDbContext:DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
           : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
