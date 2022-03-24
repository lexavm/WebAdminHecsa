using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdminHecsa.sqlModels
{
    public partial class CatTipoDireccion
    {
        public CatTipoDireccion()
        {
            TblClienteDirecciones = new HashSet<TblClienteDireccione>();
        }
        [Key]
        public int IdTipoDireccion { get; set; }
        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Campo Requerido")]
        public string TipoDireccionDesc { get; set; }
        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }
        [Display(Name = "Estatus")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdEstatusRegistro { get; set; }

        public virtual ICollection<TblClienteDireccione> TblClienteDirecciones { get; set; }
    }
}
