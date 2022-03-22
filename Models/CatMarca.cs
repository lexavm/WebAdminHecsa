using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdminHecsa.Models
{
    public partial class CatMarca
    {
        public CatMarca()
        {
            Categorias = new HashSet<CatCategoria>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdMarca")]
        [Display(Name = "Id Marca")]
        public int IdMarca { get; set; }

        [Column("MarcaDesc")]
        [Display(Name = "Marca Descripción")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Campo Requerido")]
        public string MarcaDesc { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public Guid IdProveedor { get; set; }

        [NotMapped]
        [DataType(DataType.Text)]
        [Display(Name = "Proveedor")]
        public string ProveedorDesc { get; set; }

        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }

        [Column("IdEstatusRegistro")]
        [Display(Name = "Estatus Registro")]
        public int IdEstatusRegistro { get; set; }
        public virtual ICollection<CatCategoria> Categorias { get; set; }
    }
}