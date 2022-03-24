using System;
using System.Collections.Generic;

namespace WebAdminHecsa.sqlModels
{
    public partial class TblProveedorDireccione
    {
        public int IdProveedorDirecciones { get; set; }
        public int IdTipoDireccion { get; set; }
        public string Calle { get; set; }
        public string CodigoPostal { get; set; }
        public string IdColonia { get; set; }
        public string Colonia { get; set; }
        public string LocalidadMunicipio { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public Guid IdProveedor { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdEstatusRegistro { get; set; }

        public virtual TblProveedor IdProveedorNavigation { get; set; }
    }
}
