﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using life_manager_backend.DbContexts;

#nullable disable

namespace life_manager_backend.Migrations
{
    [DbContext(typeof(FoodContext))]
    partial class FoodContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("life_manager_backend.Entities.Food", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<double?>("Carbohydrates")
                        .HasColumnType("double");

                    b.Property<double?>("Energy")
                        .HasColumnType("double");

                    b.Property<double?>("Fat")
                        .HasColumnType("double");

                    b.Property<double?>("Fiber")
                        .HasColumnType("double");

                    b.Property<double?>("MonoUnsaturatedFat")
                        .HasColumnType("double");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double?>("PolyUnsaturatedFat")
                        .HasColumnType("double");

                    b.Property<double?>("Protein")
                        .HasColumnType("double");

                    b.Property<double?>("Salt")
                        .HasColumnType("double");

                    b.Property<double?>("SaturatedFat")
                        .HasColumnType("double");

                    b.Property<double?>("Sugars")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Foods");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Carbohydrates = 12.0,
                            Energy = 99.0,
                            Fat = 4.0999999999999996,
                            Fiber = 0.0,
                            Name = "Spaghetti a la Capri",
                            Protein = 3.5,
                            Salt = 0.84999999999999998,
                            SaturatedFat = 0.90000000000000002,
                            Sugars = 2.6000000000000001
                        });
                });

            modelBuilder.Entity("life_manager_backend.Entities.FoodPortion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateOnly>("DateConsumed")
                        .HasColumnType("date");

                    b.Property<long>("FoodId")
                        .HasColumnType("bigint");

                    b.Property<int>("WeightInGrams")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.ToTable("FoodPortions");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DateConsumed = new DateOnly(2022, 6, 10),
                            FoodId = 1L,
                            WeightInGrams = 870
                        });
                });

            modelBuilder.Entity("life_manager_backend.Entities.FoodPortion", b =>
                {
                    b.HasOne("life_manager_backend.Entities.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");
                });
#pragma warning restore 612, 618
        }
    }
}
