using ChessBoard.Api.Repositories;
using ChessBoard.Api.Settings;
using MongoDB.Driver;

namespace ChessBoard.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var services = builder.Services;

            var serviceSettings = builder.Configuration
                .GetSection(nameof(ServiceSettings))
                .Get<ServiceSettings>();

            services.AddScoped(serviceProvider =>
            {
                var mongoDbSettings = builder.Configuration
                    .GetSection(nameof(MongoDbSettings))
                    .Get<MongoDbSettings>();
                var mongoClient = new MongoClient(mongoDbSettings.ConnectionString);
                return mongoClient.GetDatabase(serviceSettings.ServiceName);
            });

            services.AddScoped<IChessBoardRepository, ChessBoardRepository>();


            builder.Services.AddControllers(options => { options.SuppressAsyncSuffixInActionNames = false; });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}