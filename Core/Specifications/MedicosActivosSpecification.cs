using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
   public class MedicosGetAllSpecification : BaseSpecification<Medico>
    {
        public MedicosGetAllSpecification(MedicoSpecificationParams medicoParams) 
            : base(x => 
            (string.IsNullOrEmpty(medicoParams.Busqueda) || x.NombreMedico.Contains(medicoParams.Busqueda)) &&
            (!medicoParams.InfoMedico.HasValue || x.IdMedico == medicoParams.InfoMedico)
            )
        {

            AplicarPaginado(medicoParams.PageSize * (medicoParams.PageSize - 1), medicoParams.PageSize);

            if (!string.IsNullOrEmpty(medicoParams.Sort))
            {
                switch (medicoParams.Sort)
                {
                    case "tarifaAscendente":
                        AddOrderBy(p => p.Tarifa);
                        break;
                    case "tarifaDescendente":
                        AddOrderByDescending(p => p.Tarifa);
                        break;
                    default:
                        AddOrderBy(p => p.NombreMedico);
                        break;
                }
            }
        }
    }

    public class MedicosPorEspecialidadSpecification : BaseSpecification<Medico>
    {
        public MedicosPorEspecialidadSpecification(string Especialidad) : base(m => m.EspecialidadMedico == Especialidad) // Especialidad del medico
        {
            AddOrderBy(m => m.NombreMedico);
        }
    }

    public class MedicoByIdSpecification : BaseSpecification<Medico>
    {
        public MedicoByIdSpecification(int IdMedico) : base(m => m.IdMedico == IdMedico) // Filtro por Id del médico
        {
            AddOrderBy(m => m.NombreMedico);
        }
    }

    public class MedicoGetAllByUCSpecification : BaseSpecification<Medico>
    {
        public MedicoGetAllByUCSpecification(DateTime usuarioCreacion) : base(m => m.usuarioCreacion == usuarioCreacion) // Filtro por Id del médico
        {
            AddOrderBy(m => m.NombreMedico);
        }
    }
}

/*
Si la entidad Medico tiene alguna relación con otras entidades (por ejemplo, una especialidad o una lista de citas),
entonces puedes usar AddInclude() para esas propiedades de navegación. Por ejemplo:
 public class Medico
{
    public int IdMedico { get; set; }
    public string NombreMedico { get; set; }
    public Especialidad Especialidad { get; set; } // Propiedad de navegación
    public ICollection<Cita> Citas { get; set; } // Propiedad de navegación
}

 
Crear una nueva columna tipo bit llamada VacacionesMedico, por default sera 0 y recogera todos los datos con un getAll, 
y a la hora de llamar/mostrar datos ponemos la condicion de que si vacacionesMedico = 1 se desactiva la opcion de agendar.

Notas extra:
- 2 columnas de médicos, los activos salen en color normal, los de vacaciones en gris y a la hora de intentar acceder a esos medicos. 
Puedes hacer que sale un texto que diga "Este médico está de vacaciones"

*/