using MyService.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TempDbContext>(options =>
    options.UseInMemoryDatabase("BiblioDb"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<TempDbContext>();
    // On appelle notre méthode d'initialisation en lui passant le contexte
    BiblioInitializer.Initialize(context);
}

// Init static data
// BiblioInitializer.Initialize();

app.UseSwagger();
app.UseSwaggerUI();

// app.UseHttpsRedirection();

app.MapControllers();

app.Run();