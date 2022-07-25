using life_manager_backend.Entities;
using life_manager_backend.Utilities;
using Microsoft.EntityFrameworkCore;

namespace life_manager_backend.DbContexts
{
    public class CosmosContext : DbContext
    {
        public DbSet<Food> Foods { get; set; } = null!;
        public DbSet<FoodPortion> FoodPortions { get; set; } = null!;
        public DbSet<ApiUser> ApiUsers { get; set; } = null!;

        public CosmosContext(DbContextOptions<CosmosContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var foodGuid = Guid.NewGuid().ToString();
            var foodPortionGuid = Guid.NewGuid().ToString();

            modelBuilder.Entity<Food>()
                .HasData(
                    new Food("Spaghetti a la Capri")
                    {
                        Id = foodGuid,
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
                        foodId: foodGuid,
                        weightInGrams: 870,
                        dateConsumed: "2022-06-10"
                        )
                    {
                        Id = foodPortionGuid
                    }
                );

            modelBuilder.Entity<ApiUser>()
                .HasData(
                    new ApiUser(
                        username: "TestUsername",
                        password: "TestPassword",
                        email: "TestEmail",
                        registeredAt: new DateTime(2022, 1, 1),
                        isBanned: false
                        )
                    {
                        Id = Guid.NewGuid().ToString()
                    }
                );

            modelBuilder
                .HasDefaultContainer("lifemgr-default")
                .HasManualThroughput(400);

            modelBuilder.Entity<Food>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<Food>()
                .HasPartitionKey(f => f.PartitionKey);

            modelBuilder.Entity<FoodPortion>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<FoodPortion>()
                .HasPartitionKey(f => f.PartitionKey);

            modelBuilder.Entity<ApiUser>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<ApiUser>()
                .HasPartitionKey(u => u.PartitionKey);

            base.OnModelCreating(modelBuilder);
        }
    }
}
