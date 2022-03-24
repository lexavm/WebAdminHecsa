using System;
using System.Collections.Generic;

namespace WebAdminHecsa.sqlModels
{
    public partial class TblUsuario
    {
        public Guid IdUsuario { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NombreUsuario { get; set; }
        public Guid IdEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public int IdArea { get; set; }
        public int IdGenero { get; set; }
        public int IdPerfil { get; set; }
        public int IdRol { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CorreoAcceso { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdEstatusRegistro { get; set; }

        public virtual CatArea IdAreaNavigation { get; set; }
        public virtual CatGenero IdGeneroNavigation { get; set; }
        public virtual CatPerfile IdPerfilNavigation { get; set; }
        public virtual CatRole IdRolNavigation { get; set; }
    }
}
