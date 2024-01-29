using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crud_full.Models
{
    [Table("employe")]  // Spécifie le nom de la table
    public class Employe
    {
        [Key]
        public int idemploye { get; set; }
        public string nom { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime datenaissance { get; set; }

        [ForeignKey("iddept")]
        public Departement Departement { get; set; }
    }
}
