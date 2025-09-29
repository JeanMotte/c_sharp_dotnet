using BiblioManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace MyProgramEFCore.Data
{
    public class LibraryContext : DbContext
    {
        // Les DbSet représentent les tables qui seront créées en base de données.
        public DbSet<Livre> Livres => Set<Livre>();
        public DbSet<Auteur> Auteurs => Set<Auteur>();
        public DbSet<Categorie> Categories => Set<Categorie>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // On configure le contexte pour utiliser une base de données en mémoire.
            // Le nom "BiblioDb" est arbitraire et identifie cette base de données en mémoire.
            optionsBuilder.UseInMemoryDatabase("BiblioDb");

            // Si vous vouliez passer à PostgreSQL, vous commenteriez la ligne du dessus
            // et décommenteriez celle-ci (en vous assurant que la chaîne de connexion est correcte).
            // optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=BiblioFb;Username=user;Password=1234");
        }
    }
}