using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdminHecsa.Models
{
    public class CatCategoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdCategoria")]
        [Display(Name = "ID Categoria")]
        public int IdCategoria { get; set; }

        [Column("CategoriaDesc")]
        [Display(Name = "Categoria Descripción")]
        //[StringLength(60, MinimumLength = 100)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Campo Requerido")]
        public string CategoriaDesc { get; set; }

        [Display(Name = "Marca Descripcion")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdMarca { get; set; }

        //[NotMapped]
        [Display(Name = "Marca Descripcion")]
        [DataType(DataType.Text)]
        public string MarcaDesc { get; set; }

        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }

        [Column("IdEstatusRegistro")]
        [Display(Name = "Estatus Registro")]
        public int IdEstatusRegistro { get; set; }
    }
}