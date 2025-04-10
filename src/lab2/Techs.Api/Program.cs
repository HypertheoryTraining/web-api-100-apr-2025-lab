using FluentValidation;
using Marten;
using Techs.Api.Techs;
using Techs.Api.Techs.Services;


// Got Going on this.
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("techs") ??
                       throw new Exception("No Connection String");

builder.Services.AddScoped<IValidator<TechCreateModel>, TechCreateModelValidator>();

builder.Services.AddMarten(options =>
{
    options.Connection(connectionString);
}).UseLightweightSessions();

builder.Services.AddScoped<ITechRepository, PostGresMartenTechRepository>();

var app = builder.Build();

app.MapControllers();

app.Run();

public partial class Program;
