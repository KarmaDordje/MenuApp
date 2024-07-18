namespace Recipe.Infrastructure.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Recipe.Domain.IngredientAggregate;

using Recipe.Domain.IngredientAggregate.ValueObjects;
using Recipe.Domain.RecipeAggregate.Entities;
using Recipe.Domain.RecipeAggregate.ValueObjects;

public class RecipeConfigurations : IEntityTypeConfiguration<Domain.RecipeAggregate.Recipe>
{
    public void Configure(EntityTypeBuilder<Domain.RecipeAggregate.Recipe> builder)
    {
        ConfigureRecipeTable(builder);
        ConfigureRecipeStepTable(builder);
        ConfigureRecipeSectionTable(builder);
    }

    private static void ConfigureRecipeSectionTable(EntityTypeBuilder<Domain.RecipeAggregate.Recipe> builder)
    {
        builder.OwnsMany(s => s.RecipeSections, rs =>
        {
            rs.ToTable("RecipeSections");

            rs.WithOwner().HasForeignKey("RecipeId");

            rs.HasKey("Id", "RecipeId");

            rs.Property(s => s.Id)
                .HasColumnName("RecipeSectionId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => RecipeSectionId.Create(value));

            rs.Property(s => s.Title)
                .HasMaxLength(100);

            rs.OwnsMany(s => s.Ingredients, ri =>
            {
                ri.ToTable("RecipeIngredients");

                ri.WithOwner().HasForeignKey("RecipeSectionId", "RecipeId");

                ri.HasKey(nameof(Product.Id), "RecipeSectionId", "RecipeId");

                ri.Property(i => i.Id)
                .HasColumnName("RecipeIngredientId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => ProductId.Create(value));

                ri.Property(i => i.Quantity)
                .HasColumnType("decimal(18,2)");

            });

            rs.Navigation(s => s.Ingredients).Metadata.SetField("_ingredients");
            rs.Navigation(s => s.Ingredients).UsePropertyAccessMode(PropertyAccessMode.Field);
        });

        builder.Metadata.FindNavigation(nameof(Domain.RecipeAggregate.Recipe.RecipeSections)) !
            .SetPropertyAccessMode(PropertyAccessMode.Field);

    }

    private static void ConfigureRecipeStepTable(EntityTypeBuilder<Domain.RecipeAggregate.Recipe> builder)
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
                .HasMaxLength(1000);

            sb.Property(s => s.Order);
        });

        builder.Metadata.FindNavigation(nameof(Domain.RecipeAggregate.Recipe.RecipeSteps)) !
            .SetPropertyAccessMode(PropertyAccessMode.Field);

    }

    private static void ConfigureRecipeTable(EntityTypeBuilder<Domain.RecipeAggregate.Recipe> builder)
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