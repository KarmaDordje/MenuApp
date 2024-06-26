﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Recipe.Infrastructure.Persistence;

#nullable disable

namespace Recipe.Infrastructure.Migrations
{
    [DbContext(typeof(RecipeDbContext))]
    [Migration("20240412094209_RecipeIngredintNewTable")]
    partial class RecipeIngredintNewTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Recipe.Domain.Entities.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<float>("AvarageRating")
                        .HasColumnType("real");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("VideoUrl")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Recipes", (string)null);
                });

            modelBuilder.Entity("Recipe.Domain.Entities.Recipe", b =>
                {
                    b.OwnsMany("Recipe.Domain.Entities.RecipeStep", "RecipeSteps", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid")
                                .HasColumnName("RecipeStepId");

                            b1.Property<Guid>("RecipeId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)");

                            b1.Property<int>("Order")
                                .HasColumnType("integer");

                            b1.HasKey("Id", "RecipeId");

                            b1.HasIndex("RecipeId");

                            b1.ToTable("RecipeSteps", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("RecipeId");
                        });

                    b.OwnsMany("Recipe.Domain.ValueObjects.RecipeIngredient", "Ingredients", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("RecipeId")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("IngredientId")
                                .HasColumnType("uuid")
                                .HasColumnName("IngredientId");

                            b1.Property<decimal>("Quantity")
                                .HasColumnType("numeric");

                            b1.HasKey("Id", "RecipeId");

                            b1.HasIndex("RecipeId");

                            b1.ToTable("RecipeIngredients", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("RecipeId");
                        });

                    b.Navigation("Ingredients");

                    b.Navigation("RecipeSteps");
                });
#pragma warning restore 612, 618
        }
    }
}
