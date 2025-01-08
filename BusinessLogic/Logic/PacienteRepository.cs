using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace BusinessLogic.Logic
{
    public class PacienteRepository : IPacienteRepository
    {
        public Task<Paciente> GetPacienteByIdAsync(int IdMedico)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Paciente>> GetPacientesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
