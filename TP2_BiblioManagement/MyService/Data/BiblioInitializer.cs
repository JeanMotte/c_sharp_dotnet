// using BiblioManagement.Models;
// using BiblioManagement.Models.Enums;
// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace MyService.Data
// {
//     public static class BiblioInitializer
//     {
//         public static List<Auteur> Auteurs { get; private set; } = new List<Auteur>();
//         public static List<Categorie> Categories { get; private set; } = new List<Categorie>();
//         public static List<Livre> Livres { get; private set; } = new List<Livre>();

//         public static void Initialize()
//         {
//             // Si les données sont déjà initialisées, ne rien faire
//             if (Livres.Any()) return;

//             // Initialiser les Auteurs
//             Auteurs.AddRange(new List<Auteur>
//             {
//                 new Auteur { Id = 1, Nom = "Tolkien", Prenom = "J.R.R." },
//                 new Auteur { Id = 2, Nom = "Asimov", Prenom = "Isaac" },
//                 new Auteur { Id = 3, Nom = "Herbert", Prenom = "Frank" },
//                 new Auteur { Id = 4, Nom = "Rowling", Prenom = "J.K." },
//                 new Auteur { Id = 5, Nom = "Martin", Prenom = "George R.R." }
//             });

//             // Initialiser les Catégories
//             Categories.AddRange(new List<Categorie>
//             {
//                 new Categorie { Id = 1, Nom = "Fantaisie" },
//                 new Categorie { Id = 2, Nom = "Science-Fiction" },
//                 new Categorie { Id = 3, Nom = "Aventure" },
//                 new Categorie { Id = 4, Nom = "Roman Historique" },
//                 new Categorie { Id = 5, Nom = "Jeunesse" }
//             });

//             // Initialiser les Livres avec relations
//             Livres.AddRange(new List<Livre>
//             {
//                 new Livre { Id = 1, Titre = "Le Seigneur des Anneaux", Type = TypeLivre.Fantaisie, Auteurs = { Auteurs[0] }, Categories = { Categories[0], Categories[2] } },
//                 new Livre { Id = 2, Titre = "Fondation", Type = TypeLivre.Scientifique, Auteurs = { Auteurs[1] }, Categories = { Categories[1] } },
//                 new Livre { Id = 3, Titre = "Dune", Type = TypeLivre.Scientifique, Auteurs = { Auteurs[2] }, Categories = { Categories[1] } },
//                 new Livre { Id = 4, Titre = "Harry Potter à l'école des sorciers", Type = TypeLivre.Fantaisie, Auteurs = { Auteurs[3] }, Categories = { Categories[0], Categories[4] } },
//                 new Livre { Id = 5, Titre = "Le Hobbit", Type = TypeLivre.Fantaisie, Auteurs = { Auteurs[0] }, Categories = { Categories[0], Categories[2] } },
//                 new Livre { Id = 6, Titre = "Les Robots", Type = TypeLivre.Scientifique, Auteurs = { Auteurs[1] }, Categories = { Categories[1] } },
//                 new Livre { Id = 7, Titre = "Le Trône de Fer", Type = TypeLivre.Fantaisie, Auteurs = { Auteurs[4] }, Categories = { Categories[0] } },
//                 new Livre { Id = 8, Titre = "Les Enfants de Dune", Type = TypeLivre.Scientifique, Auteurs = { Auteurs[2] }, Categories = { Categories[1] } },
//                 new Livre { Id = 9, Titre = "Harry Potter et la Chambre des Secrets", Type = TypeLivre.Fantaisie, Auteurs = { Auteurs[3] }, Categories = { Categories[0], Categories[4] } },
//                 new Livre { Id = 10, Titre = "Fondation et Empire", Type = TypeLivre.Scientifique, Auteurs = { Auteurs[1] }, Categories = { Categories[1] } }
//             });
//         }
//     }
// }

using BiblioManagement.Models;
using BiblioManagement.Models.Enums;
using Microsoft.EntityFrameworkCore; // Important pour utiliser le DbContext
using System.Linq;

namespace MyService.Data
{
    // On a besoin d'un DbContext pour cette classe. Pour le créer, on va devoir le passer en paramètre.
    // On crée un contexte temporaire juste pour pouvoir l'utiliser
    // La bonne manière de le faire est de le passer en paramètre (injection de dépendance)
    public class TempDbContext : DbContext
    {
        // 1. AJOUTER CE CONSTRUCTEUR
        // Ce constructeur accepte les options de configuration (venant de Program.cs)
        // et les passe à la classe de base DbContext.
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
        // On ne stocke plus de listes statiques ici.
        // La méthode prend maintenant le DbContext en paramètre.
        public static void Initialize(TempDbContext context)
        {
            // S'assure que la base de données est créée.
            context.Database.EnsureCreated();

            // Si la table Livres contient déjà des éléments, on ne fait rien.
            if (context.Livres.Any())
            {
                return; // La base a déjà été initialisée
            }

            // La logique d'ajout est la même, mais on utilise le contexte
            var auteurs = new[]
            {
                new Auteur { Nom = "Tolkien", Prenom = "J.R.R." },
                new Auteur { Nom = "Asimov", Prenom = "Isaac" },
                new Auteur { Nom = "Herbert", Prenom = "Frank" },
                new Auteur { Nom = "Rowling", Prenom = "J.K." },
                new Auteur { Nom = "Martin", Prenom = "George R.R." }
            };
            context.Auteurs.AddRange(auteurs);

            var categories = new[]
            {
                new Categorie { Nom = "Fantaisie" },
                new Categorie { Nom = "Science-Fiction" },
                new Categorie { Nom = "Aventure" }
            };
            context.Categories.AddRange(categories);

            var livres = new[]
            {
                new Livre { Titre = "Le Seigneur des Anneaux", Type = TypeLivre.Fantaisie, Auteurs = { auteurs[0] }, Categories = { categories[0], categories[2] } },
                new Livre { Titre = "Fondation", Type = TypeLivre.Scientifique, Auteurs = { auteurs[1] }, Categories = { categories[1] } },
                new Livre { Titre = "Dune", Type = TypeLivre.Scientifique, Auteurs = { auteurs[2] }, Categories = { categories[1] } },
                new Livre { Titre = "Harry Potter à l'école des sorciers", Type = TypeLivre.Fantaisie, Auteurs = { auteurs[3] }, Categories = { categories[0] } },
                new Livre { Titre = "Le Hobbit", Type = TypeLivre.Fantaisie, Auteurs = { auteurs[0] }, Categories = { categories[0], categories[2] } },
                new Livre { Titre = "Les Robots", Type = TypeLivre.Scientifique, Auteurs = { auteurs[1] }, Categories = { categories[1] } },
                new Livre { Titre = "Le Trône de Fer", Type = TypeLivre.Fantaisie, Auteurs = { auteurs[4] }, Categories = { categories[0] } },
            };
            context.Livres.AddRange(livres);

            // Très important : sauvegarder toutes les modifications en une seule transaction.
            context.SaveChanges();
        }
    }
}