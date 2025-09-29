using BiblioManagement.Models;
using BiblioManagement.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MyService.Data
{
    public class TempDbContext : DbContext
    {
        public TempDbContext(DbContextOptions<TempDbContext> options) : base(options)
        {
        }

        public DbSet<Livre> Livres => Set<Livre>();
        public DbSet<Auteur> Auteurs => Set<Auteur>();
        public DbSet<Categorie> Categories => Set<Categorie>();

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseInMemoryDatabase("BiblioDb");
        }
        */
    }

    public static class BiblioInitializer
    {
        public static void Initialize(TempDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Livres.Any())
            {
                return; // DB already seeded
            }

            // Auteurs.AddRange(new List<Auteur>
            var auteurs = new[]
            {
                new Auteur { Nom = "Tolkien", Prenom = "JRR" },
                new Auteur { Nom = "Mathieu", Prenom = "Nicolas" },
                new Auteur { Nom = "Herbert", Prenom = "Frank" },
                new Auteur { Nom = "Rowling", Prenom = "JK" },
                new Auteur { Nom = "Clarke", Prenom = "Arthur" }
            };
            context.Auteurs.AddRange(auteurs);

            // Categories.AddRange(new List<Categorie>
            var categories = new[]
            {
                new Categorie { Nom = "Fantaisie" },
                new Categorie { Nom = "Science-Fiction" },
                new Categorie { Nom = "Aventure" }
            };
            context.Categories.AddRange(categories);

            // Livres.AddRange(new List<Livre>
            var livres = new[]
            {
                new Livre { Titre = "Le Seigneur des Anneaux", Type = TypeLivre.Fantaisie, Auteurs = { auteurs[0] }, Categories = { categories[0], categories[2] } },
                new Livre { Titre = "Leurs enfants après eux", Type = TypeLivre.Scientifique, Auteurs = { auteurs[1] }, Categories = { categories[1] } },
                new Livre { Titre = "Dune", Type = TypeLivre.Scientifique, Auteurs = { auteurs[2] }, Categories = { categories[1] } },
                new Livre { Titre = "Harry Potter à l'école des sorciers", Type = TypeLivre.Fantaisie, Auteurs = { auteurs[3] }, Categories = { categories[0] } },
                new Livre { Titre = "Le Hobbit", Type = TypeLivre.Fantaisie, Auteurs = { auteurs[0] }, Categories = { categories[0], categories[2] } },
                new Livre { Titre = "Les Robots", Type = TypeLivre.Scientifique, Auteurs = { auteurs[1] }, Categories = { categories[1] } },
                new Livre { Titre = "2001 L'odyssée de l'espace", Type = TypeLivre.Fantaisie, Auteurs = { auteurs[4] }, Categories = { categories[0] } },
            };
            context.Livres.AddRange(livres);

            // Save changes with transaction
            context.SaveChanges();
        }
    }
}