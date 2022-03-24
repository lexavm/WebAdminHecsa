using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdminHecsa.sqlModels
{
    public partial class CatArea
    {
        public CatArea()
        {
            TblUsuarios = new HashSet<TblUsuario>();
        }
        [Key]
        public int IdArea { get; set; }

        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Campo Requerido")]
        public string AreaDesc { get; set; }
        public Guid IdEmpresa { get; set; }

        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdEstatusRegistro { get; set; }

        public virtual TblEmpresa IdEmpresaNavigation { get; set; }
        public virtual ICollection<TblUsuario> TblUsuarios { get; set; }
    }
}
