using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CMS_HERA_MVC.Models
{
    public class Taxe
    {
        public int Id { get; set; }

        [StringLength(45)]
        public string Nom_Taxe { get; set; }
        public float Valeur_Taxe { get; set; }

        public int Status_Taxe { get; set; }

        [StringLength(45)]
        public string Taxe_Col { get; set; }
    }
}
