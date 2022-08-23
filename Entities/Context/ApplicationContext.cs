using Entities.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entities {
    public class ApplicationContext : IdentityDbContext<UserModel> {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
            :base (options) {
        }
        public DbSet<BookModel> Books{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
        }
    }
}
