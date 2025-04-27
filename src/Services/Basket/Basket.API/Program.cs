using BuildingBlocks.Exceptions.Handler;

var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly;
var connectionstring = builder.Configuration.GetConnectionString("Default");


builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddMarten(opts =>
{
    opts.Connection(connectionstring);
    opts.Schema.For<ShoppingCart>().Identity(x => x.UserName);

}).UseLightweightSessions();

builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddExceptionHandler<CustomExceptionHandler>();

// Add services to the container

var app = builder.Build();

app.MapCarter();
app.UseExceptionHandler(opts => { });
// Configure the HTTP request pipeline

app.Run();
