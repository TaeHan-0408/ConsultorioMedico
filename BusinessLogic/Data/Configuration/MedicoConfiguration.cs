using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Data.Configuration
{
    public class MedicoConfiguration : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.Property(m => m.IdMedico).IsRequired();
            builder.Property(m => m.NombreMedico).IsRequired().HasMaxLength(250);
            builder.Property(m => m.ApellidoMedico).IsRequired().HasMaxLength(250);
            builder.Property(m => m.Tarifa).HasColumnType("decimal(18,2)");
        }
    }
}
