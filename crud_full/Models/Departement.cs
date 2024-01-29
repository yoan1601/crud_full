using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crud_full.Models
{
    [Table("departement")]  // Spécifie le nom de la table
    public class Departement
    {
        [Key]
        public int iddept { get; set; }
        public string nomdept { get; set; }

    }
}
