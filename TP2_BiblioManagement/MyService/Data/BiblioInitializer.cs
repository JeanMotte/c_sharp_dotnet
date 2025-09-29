using BiblioManagement.Models;
using BiblioManagement.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyService.Data
{
    public static class BiblioInitializer
    {
        public static List<Auteur> Auteurs { get; private set; } = new List<Auteur>();
        public static List<Categorie> Categories { get; private set; } = new List<Categorie>();
        public static List<Livre> Livres { get; private set; } = new List<Livre>();

        public static void Initialize()
        {
            // Si les données sont déjà initialisées, ne rien faire
            if (Livres.Any()) return;

            // Initialiser les Auteurs
            Auteurs.AddRange(new List<Auteur>
            {
                new Auteur { Id = 1, Nom = "Tolkien", Prenom = "J.R.R." },
                new Auteur { Id = 2, Nom = "Asimov", Prenom = "Isaac" },
                new Auteur { Id = 3, Nom = "Herbert", Prenom = "Frank" },
                new Auteur { Id = 4, Nom = "Rowling", Prenom = "J.K." },
                new Auteur { Id = 5, Nom = "Martin", Prenom = "George R.R." }
            });

            // Initialiser les Catégories
            Categories.AddRange(new List<Categorie>
            {
                new Categorie { Id = 1, Nom = "Fantaisie" },
                new Categorie { Id = 2, Nom = "Science-Fiction" },
                new Categorie { Id = 3, Nom = "Aventure" },
                new Categorie { Id = 4, Nom = "Roman Historique" },
                new Categorie { Id = 5, Nom = "Jeunesse" }
            });

            // Initialiser les Livres avec relations
            Livres.AddRange(new List<Livre>
            {
                new Livre { Id = 1, Titre = "Le Seigneur des Anneaux", Type = TypeLivre.Fantaisie, Auteurs = { Auteurs[0] }, Categories = { Categories[0], Categories[2] } },
                new Livre { Id = 2, Titre = "Fondation", Type = TypeLivre.Scientifique, Auteurs = { Auteurs[1] }, Categories = { Categories[1] } },
                new Livre { Id = 3, Titre = "Dune", Type = TypeLivre.Scientifique, Auteurs = { Auteurs[2] }, Categories = { Categories[1] } },
                new Livre { Id = 4, Titre = "Harry Potter à l'école des sorciers", Type = TypeLivre.Fantaisie, Auteurs = { Auteurs[3] }, Categories = { Categories[0], Categories[4] } },
                new Livre { Id = 5, Titre = "Le Hobbit", Type = TypeLivre.Fantaisie, Auteurs = { Auteurs[0] }, Categories = { Categories[0], Categories[2] } },
                new Livre { Id = 6, Titre = "Les Robots", Type = TypeLivre.Scientifique, Auteurs = { Auteurs[1] }, Categories = { Categories[1] } },
                new Livre { Id = 7, Titre = "Le Trône de Fer", Type = TypeLivre.Fantaisie, Auteurs = { Auteurs[4] }, Categories = { Categories[0] } },
                new Livre { Id = 8, Titre = "Les Enfants de Dune", Type = TypeLivre.Scientifique, Auteurs = { Auteurs[2] }, Categories = { Categories[1] } },
                new Livre { Id = 9, Titre = "Harry Potter et la Chambre des Secrets", Type = TypeLivre.Fantaisie, Auteurs = { Auteurs[3] }, Categories = { Categories[0], Categories[4] } },
                new Livre { Id = 10, Titre = "Fondation et Empire", Type = TypeLivre.Scientifique, Auteurs = { Auteurs[1] }, Categories = { Categories[1] } }
            });
        }
    }
}