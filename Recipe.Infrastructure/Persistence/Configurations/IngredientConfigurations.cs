using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipe.Domain.IngredientAggregate;
using Recipe.Domain.IngredientAggregate.ValueObjects;

namespace Recipe.Infrastructure.Persistence.Configurations;

public class IngredientConfigurations : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        ConfigureIngredientTable(builder);
    }

    private void ConfigureIngredientTable(EntityTypeBuilder<Ingredient> builder)
    {
        builder.ToTable("Ingredients");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => IngredientId.Create(value));

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

        builder.OwnsOne(i => i.Measurement, m =>
        {
            m.Property(me => me.Name);
            m.Property(me => me.Quantity);
        });
    }

}
