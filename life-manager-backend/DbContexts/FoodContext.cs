﻿using life_manager_backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace life_manager_backend.DbContexts
{
    public class FoodContext : DbContext
    {
        public DbSet<Food> Foods { get; set; } = null!;
        public DbSet<FoodPortion> FoodPortions { get; set; } = null!;

        public FoodContext(DbContextOptions<FoodContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>()
                .HasData(
                    new Food("Spaghetti a la Capri")
                    {
                        Id = 1,
                        Energy = 99,
                        Fat = 4.10,
                        SaturatedFat = 0.90,
                        Carbohydrates = 12.0,
                        Sugars = 2.60,
                        Fiber = 0.0,
                        Protein = 3.50,
                        Salt = 0.85
                    }
                );

            modelBuilder.Entity<FoodPortion>()
                .HasData(
                    new FoodPortion(
                        foodId: 1,
                        weightInGrams: 870,
                        dateConsumed: new DateTime(2022, 6, 10)
                        )
                    {
                        Id = 1
                    }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}