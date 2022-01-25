using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdminHecsa.Models
{
    public class TblUsuario
    {
        [Key]
        [Display(Name = "Id Usuario")]
        public Guid IdUsuario { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Nombre")]
        public string NombreUsuario { get; set; }

        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus Registro")]
        public int IdEstatusRegistro { get; set; }
    }
}