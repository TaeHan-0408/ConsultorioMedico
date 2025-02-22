using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class CitasGetAllSpecification : BaseSpecification<Cita>
    {
        public CitasGetAllSpecification(CitasSpecificationParams citasParams)
    : base(x =>
    (string.IsNullOrEmpty(citasParams.Busqueda) || x.IdPaciente == citasParams.IdPaciente || x.IdMedico == citasParams.IdMedico) &&
    (!citasParams.InfoCitas.HasValue || x.IdCita == citasParams.InfoCitas)
    )
        {

            AplicarPaginado(citasParams.PageSize, citasParams.PageSize * (citasParams.pageIndex - 1));

            if (!string.IsNullOrEmpty(citasParams.Sort))
            {
                switch (citasParams.Sort)
                {
                    case "IdCitasAscendente":
                        AddOrderBy(c => c.IdCita);
                        break;
                    case "edadPacienteDescendente":
                        AddOrderByDescending(c => c.IdCita);
                        break;
                    default:
                        AddOrderBy(c => c.IdPaciente);
                        break;
                }
            }
        }
    }

    public class CitasByIdSpecification : BaseSpecification<Cita>
    {
        public CitasByIdSpecification(int IdCita) : base(c => c.IdCita == IdCita) // Filtro por Id del paciente
        {
            AddOrderBy(c => c.IdCita);
        }
    }

    public class CitasPorIdMedico : BaseSpecification<Cita>
    {
        public CitasPorIdMedico(int IdMedico) : base(c => c.IdMedico == IdMedico) // Filtro por Id del medico
        {
            AddOrderBy(c => c.IdMedico);
        }
    }


    public class CitasPacienteByIdSpecification : BaseSpecification<Cita>
    {
        public CitasPacienteByIdSpecification(int IdPaciente) : base(p => p.IdPaciente == IdPaciente) // Filtro por Id del paciente
        {
            AddOrderBy(c => c.IdPaciente);
        }
    }

    public class CitasGetAllBySpecification : BaseSpecification<Cita>
    {
        public CitasGetAllBySpecification(DateTime CitaCreacion) : base(c => c.CitaCreacion == CitaCreacion) // Filtro por la fecha de creacion de la cita
        {
            AddOrderBy(c => c.IdCita);
        }
    }
}
