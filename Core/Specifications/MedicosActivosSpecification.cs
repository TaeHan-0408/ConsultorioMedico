using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class MedicosActivosSpecification : BaseSpecification<Medico>
    {
        public MedicosActivosSpecification() : base(m => m.EstatusMedico == true) // Medicos Activos
        {
            AddOrderBy(m => m.NombreMedico);
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

 
 */