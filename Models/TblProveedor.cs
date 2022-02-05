using System;
using System.ComponentModel.DataAnnotations;

namespace WebAdminHecsa.Models
{
    public class TblProveedor
    {
        [Key]
        [Display(Name = "Id Proveedor")]
        public Guid IdProveedor { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Nombre Proveedor")]
        public string NombreProveedor { get; set; }

        [Display(Name = "RFC")]
        public string RFC { get; set; }

        [Display(Name = "Giro Comercial")]
        public string GiroComercial { get; set; }
        public Guid IdEmpresa { get; set; }

        [Display(Name = "NombreEmpresa")]
        public string NombreEmpresa { get; set; }

        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus Registro")]
        public int IdEstatusRegistro { get; set; }
    }
}