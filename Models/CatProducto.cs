using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdminHecsa.Models
{
    public class CatProducto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdProducto")]
        [Display(Name = "ID Producto")]
        public int IdProducto { get; set; }

        public string CodigoInterno { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public string CodigoExterno { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public int IdMarca { get; set; }

        public string MarcaDesc { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public int IdCategoria { get; set; }

        public string CategoriaDesc { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public string DescProducto { get; set; }

        public int CantidadMinima { get; set; }

        public string CantidadInicial { get; set; }

        public string ProductoPrecio { get; set; }

        public string PorcentajeGanancia { get; set; }

        public string PorcentajeVenta { get; set; }

        public string SubCosto { get; set; }

        public string Costo { get; set; }

        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }

        [Column("IdEstatusRegistro")]
        [Display(Name = "Estatus Registro")]
        public int IdEstatusRegistro { get; set; }
    }
}