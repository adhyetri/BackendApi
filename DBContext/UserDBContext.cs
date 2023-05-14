using Microsoft.EntityFrameworkCore;
using SampleApi.Models;

namespace SampleApi.DBContext
{
    public class UserDBContext : DbContext
    {
        public DbSet<SignUpRequest> Users { get; set; }
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options) { }

        public UserDBContext() { }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
