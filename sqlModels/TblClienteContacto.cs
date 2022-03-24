using System;
using System.Collections.Generic;

namespace WebAdminHecsa.sqlModels
{
    public partial class TblClienteContacto
    {
        public int IdClienteContacto { get; set; }
        public int IdPerfil { get; set; }
        public string NombreClienteContacto { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public string TelefonoMovil { get; set; }
        public Guid IdCliente { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdEstatusRegistro { get; set; }

        public virtual TblCliente IdClienteNavigation { get; set; }
    }
}
