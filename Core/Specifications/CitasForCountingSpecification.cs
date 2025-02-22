using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class CitasForCountingSpecification : BaseSpecification<Cita>
    {
        public CitasForCountingSpecification(CitasSpecificationParams citasParams)
    : base(x =>
    (string.IsNullOrEmpty(citasParams.Busqueda) || x.IdPaciente == citasParams.IdPaciente || x.IdMedico == citasParams.IdMedico) &&
    (!citasParams.InfoCitas.HasValue || x.IdCita == citasParams.InfoCitas)
    )
        {

        }
    }
}
