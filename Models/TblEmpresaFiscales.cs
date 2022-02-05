using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdminHecsa.Models
{
    public class TblEmpresaFiscales
    {
        [Key]
        [Display(Name = "Id Empresa Fiscales")]
        public Guid IdEmpresaFiscales { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Nombre Fiscal")]
        public string NombreFiscal { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "RFC")]
        public string RFC { get; set; }

        [Display(Name = "Regimen Fiscal")]
        public string RegimenFiscal { get; set; }

        [Display(Name = "Calle")]
        public string Calle { get; set; }

        [Display(Name = "Codigo Postal")]
        public string CodigoPostal { get; set; }

        [Display(Name = "IdColonia")]
        public string IdColonia { get; set; }

        [Display(Name = "Colonia")]
        public string Colonia { get; set; }

        [Display(Name = "Localidad / Municipio")]
        public string LocalidadMunicipio { get; set; }

        [Display(Name = "Ciudad")]
        public string Ciudad { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Correo Electrónico")]
        [DataType(DataType.EmailAddress)]
        public string CorreoElectronico { get; set; }

        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }
        public Guid IdEmpresa { get; set; }

        [Display(Name = "Nombre Cliente")]
        public string NombreEmpresa { get; set; }

        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus Registro")]
        public int IdEstatusRegistro { get; set; }
    }
}