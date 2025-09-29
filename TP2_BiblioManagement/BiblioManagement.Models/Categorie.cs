using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BiblioManagement.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        [JsonIgnore]
        public virtual ICollection<Livre> Livres { get; set; } = new List<Livre>();
    }
}