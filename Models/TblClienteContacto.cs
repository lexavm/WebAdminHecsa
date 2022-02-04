using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdminHecsa.Models
{
    public class TblClienteContacto
    {
        [Key]
        public int IdClienteContacto { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Nombre Contacto")]
        public string NombreClienteContacto { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Correo Electrónico")]
        [DataType(DataType.EmailAddress)]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }

        public Guid IdCliente { get; set; }

        [Display(Name = "Nombre Cliente")]
        public string NombreCliente { get; set; }

        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus Registro")]
        public int IdEstatusRegistro { get; set; }
    }
}