using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdminHecsa.Models
{
    public class TblCliente
    {
        [Key]
        [Display(Name = "Id Cliente")]
        public Guid IdCliente { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Nombre")]
        public string NombreCliente { get; set; }

        [Display(Name = "RFC")]
        public string RFC { get; set; }

        [Display(Name = "Giro Comercial")]
        public string GiroComercial { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Correo Electrónico")]
        [DataType(DataType.EmailAddress)]
        public string CorreoElectronico { get; set; }

        public Guid IdEmpresa { get; set; }

        [Display(Name = "NombreEmpresa")]
        public string NombreEmpresa { get; set; }

        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus Registro")]
        public int IdEstatusRegistro { get; set; }
    }
}