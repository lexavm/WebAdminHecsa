using System;
using System.Collections.Generic;

namespace WebAdminHecsa.sqlModels
{
    public partial class TblProveedorContacto
    {
        public int IdProveedorContacto { get; set; }
        public int IdPerfil { get; set; }
        public string NombreProveedorContacto { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public string TelefonoMovil { get; set; }
        public Guid IdProveedor { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdEstatusRegistro { get; set; }

        public virtual TblProveedor IdProveedorNavigation { get; set; }
    }
}
