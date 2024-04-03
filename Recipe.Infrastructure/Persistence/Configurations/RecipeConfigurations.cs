using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Recipe.Infrastructure.Persistence.Configurations;

public class RecipeConfigurations : IEntityTypeConfiguration<Domain.Entities.Recipe>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Recipe> builder)
    {
        ConfigureRecipeTable(builder);
        ConfigureRecipeStepTable(builder);
        ConfigureRecipeIngredientTable(builder);
    }

    private void ConfigureRecipeIngredientTable(EntityTypeBuilder<Domain.Entities.Recipe> builder)
    {
        builder.OwnsMany(s => s.Ingredients, sb =>
        {
            sb.ToTable("RecipeIngredients");

            sb.WithOwner().HasForeignKey("RecipeId");

            sb.HasKey("Id", "RecipeId");

            sb.Property(s => s.Id)
                .HasColumnName("IngredintId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => Domain.ValueObjects.IngredientId.Create(value));
            sb.Property(s => s.Name)
                .HasMaxLength(100);
            
            sb.Property(s => s.PolishName)
                .HasMaxLength(100);

            sb.Property(s => s.Calories);

            sb.Property(s => s.Cholesterol);

            sb.Property(s => s.FatSaturated);

            sb.Property(s => s.FatTotal);

            sb.Property(s => s.Potassium);

            sb.Property(s => s.Protein);

            sb.Property(s => s.Sodium);

            sb.OwnsOne(s => s.Measurement, ms =>
            {
                ms.Property(m => m.Quantity)
                .HasConversion<string>();
                ms.Property(m => m.Name);
            });

        });

        builder.Metadata.FindNavigation(nameof(Domain.Entities.Recipe.Ingredients))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureRecipeStepTable(EntityTypeBuilder<Domain.Entities.Recipe> builder)
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

        builder.Metadata.FindNavigation(nameof(Domain.Entities.Recipe.RecipeSteps))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

    }

    private void ConfigureRecipeTable(EntityTypeBuilder<Domain.Entities.Recipe> builder)
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