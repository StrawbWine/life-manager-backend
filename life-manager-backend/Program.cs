using life_manager_backend.DbContexts;
using life_manager_backend.Services;
using Microsoft.EntityFrameworkCore;

namespace life_manager_backend
{
    public class Program
    {
        public static void Main(string[] args)
        {            
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                    {
                        policy.AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithOrigins(builder.Configuration["LifeManagerApiCorsEnabledUrl"]);
                    });
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<InMemoryDataStore>();

            builder.Services.AddDbContext<FoodContext>(
                dbContextOptions => dbContextOptions.UseMySql(
                    builder.Configuration["LifeManagerMySQLConnectionString"],
                    ServerVersion.AutoDetect(builder.Configuration["LifeManagerMySQLConnectionString"]))
                );

            builder.Services.AddDbContextFactory<CosmosContext>(optionsBuilder => {
                optionsBuilder.UseCosmos(
                    connectionString: builder.Configuration["DEV_COSMOS_CONNECTION_STRING"],
                    databaseName: builder.Configuration["DEV_COSMOS_DATABASE"]
                );
                }
            );

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //builder.Services.AddScoped<IFoodRepository, FoodRepository>();
            builder.Services.AddScoped<IFoodRepository, CosmosRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
                endpoints.MapControllers());            

            app.Run();
        }
    }
}