using System;
using System.Collections.Generic;

namespace WebAdminHecsa.sqlModels
{
    public partial class CatMarca
    {
        public CatMarca()
        {
            CatCategoria = new HashSet<CatCategorium>();
        }

        public int IdMarca { get; set; }
        public string MarcaDesc { get; set; }
        public Guid IdProveedor { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdEstatusRegistro { get; set; }

        public virtual TblProveedor IdProveedorNavigation { get; set; }
        public virtual ICollection<CatCategorium> CatCategoria { get; set; }
    }
}
