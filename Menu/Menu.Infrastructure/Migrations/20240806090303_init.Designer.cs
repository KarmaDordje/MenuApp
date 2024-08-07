﻿// <auto-generated />
using System;
using Menu.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Menu.Infrastructure.Migrations
{
    [DbContext(typeof(MenuDbContext))]
    [Migration("20240806090303_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Menu.Domain.MenuAggregate.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Menus", (string)null);
                });

            modelBuilder.Entity("Menu.Domain.MenuAggregate.Menu", b =>
                {
                    b.OwnsMany("Menu.Domain.MenuAggregate.Entities.MenuDay", "MenuDays", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid")
                                .HasColumnName("MenuDayId");

                            b1.Property<Guid>("MenuId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("DayOfWeek")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)");

                            b1.HasKey("Id", "MenuId");

                            b1.HasIndex("MenuId");

                            b1.ToTable("MenuDays", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("MenuId");

                            b1.OwnsMany("Menu.Domain.MenuAggregate.Entities.Meal", "Meals", b2 =>
                                {
                                    b2.Property<Guid>("Id")
                                        .HasColumnType("uuid")
                                        .HasColumnName("MealId");

                                    b2.Property<Guid>("MenuDayId")
                                        .HasColumnType("uuid");

                                    b2.Property<Guid>("MenuId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("MealType")
                                        .HasColumnType("integer");

                                    b2.Property<string>("RecipeDescription")
                                        .IsRequired()
                                        .HasMaxLength(500)
                                        .HasColumnType("character varying(500)");

                                    b2.Property<string>("RecipeImageUrl")
                                        .IsRequired()
                                        .HasMaxLength(500)
                                        .HasColumnType("character varying(500)");

                                    b2.Property<string>("RecipeName")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("character varying(100)");

                                    b2.Property<Guid>("UserId")
                                        .HasColumnType("uuid");

                                    b2.HasKey("Id", "MenuDayId", "MenuId");

                                    b2.HasIndex("MenuDayId", "MenuId");

                                    b2.ToTable("Meals", (string)null);

                                    b2.WithOwner()
                                        .HasForeignKey("MenuDayId", "MenuId");
                                });

                            b1.Navigation("Meals");
                        });

                    b.Navigation("MenuDays");
                });
#pragma warning restore 612, 618
        }
    }
}
