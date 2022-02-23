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

        [Display(Name = "Minima")]
        public int CantidadMinima { get; set; }

        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        [Display(Name = "$ Uno")]
        public double ProductoPrecioUno { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        [Display(Name = "% Uno")]
        public double PorcentajePrecioUno { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        [Display(Name = "$ Dos")]
        public double ProductoPrecioDos { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        [Display(Name = "% Dos")]
        public double PorcentajePrecioDos { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        [Display(Name = "$ Tres")]
        public double ProductoPrecioTres { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        [Display(Name = "% Tres")]
        public double PorcentajePrecioTres { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        [Display(Name = "$ Cuatro")]
        public double ProductoPrecioCuatro { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        [Display(Name = "% Cuatro")]
        public double PorcentajePrecioCuatro { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        [Display(Name = "Sub Costo")]
        public double SubCosto { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        [Display(Name = "Costo")]
        public double Costo { get; set; }

        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }

        [Column("IdEstatusRegistro")]
        [Display(Name = "Estatus Registro")]
        public int IdEstatusRegistro { get; set; }
    }
}