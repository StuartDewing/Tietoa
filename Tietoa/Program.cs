using FluentValidation;
using Services.GetRequest;
using Services.GetRequest.Interface;
using Services.NHL;
using Services.NHL.Interface;
using Services.NHL.Player;
using Services.NHL.Player.Interface;
using Tietoa.Domain.Models.Player;
using Tietoa.Services.Player;
using Tietoa.Services.Player.Interface;
using Tietoa.Validation.Player;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.ConfigureServices(x => {
    //Services
    x.AddScoped<INhlRequest, NhlRequest>();
    x.AddScoped<IGetRequest, GetRequest>();
    //Tietoa.Services
    x.AddScoped<INhlPlayerService222, NhlPlayerService>();
    x.AddScoped<IPlayerSqlQuerys, PlayerSqlQuerys>();
    //Tietoa.Validation
    x.AddScoped<IValidator<PlayerRequestModel>, PlayerValidator>();
});

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
