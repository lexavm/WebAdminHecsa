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

        [Display(Name = "Nombre(s)")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string Nombres { get; set; }
        [Display(Name = "Apellido Paterno")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string ApellidoPaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string ApellidoMaterno { get; set; }

        [Display(Name = "Nombre de Usuario")]
        public string NombreUsuario { get; set; }
        [Display(Name = "Id Empresa")]
        public Guid IdEmpresa { get; set; }

        [Display(Name = "NombreEmpresa")]
        public string NombreEmpresa { get; set; }
        [Display(Name = "ID Área")]
        public int IdArea { get; set; }
        [Display(Name = "ID Género")]
        public int IdGenero { get; set; }

        [Display(Name = "ID Perfil")]
        public int IdPerfil { get; set; }

        [Display(Name = "ID Rol")]
        public int IdRol { get; set; }

        [Column("FechaNacimiento")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; }


        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus Registro")]
        public int IdEstatusRegistro { get; set; }
    }
}