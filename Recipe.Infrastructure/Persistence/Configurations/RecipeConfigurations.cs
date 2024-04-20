using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Recipe.Domain.IngredientAggregate.ValueObjects;

namespace Recipe.Infrastructure.Persistence.Configurations;

public class RecipeConfigurations : IEntityTypeConfiguration<Domain.RecipeAggregate.Recipe>
{
    public void Configure(EntityTypeBuilder<Domain.RecipeAggregate.Recipe> builder)
    {
        ConfigureRecipeTable(builder);
        ConfigureRecipeStepTable(builder);
        ConfigureRecipeIngredientTable(builder);
    }

    private void ConfigureRecipeIngredientTable(EntityTypeBuilder<Domain.RecipeAggregate.Recipe> builder)
    {
        builder.OwnsMany(s => s.Ingredients, sb =>
        {
            sb.ToTable("RecipeIngredients");

            sb.WithOwner().HasForeignKey("RecipeId");

            sb.HasKey("Id", "RecipeId");

            sb.Property(s => s.IngredientId)
                .HasColumnName("IngredientId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => IngredientId.Create(value));

            sb.Property(s => s.Quantity);
        });

        builder.Metadata.FindNavigation(nameof(Domain.RecipeAggregate.Recipe.Ingredients))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureRecipeStepTable(EntityTypeBuilder<Domain.RecipeAggregate.Recipe> builder)
    {
        builder.OwnsMany(s => s.RecipeSteps, sb =>
        {
            sb.ToTable("RecipeSteps");

            sb.WithOwner().HasForeignKey("RecipeId");

            sb.HasKey("Id", "RecipeId");

            sb.Property(s => s.Id)
                .HasColumnName("RecipeStepId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => Domain.ValueObjects.RecipeStepId.Create(value));

            sb.Property(s => s.Name)
                .HasMaxLength(100);

            sb.Property(s => s.Order);
        });

        builder.Metadata.FindNavigation(nameof(Domain.RecipeAggregate.Recipe.RecipeSteps))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

    }

    private void ConfigureRecipeTable(EntityTypeBuilder<Domain.RecipeAggregate.Recipe> builder)
    {
        builder.ToTable("Recipes");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => Domain.ValueObjects.RecipeId.Create(value));

        builder.Property(r => r.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(r => r.Description)
            .HasMaxLength(500);

        builder.Property(r => r.AvarageRating);

        builder.Property(r => r.ImageUrl)
            .HasMaxLength(100);

        builder.Property(r => r.VideoUrl)
            .HasMaxLength(100);

        builder.Property(r => r.UserId);

        builder.Property(r => r.CreatedAt);

        builder.Property(r => r.UpdatedAt);
    }
}