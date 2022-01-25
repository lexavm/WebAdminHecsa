using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdminHecsa.Models
{
    public class CatCodigosPostales
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdCodigosPostales")]
        [Display(Name = "ID IdCodigosPostales")]
        public int IdCodigosPostales { get; set; }

        [MaxLength(10)]
        public string d_codigo { get; set; }

        [MaxLength(300)]
        public string d_asenta { get; set; }

        [MaxLength(300)]
        public string d_tipo_asenta { get; set; }

        [MaxLength(300)]
        public string D_mnpio { get; set; }

        [MaxLength(300)]
        public string d_estado { get; set; }

        [MaxLength(300)]
        public string d_ciudad { get; set; }

        [MaxLength(10)]
        public string d_CP { get; set; }

        [MaxLength(10)]
        public string c_estado { get; set; }

        [MaxLength(10)]
        public string c_oficina { get; set; }

        [MaxLength(10)]
        public string c_CP { get; set; }

        [MaxLength(10)]
        public string c_tipo_asenta { get; set; }

        [MaxLength(10)]
        public string c_mnpio { get; set; }

        [MaxLength(10)]
        public string id_asenta_cpcons { get; set; }

        [MaxLength(300)]
        public string d_zona { get; set; }

        [MaxLength(10)]
        public string c_cve_ciudad { get; set; }
    }
}