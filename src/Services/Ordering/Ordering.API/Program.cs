using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();
     

var app = builder.Build();

app.UseApiServices();

app.InitialiseDatabaseAsync();


app.Run();
