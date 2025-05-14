using zonable.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();


var app = builder.Build();

app.MapGet("/", () => $"Hello World! {System.DateTime.UtcNow}");

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
