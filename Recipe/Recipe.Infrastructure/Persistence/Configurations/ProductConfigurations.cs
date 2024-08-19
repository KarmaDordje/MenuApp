namespace Recipe.Infrastructure.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipe.Domain.IngredientAggregate;
using Recipe.Domain.IngredientAggregate.ValueObjects;

public class IngredientConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        ConfigureIngredientTable(builder);
    }

    private void ConfigureIngredientTable(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ProductId.Create(value));

        builder.Property(i => i.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(i => i.PolishName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(i => i.Calories)
            .HasColumnType("decimal(18,2)");

        builder.Property(i => i.Cholesterol)
            .HasColumnType("decimal(18,2)");

        builder.Property(i => i.FatSaturated)
            .HasColumnType("decimal(18,2)");

        builder.Property(i => i.FatTotal)
            .HasColumnType("decimal(18,2)");

        builder.Property(i => i.Potassium)
            .HasColumnType("decimal(18,2)");

        builder.Property(i => i.Protein)
            .HasColumnType("decimal(18,2)");

        builder.Property(i => i.Sodium)
            .HasColumnType("decimal(18,2)");

        builder.Property(i => i.Sugar)
            .HasColumnType("decimal(18,2)");

        builder.OwnsOne(i => i.Measurement, m =>
        {
            m.Property(me => me.Name);
            m.Property(me => me.Quantity);
        });
    }

}
