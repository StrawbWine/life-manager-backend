using life_manager_backend.DbContexts;
using life_manager_backend.Services;
using Microsoft.EntityFrameworkCore;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Core;

namespace life_manager_backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SecretClientOptions options = new SecretClientOptions()
            {
                Retry =
                    {
                        Delay= TimeSpan.FromSeconds(2),
                        MaxDelay = TimeSpan.FromSeconds(16),
                        MaxRetries = 5,
                        Mode = RetryMode.Exponential
                     }
            };
            var client = new SecretClient(new Uri("https://guitar-app-kv.vault.azure.net/"), new DefaultAzureCredential(), options);

            KeyVaultSecret connStringSecret = client.GetSecret("cosmos-connection-string");
            KeyVaultSecret databaseSecret = client.GetSecret("cosmos-database");

            string connString = connStringSecret.Value;
            string databaseName = databaseSecret.Value;


            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<InMemoryDataStore>();

            //builder.Services.AddDbContext<FoodContext>(
            //    dbContextOptions => dbContextOptions.UseMySql(
            //        builder.Configuration["LifeManagerMySQLConnectionString"],
            //        ServerVersion.AutoDetect(builder.Configuration["LifeManagerMySQLConnectionString"]))
            //    );

            if (builder.Environment.EnvironmentName == "Development")
            {
                builder.Services.AddDbContextFactory<CosmosContext>(optionsBuilder => {
                    optionsBuilder.UseCosmos(
                        connectionString: builder.Configuration["DEV_COSMOS_CONNECTION_STRING"],
                        databaseName: builder.Configuration["DEV_COSMOS_DATABASE"]
                    );
                });
                builder.Services.AddCors(options =>
                {
                    options.AddDefaultPolicy(policy =>
                    {
                        policy.AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithOrigins(builder.Configuration["LifeManagerApiCorsEnabledUrl"]);
                    });
                });
            }

            else
            {
                builder.Services.AddDbContextFactory<CosmosContext>(optionsBuilder => {
                    optionsBuilder.UseCosmos(
                        connectionString: connString,
                        databaseName: databaseName
                    );
                });
            }

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

            app.MapGet("/", () => builder.Configuration["WEBSITE_SITE_NAME"]);

            app.Run();
        }
    }
}