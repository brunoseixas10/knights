
using Knights.Service;
using Knights.Service.Interfaces;
using MongoDB.Driver;

namespace Knights.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<IKnightsRepository, KnightsRepository>();

            var mongoClient = new MongoClient(builder.Configuration.GetConnectionString("MongoDB"));
            var database = mongoClient.GetDatabase("KnightsDatabase");
            builder.Services.AddSingleton<IMongoDatabase>(database);
            builder.Services.AddCors(o => { o.AddPolicy("Allow", builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }); });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
            //}

            app.UseAuthorization();
            app.UseCors("Allow");

            app.MapControllers();

            app.Run();
        }
    }
}
