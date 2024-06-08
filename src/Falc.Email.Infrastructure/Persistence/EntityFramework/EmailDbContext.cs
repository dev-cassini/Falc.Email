using System.Reflection;
using Falc.Email.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Falc.Email.Infrastructure.Persistence.EntityFramework;

public class EmailDbContext : DbContext
{
    public DbSet<SendEmailRequest> SendEmailRequests { get; set; } = null!;

    public EmailDbContext(DbContextOptions<EmailDbContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entity.GetProperties().Where(x => x.IsPrimaryKey()))
            {
                property.ValueGenerated = ValueGenerated.Never;
            }
        }
    }
}