using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class PacientesGetAllSpecification : BaseSpecification<Paciente>
    {
        public PacientesGetAllSpecification(PacienteSpecificationParams pacienteParams)
    : base(x =>
    (string.IsNullOrEmpty(pacienteParams.Busqueda) || x.NombrePaciente.Contains(pacienteParams.Busqueda)) &&
    (!pacienteParams.InfoPaciente.HasValue || x.IdPaciente == pacienteParams.InfoPaciente)
    )
        {

            AplicarPaginado(pacienteParams.PageSize, pacienteParams.PageSize * (pacienteParams.pageIndex - 1));
            //AplicarPaginado(medicoParams.PageSize * (medicoParams.PageSize - 1), medicoParams.PageSize); -> El error...

            if (!string.IsNullOrEmpty(pacienteParams.Sort))
            {
                switch (pacienteParams.Sort)
                {
                    case "edadPacienteAscendente":
                        AddOrderBy(p => p.EdadPaciente);
                        break;
                    case "edadPacienteDescendente":
                        AddOrderByDescending(p => p.EdadPaciente);
                        break;
                    default:
                        AddOrderBy(p => p.NombrePaciente);
                        break;
                }
            }
        }
    }

    public class PacientesPorEstatusSpecification : BaseSpecification<Paciente>
    {
        public PacientesPorEstatusSpecification(string estatus)
            : base(p =>
                p.EstatusPaciente.ToString().ToLower() == estatus.ToLower()) //Para permitir que el EstatusPaciente pudiese ser comparado [Bool != String]
        {
            AddOrderBy(p => p.EstatusPaciente);
        }
    }


    public class PacienteByIdSpecification : BaseSpecification<Paciente>
    {
        public PacienteByIdSpecification(int IdPaciente) : base(p => p.IdPaciente == IdPaciente) // Filtro por Id del paciente
        {
            AddOrderBy(p => p.NombrePaciente);
        }
    }

    public class PacienteGetAllBySpecification : BaseSpecification<Paciente>
    {
        public PacienteGetAllBySpecification(DateTime UsuarioCreacion) : base(p => p.UsuarioCreacionPaciente == UsuarioCreacion) // Filtro por la fecha de creacion del paciente
        {
            AddOrderBy(p => p.NombrePaciente);
        }
    }
}

