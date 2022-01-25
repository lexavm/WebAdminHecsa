using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdminHecsa.Models
{
    public class CatPerfile
    {
        [Key]
        [Display(Name = "ID Perfil")]
        public int IdPerfil { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Perfil Descripción")]
        public string PerfilDesc { get; set; }

        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus Registro")]
        public int IdEstatusRegistro { get; set; }
    }
}