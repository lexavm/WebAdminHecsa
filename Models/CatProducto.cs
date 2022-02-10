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

        [Display(Name = "Codigo Interno")]
        public string CodigoInterno { get; set; }

        [Display(Name = "Codigo Externo")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string CodigoExterno { get; set; }

        [Display(Name = "Id Marca")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdMarca { get; set; }

        [Display(Name = "Marca Descripcion")]
        public string MarcaDesc { get; set; }

        [Display(Name = "Id Categoria")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdCategoria { get; set; }

        [Display(Name = "Categoria Descripcion")]
        public string CategoriaDesc { get; set; }

        [Display(Name = "Descripcion Producto")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string DescProducto { get; set; }

        [Display(Name = "Cantidad Minima")]
        public int CantidadMinima { get; set; }

        [Display(Name = "Cantidad Inicial")]
        public string CantidadInicial { get; set; }

        [Display(Name = "Producto Precio")]
        public string ProductoPrecio { get; set; }

        [Display(Name = "Porcentaje Ganancia")]
        public string PorcentajeGanancia { get; set; }

        [Display(Name = "Porcentaje Venta")]
        public string PorcentajeVenta { get; set; }

        [Display(Name = "Sub Costo")]
        public string SubCosto { get; set; }

        [Display(Name = "Costo")]
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