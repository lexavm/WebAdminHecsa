using System;
using System.Collections.Generic;

namespace WebAdminHecsa.sqlModels
{
    public partial class TblEmpresaFiscale
    {
        public TblEmpresaFiscale()
        {
            TblCotizacionGenerals = new HashSet<TblCotizacionGeneral>();
        }

        public Guid IdEmpresaFiscales { get; set; }
        public string NombreFiscal { get; set; }
        public string Rfc { get; set; }
        public string RegimenFiscal { get; set; }
        public string Calle { get; set; }
        public string CodigoPostal { get; set; }
        public string IdColonia { get; set; }
        public string Colonia { get; set; }
        public string LocalidadMunicipio { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public Guid IdEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdEstatusRegistro { get; set; }

        public virtual TblEmpresa IdEmpresaNavigation { get; set; }
        public virtual ICollection<TblCotizacionGeneral> TblCotizacionGenerals { get; set; }
    }
}
