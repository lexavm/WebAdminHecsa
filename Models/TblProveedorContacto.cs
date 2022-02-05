using System;
using System.ComponentModel.DataAnnotations;

namespace WebAdminHecsa.Models
{
    public class TblProveedorContacto
    {
        [Key]
        public int IdProveedorContacto { get; set; }
        
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "ID Perfil")]
        public int IdPerfil { get; set; }

        [Display(Name = "Perfil Descripción")]
        public string PerfilDesc { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Nombre Contacto")]
        public string NombreProveedorContacto { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Correo Electrónico")]
        [DataType(DataType.EmailAddress)]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Teléfono Movil")]
        [DataType(DataType.PhoneNumber)]
        public string TelefonoMovil { get; set; }

        public Guid IdProveedor { get; set; }

        [Display(Name = "Nombre Proveedor")]
        public string NombreProveedor { get; set; }

        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus Registro")]
        public int IdEstatusRegistro { get; set; }
    }
}