using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdminHecsa.sqlModels
{
    public partial class CatEstatus
    {
        public CatEstatus()
        {
            TblEmpresas = new HashSet<TblEmpresa>();
        }
        [Key]
        [Display(Name = "Estatus")]
        public int IdEstatusRegistro { get; set; }

        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Campo Requerido")]
        public string EstatusDesc { get; set; }
        
        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }

        public virtual ICollection<TblEmpresa> TblEmpresas { get; set; }
    }
}
