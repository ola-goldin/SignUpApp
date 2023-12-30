using Domain.BLL;
using Domain.DAL;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UserContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("UsersDbConection")));

builder.Services.AddSingleton<ModelsConverter>();


var app = builder.Build();

app.MapGet("/", () => "Hello World!");


app.Run();
