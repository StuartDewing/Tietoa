//using Services.Player;
using FluentValidation;
using Services.GetRequest;
using Services.GetRequest.Interface;
using Services.NHL;
using Services.NHL.Interface;
using Services.NHL.Player;
using Services.NHL.Player.Interface;
using Services.NHL.Player.Validation;
//using Services.Sql.GetData;
using Services.Sql.Interface;
using Services.Sql.UpdateData;
using Tietoa.Domain.Models.Player;
//using Services.Sql.UpdateData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.ConfigureServices(x => {
    //HTTP
    x.AddScoped<IGetRequest, GetRequest>();
    //NHL
    x.AddScoped<INhlRequest, NhlRequest>();
    x.AddScoped<IDraftSql, DraftSql>();

    //SQL
    x.AddScoped<IInsertData, DivisionsSql>();
    //Player
    x.AddScoped<INhlPlayerService, NhlPlayerService>();
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
