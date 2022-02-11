using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdminHecsa.Models
{
    public class TblCotizacionGeneral
    {
        [Key]
        public Guid IdCotizacionGeneral { get; set; }

        [Display(Name = "Numero Cotizacion")]
        public string NumeroCotizacion { get; set; }

        #region EmpresaFiscales

        [Display(Name = "Empresa Fiscales")]
        public Guid IdEmpresaFiscales { get; set; }

        [Display(Name = "Nombre Fiscal")]
        public string NombreFiscal { get; set; }

        [Display(Name = "Empresa Generales")]
        public string EmpresaGeneral { get; set; }

        [Display(Name = "Empresa Contacto")]
        public string EmpresaContacto { get; set; }

        #endregion EmpresaFiscales

        #region Cliente
        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Campo Requerido")]
        public Guid IdCliente { get; set; }

        [Display(Name = "Nombre Cliente")]
        public string NombreCliente { get; set; }

        [Display(Name = "RFC Cliente")]
        public string RFCCliente { get; set; }

        [Display(Name = "Medios Cliente")]
        public string MediosCliente { get; set; }

        [Display(Name = "Direccion Cliente")]
        public string DireccionCliente { get; set; }

        [Display(Name = "Direccion Contacto")]
        public string DireccionContacto { get; set; }

        [Display(Name = "Cliente Contacto")]
        public string ClienteContacto { get; set; }

        #endregion Cliente

        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus Registro")]
        public int IdEstatusRegistro { get; set; }
    }
}