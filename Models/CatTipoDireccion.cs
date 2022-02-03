using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdminHecsa.Models
{
    public class CatTipoDireccion
    {
        [Key]
        [Display(Name = "ID Tipo Dirección ")]
        public int IdTipoDireccion { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Tipos Dirección Descripción")]
        public string TipoDireccionDesc { get; set; }

        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus Registro")]
        public int IdEstatusRegistro { get; set; }
    }
}