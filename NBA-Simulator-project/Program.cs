using Microsoft.EntityFrameworkCore;
using NBA_Simulator_project.Data;
using dotenv.net;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_MyAllowSpecificOrigins";

DotEnv.Load();

// Add services to the container.

var url = Environment.GetEnvironmentVariable("BACKEND_URL");

var backendUrl = url ?? "http://localhost:4200";

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
        policy => {
            policy.WithOrigins(backendUrl)
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
    
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var postgresSQL = Environment.GetEnvironmentVariable("POSTGRES_SQL");

var connectionString = postgresSQL;

builder.Services.AddDbContext<NbaDb>(options =>
    options.UseNpgsql(connectionString)
);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8081";
builder.WebHost.UseUrls($"http://*:{port}");

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
