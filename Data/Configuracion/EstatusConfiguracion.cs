using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAdminHecsa.sqlModels;
using System;

namespace WebAdminHecsa.Data.Configuracion
{
    public class EstatusConfiguracion : IEntityTypeConfiguration<CatEstatus>
    {
        public void Configure(EntityTypeBuilder<CatEstatus> builder)
        {
            builder.HasKey(e => e.IdEstatusRegistro);

            builder.Property(e => e.IdEstatusRegistro).HasColumnName("IdEstatusRegistro");

            builder.Property(e => e.EstatusDesc)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.HasData(
                   new CatEstatus { IdEstatusRegistro = 1, EstatusDesc = "ACTIVO", FechaRegistro = DateTime.Now},
                   new CatEstatus { IdEstatusRegistro = 2, EstatusDesc = "DESACTIVO", FechaRegistro = DateTime.Now}
                  );
        }
    }
}
