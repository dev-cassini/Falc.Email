using Falc.CleanArchitecture.Infrastructure;
using Falc.CleanArchitecture.Infrastructure.Persistence.EntityFramework;
using Falc.Email.Infrastructure.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddInfrastructure(infrastructureConfigurator =>
    {
        infrastructureConfigurator
            .AddPersistence(persistenceConfigurator =>
            {
                persistenceConfigurator
                    .AddEntityFramework(efConfigurator =>
                    {
                        efConfigurator
                            .AddDbContext<EmailDbContext>((_, optionsBuilder) =>
                            {
                                optionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
                            });
                    });
            });
    });

var app = builder.Build();

app.Services.MigrateDatabase<EmailDbContext>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();