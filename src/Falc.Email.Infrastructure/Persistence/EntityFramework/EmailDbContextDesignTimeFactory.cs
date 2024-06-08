using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Falc.Email.Infrastructure.Persistence.EntityFramework;

public class EmailDbContextDesignTimeFactory : IDesignTimeDbContextFactory<EmailDbContext>
{
    public EmailDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EmailDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=password;Database=Falc.Email;Include Error Detail=true");

        return new EmailDbContext(optionsBuilder.Options);
    }
}