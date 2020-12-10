using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CMS_HERA_MVC.Models
{
    public class Role
    {
        [Key]
        public int id_role { get; set; }

        [Required(ErrorMessage = "Entrez le titre du role !!")]
        public string titre_role { get; set; }
        public string permissions { get; set; }
        public byte position_role { get; set; }
        public byte statut_role { get; set; }
        public DateTime? date_creation { get; set; }

        public int UserId { get; set; }
    }
}