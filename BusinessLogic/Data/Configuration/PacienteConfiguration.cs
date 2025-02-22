using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Data.Configuration
{
    public class PacienteConfiguration
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.Property(m => m.IdPaciente).IsRequired();
            builder.Property(m => m.NombrePaciente).IsRequired().HasMaxLength(250);
            builder.Property(m => m.ApellidoPaciente).IsRequired().HasMaxLength(250);
        }
    }
}
