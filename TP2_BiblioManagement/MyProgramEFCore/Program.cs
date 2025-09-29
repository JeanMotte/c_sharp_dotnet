using BiblioManagement.Models;
using BiblioManagement.Models.Enums;
using MyProgramEFCore.Data;
using System;
using System.Linq;

Console.WriteLine("--- Test de EF Core In-Memory ---");

// 'using' garantit que la connexion à la base de données est bien fermée à la fin du bloc.
using var context = new LibraryContext();

// S'assurer que la base de données est créée (ne fait rien si elle existe déjà)
context.Database.EnsureCreated();

// Vérifier si la base est vide avant d'ajouter des données
if (!context.Livres.Any())
{
    Console.WriteLine("La base de données est vide. Ajout de données de test...");
    var auteur = new Auteur { Nom = "Hugo", Prenom = "Victor" };
    var categorie = new Categorie { Nom = "Classique" };

    context.Livres.Add(new Livre
    {
        Titre = "Les Misérables",
        Type = TypeLivre.Historique,
        Auteurs = { auteur },
        Categories = { categorie }
    });

    // Sauvegarder les changements en base de données
    context.SaveChanges();
    Console.WriteLine("Données ajoutées !");
}
else
{
    Console.WriteLine("La base de données contient déjà des données.");
}

Console.WriteLine("\n--- Récupération des livres ---");
var livresEnBase = context.Livres.ToList();

foreach (var livre in livresEnBase)
{
    Console.WriteLine($"Livre trouvé : {livre.Titre} (ID: {livre.Id})");
}

Console.WriteLine("\nTest terminé.");