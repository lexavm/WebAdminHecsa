using System;
using System.Collections.Generic;

namespace WebAdminHecsa.sqlModels
{
    public partial class CatTiposEstatus
    {
        public int IdTipoEstatus { get; set; }
        public string TipoEstatusDesc { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdEstatusRegistro { get; set; }
    }
}
