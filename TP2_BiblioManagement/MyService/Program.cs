using MyService.Data;

var builder = WebApplication.CreateBuilder(args);

// =============================================================
// 1. AJOUTER LES SERVICES AU CONTENEUR D'INJECTION DE DÉPENDANCES
// =============================================================

builder.Services.AddControllers();

// Ces deux lignes sont nécessaires pour faire fonctionner Swagger.
// Elles doivent impérativement être AVANT builder.Build()
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// =============================================================
// 2. CONSTRUIRE L'APPLICATION
// =============================================================
var app = builder.Build();

// Initialiser les données statiques (juste après la construction)
BiblioInitializer.Initialize();

// =============================================================
// 3. CONFIGURER LE PIPELINE DE REQUÊTES HTTP
// =============================================================

// On active l'interface Swagger uniquement en environnement de développement
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }

// app.UseHttpsRedirection(); // Vous pouvez décommenter cette ligne plus tard

app.MapControllers();

app.Run();