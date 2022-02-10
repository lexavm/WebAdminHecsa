using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdminHecsa.Models
{
    public class CatMarca
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdMarca")]
        [Display(Name = "Id Marca")]
        public int IdMarca { get; set; }

        [Column("MarcaDesc")]
        [Display(Name = "Marca Descripción")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Campo Requerido")]
        public string MarcaDesc { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public Guid IdProveedor { get; set; }

        [Display(Name = "Proveedor")]
        public string ProveedorDesc { get; set; }

        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }

        [Column("IdEstatusRegistro")]
        [Display(Name = "Estatus Registro")]
        public int IdEstatusRegistro { get; set; }
    }
}