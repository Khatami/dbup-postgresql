using AspNetCore.Extensions;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MigrateDatabase<Program>();

app.MapGet("/", () => "Hello World!");

app.Run();