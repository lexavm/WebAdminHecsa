using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdminHecsa.Models
{
    public class CatEstatus
    {
        [Key]
        [Display(Name = "ID Estatus")]
        public int IdEstatus { get; set; }

        [Display(Name = "Estatus Descripción")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Campo Requerido")]
        public string EstatusDesc { get; set; }

        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus Registro")]
        public int IdEstatusRegistro { get; set; }
    }
}
