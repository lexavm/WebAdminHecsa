using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdminHecsa.Models
{
    public class CatGenero
    {
        [Key]
        [Display(Name = "ID Género")]
        public int IdGenero { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Género Descripción")]
        public string GeneroDesc { get; set; }

        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus Registro")]
        public int IdEstatusRegistro { get; set; }
    }
}