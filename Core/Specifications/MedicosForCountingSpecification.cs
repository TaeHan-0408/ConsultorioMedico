using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class MedicosForCountingSpecification : BaseSpecification<Medico>
    {
        public MedicosForCountingSpecification(MedicoSpecificationParams medicoParams) 
            : base(x =>
            (string.IsNullOrEmpty(medicoParams.Busqueda) || x.NombreMedico.Contains(medicoParams.Busqueda)) &&
            (!medicoParams.InfoMedico.HasValue || x.IdMedico == medicoParams.InfoMedico)
            )
        {
            
        }
    }
}
