using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdminHecsa.Models
{
    public class TblProveedorDirecciones
    {
        [Key]
        [Display(Name = "Id Proveedor Direcciones")]
        public int IdProveedorDirecciones { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "ID Tipo Direccion")]
        public int IdTipoDireccion { get; set; }

        
        [Display(Name = "Tipo Direccion")]
        public string TipoDireccionDesc { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Calle")]
        public string Calle { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
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

        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public Guid IdProveedor { get; set; }

        [Display(Name = "Nombre Proveedor")]
        public string NombreProveedor { get; set; }

        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus Registro")]
        public int IdEstatusRegistro { get; set; }
    }
}