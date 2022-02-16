using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAdminHecsa.Models;
using System;

namespace WebAdminHecsa.Data.Configuracion
{
    public class EstatusConfiguracion : IEntityTypeConfiguration<CatEstatus>
    {
        public void Configure(EntityTypeBuilder<CatEstatus> builder)
        {
            builder.HasKey(e => e.IdEstatus);

            builder.Property(e => e.IdEstatus).HasColumnName("IdEstatus");

            builder.Property(e => e.EstatusDesc)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.HasData(
                   new CatEstatus { IdEstatus = 1, EstatusDesc = "ACTIVO", FechaRegistro = DateTime.Now, IdEstatusRegistro = 1 },
                   new CatEstatus { IdEstatus = 2, EstatusDesc = "DESACTIVO", FechaRegistro = DateTime.Now, IdEstatusRegistro = 1 }
                  );
        }
    }
}
