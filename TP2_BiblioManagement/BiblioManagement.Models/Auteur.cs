using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BiblioManagement.Models
{
    public class Auteur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        // Pour éviter les références circulaires lors de la sérialisation JSON
        [JsonIgnore]
        public virtual ICollection<Livre> Livres { get; set; } = new List<Livre>();
    }
}