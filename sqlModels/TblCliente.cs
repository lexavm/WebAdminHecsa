using System;
using System.Collections.Generic;

namespace WebAdminHecsa.sqlModels
{
    public partial class TblCliente
    {
        public TblCliente()
        {
            TblClienteContactos = new HashSet<TblClienteContacto>();
            TblClienteDirecciones = new HashSet<TblClienteDireccione>();
        }

        public Guid IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string Rfc { get; set; }
        public string GiroComercial { get; set; }
        public Guid IdEmpresa { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdEstatusRegistro { get; set; }

        public virtual TblEmpresa IdEmpresaNavigation { get; set; }
        public virtual ICollection<TblClienteContacto> TblClienteContactos { get; set; }
        public virtual ICollection<TblClienteDireccione> TblClienteDirecciones { get; set; }
    }
}
