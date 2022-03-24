using System;
using System.Collections.Generic;

namespace WebAdminHecsa.sqlModels
{
    public partial class TblCotizacionGeneral
    {
        public Guid IdCotizacionGeneral { get; set; }
        public string NumeroCotizacion { get; set; }
        public Guid IdEmpresaFiscales { get; set; }
        public string NombreFiscal { get; set; }
        public string EmpresaGeneral { get; set; }
        public string EmpresaContacto { get; set; }
        public Guid IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string Rfccliente { get; set; }
        public string MediosCliente { get; set; }
        public string DireccionCliente { get; set; }
        public string DireccionContacto { get; set; }
        public string ClienteContacto { get; set; }
        public int IdTiposEnvio { get; set; }
        public int IdDivisa { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdEstatusRegistro { get; set; }

        public virtual CatDivisa IdDivisaNavigation { get; set; }
        public virtual TblEmpresaFiscale IdEmpresaFiscalesNavigation { get; set; }
        public virtual CatTipoEnvio IdTiposEnvioNavigation { get; set; }
    }
}
