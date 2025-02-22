using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Data.Configuration
{
    public class CitasConfiguration
    {
        public void Configure(EntityTypeBuilder<Cita> builder)
        {
            builder.Property(m => m.IdCita).IsRequired();
            builder.Property(m => m.IdMedico).IsRequired();
            builder.Property(m => m.IdPaciente).IsRequired();
        }
    }
}
