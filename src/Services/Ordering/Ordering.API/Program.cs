var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);
     

var app = builder.Build();

app.UseApiServices();

app.InitialiseDatabaseAsync();


app.Run();
