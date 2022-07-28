using Microsoft.EntityFrameworkCore;
using MusicDemo.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
var connectionString = builder.Configuration.GetConnectionString("MysqlConnectionString");
builder.Services.AddDbContext<MusicContext>(opt =>
{
    opt.UseMySql(connectionString, serverVersion);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc(); 
builder.Logging.AddLog4Net("log4net.config");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
