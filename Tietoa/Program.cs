//using Services.Player;
using Services.GetRequest;
using Services.GetRequest.Interface;
using Services.NHL;
using Services.NHL.Divisions;
using Services.NHL.Draft;
using Services.NHL.Interface;
using Services.NHL.Interface.Divisions;
using Services.NHL.Interface.Draft;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.ConfigureServices(x => {
    x.AddScoped<INhlRequest, NhlRequest>();
    x.AddScoped<IGetRequest, GetRequest>();
    //Draft
    x.AddScoped<INhlDraftService, NhlDraftService>();
    x.AddScoped<INhlDraftRequestService, NhlDraftRequestService>();
    x.AddScoped<INhlDraftMappingService, NhlDraftMappingService>();
    x.AddScoped<INhlDraftTeamMappingService, NhlDraftTeamMappingService>();
    //Divisons
    x.AddScoped<INhlDivisionsService, NhlDivisionsService>();
    x.AddScoped<INhlDivisionsRequestService, NhlDivisionsRequestService>();
    x.AddScoped<INhlDivisionsMappingService, NhlDivisionsMappingService>();
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
