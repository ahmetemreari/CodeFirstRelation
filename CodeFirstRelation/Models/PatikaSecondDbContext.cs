// filepath: /Users/ahmetemreari/Desktop/CodeFirstRelation/CodeFirstRelation/Data/PatikaSecondDbContext.cs
using Microsoft.EntityFrameworkCore;
using CodeFirstRelation.Models;

namespace CodeFirstRelation.Data
{
    public class PatikaSecondDbContext : DbContext
    {
        public PatikaSecondDbContext(DbContextOptions<PatikaSecondDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId);
        }
    }
}