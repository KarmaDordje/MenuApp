namespace User.Infrastructure.Persistance.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User.Domain.ValueObjects;

internal class UserConfigurations : IEntityTypeConfiguration<Domain.UserAggregate.User> 
    {
        public void Configure(EntityTypeBuilder<Domain.UserAggregate.User> builder)
        {
            ConfigureUserTable(builder);
        }

        private void ConfigureUserTable(EntityTypeBuilder<Domain.UserAggregate.User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);

            builder.Property(r => r.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));

            builder.Property(u => u.Email)
                .HasMaxLength(100)
                .IsRequired();
            
            builder.Property(u => u.FirstName);
            builder.Property(u => u.LastName);
            builder.Property(u => u.Login);
            builder.Property(u => u.Password);
            builder.Property(u => u.RegistrationDate);
            builder.Property(u => u.ConfirmationDate);

            builder.OwnsOne(u => u.RegistrationStatus, rs =>
            {
                rs.Property(s => s.Value)
                    .HasColumnName("RegistrationStatus")
                    .HasMaxLength(100)
                    .IsRequired();
            });
        }
    }