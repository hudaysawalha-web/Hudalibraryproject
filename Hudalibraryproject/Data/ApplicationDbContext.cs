using Hudalibraryproject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hudalibraryproject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
       

        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BookCategory>().HasKey(e => new
            {
                e.CategoryId,
                e.BookId
            });
            base.OnModelCreating(builder);
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
