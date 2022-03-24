using System;
using System.Collections.Generic;

namespace WebAdminHecsa.sqlModels
{
    public partial class CatProducto
    {
        public int IdProducto { get; set; }
        public string CodigoInterno { get; set; }
        public string CodigoExterno { get; set; }
        public int IdMarca { get; set; }
        public int IdCategoria { get; set; }
        public string DescProducto { get; set; }
        public int CantidadMinima { get; set; }
        public int Cantidad { get; set; }
        public decimal ProductoPrecioUno { get; set; }
        public decimal PorcentajePrecioUno { get; set; }
        public decimal SubCosto { get; set; }
        public decimal Costo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdEstatusRegistro { get; set; }

        public virtual CatCategorium IdCategoriaNavigation { get; set; }
    }
}
