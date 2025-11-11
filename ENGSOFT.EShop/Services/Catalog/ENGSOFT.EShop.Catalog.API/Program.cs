var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// add Carter
builder.Services.AddCarter();

builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

// add MediatR
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapCarter();
app.Run();
