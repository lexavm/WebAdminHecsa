using System;
using System.Collections.Generic;

namespace WebAdminHecsa.sqlModels
{
    public partial class CatCategorium
    {
        public CatCategorium()
        {
            CatProductos = new HashSet<CatProducto>();
        }

        public int IdCategoria { get; set; }
        public string CategoriaDesc { get; set; }
        public int IdMarca { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdEstatusRegistro { get; set; }

        public virtual CatMarca IdMarcaNavigation { get; set; }
        public virtual ICollection<CatProducto> CatProductos { get; set; }
    }
}
