
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

        builder.Property(i => i.Calories);

        builder.Property(i => i.Cholesterol);

        builder.Property(i => i.FatSaturated);

        builder.Property(i => i.FatTotal);

        builder.Property(i => i.Potassium);

        builder.Property(i => i.Protein);

        builder.Property(i => i.Sodium);

        builder.Property(i => i.Sugar);

        builder.OwnsOne(i => i.Measurement, m =>
        {
            m.Property(me => me.Name);
            m.Property(me => me.Quantity);
        });
    }

}
