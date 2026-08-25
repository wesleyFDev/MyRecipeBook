using Microsoft.EntityFrameworkCore;
using MyRecipeBook.domain.Entities;

namespace MyRecipeBook.infrastructure.DataAccess
{
    internal class MyRecipeBookDbContext : DbContext
    {
        public MyRecipeBookDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<User> Users { get; set; }

    }
        
}
