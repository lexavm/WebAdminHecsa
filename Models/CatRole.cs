using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdminHecsa.Models
{
    public class CatRole
    {
        [Key]
        [Display(Name = "ID Rol")]
        public int IdRol { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Rol Descripción")]
        public string RolDesc { get; set; }

        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus Registro")]
        public int IdEstatusRegistro { get; set; }
    }
}