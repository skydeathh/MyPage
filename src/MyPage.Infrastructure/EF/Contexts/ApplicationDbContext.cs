using Microsoft.EntityFrameworkCore;
using MyPage.Domain.Entities;

namespace MyPage.Infrastructure.EF.Contexts;

public sealed class ApplicationDbContext : DbContext {
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Posts)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);

        modelBuilder.Entity<User>().HasKey(u => u.Id);

        modelBuilder.Entity<Post>().HasKey(p => p.Id);
    }
}