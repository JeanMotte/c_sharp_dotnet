using BiblioManagement.Models.Enums;
using System.Collections.Generic;

namespace BiblioManagement.Models
{
    public class Livre
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public TypeLivre Type { get; set; }

        // Relations
        public virtual ICollection<Auteur> Auteurs { get; set; } = new List<Auteur>();
        public virtual ICollection<Categorie> Categories { get; set; } = new List<Categorie>();
    }
}