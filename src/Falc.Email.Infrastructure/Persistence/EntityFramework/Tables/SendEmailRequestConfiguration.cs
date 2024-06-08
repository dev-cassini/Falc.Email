using Falc.Email.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Falc.Email.Infrastructure.Persistence.EntityFramework.Tables;

public class SendEmailRequestConfiguration : IEntityTypeConfiguration<SendEmailRequest>
{
    public void Configure(EntityTypeBuilder<SendEmailRequest> builder)
    {
        builder.ToTable(nameof(EmailDbContext.SendEmailRequests));

        builder.HasKey(x => x.Id);
        builder.Property(x => x.CreationTimestampUtc);
        builder.Property(x => x.EmailType);
        builder.Property(x => x.RecipientEmailAddress);
        builder.Property(x => x.Metadata).HasColumnType("jsonb");
    }
}