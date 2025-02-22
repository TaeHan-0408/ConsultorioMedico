using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class PacientesForCountingSpecification : BaseSpecification<Paciente>
    {
        public PacientesForCountingSpecification(PacienteSpecificationParams pacienteParams)
        : base(x =>
        (string.IsNullOrEmpty(pacienteParams.Busqueda) || x.NombrePaciente.Contains(pacienteParams.Busqueda)) &&
        (!pacienteParams.InfoPaciente.HasValue || x.IdPaciente == pacienteParams.InfoPaciente)
        )
            {

            }
    }
}
