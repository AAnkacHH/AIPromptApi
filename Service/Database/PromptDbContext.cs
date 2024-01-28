using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PromptAPI.Model.Entity;

namespace PromptAPI.Service.Database;

public class PromptDbContext : DbContext
{
    public PromptDbContext(DbContextOptions<PromptDbContext> options)
        : base(options)
    {
    }

    public DbSet<Prompt> Prompts { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }      
}
