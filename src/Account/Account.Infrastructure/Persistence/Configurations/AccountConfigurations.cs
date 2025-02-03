using Account.Domain.AccountRegistrationAggregate;
using Account.Domain.AccountRegistrationAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Account.Infrastructure.Persistance.Configurations;

public class AccountConfigurations : IEntityTypeConfiguration<AccountRegistrations>
{
    public void Configure(EntityTypeBuilder<AccountRegistrations> builder)
    {
        ConfigureAccountRegistrationTable(builder);
    }

    private void ConfigureAccountRegistrationTable(EntityTypeBuilder<AccountRegistrations> builder)
    {
        builder.ToTable("AccountRegistrations");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value,
                value => AccountRegistrationId.Create(value));

        builder.Property(l => l.Login)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Email)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Password)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(f => f.FirstName)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(f => f.LastName)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(n => n.Name)
            .HasMaxLength(80)
            .IsRequired();

        builder.Property(d => d.RegistrationDate);
        builder.Property(c => c.ConfirmedDate);

        builder.OwnsOne<UserRegistrationStatus>(f => f.Status, a =>
        {
            a.Property(f => f.Value);
        });

    }
}