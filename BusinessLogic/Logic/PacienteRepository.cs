using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Data;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Logic
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ConsultorioDbContext _context;
        public PacienteRepository(ConsultorioDbContext context)
        {
            _context = context;
        }
        public async Task<Paciente> GetPacienteByIdAsync(int IdPaciente)
        {
            return await _context.Paciente.FindAsync(IdPaciente);
            //.Include(c => c.Citas)
            //.FirstOrDefaultAsync(m => m.IdMedico == IdMedico);
        }

        public async Task<IReadOnlyList<Paciente>> GetPacientesAsync()
        {
            return await _context.Paciente.ToListAsync();
            //.Include(c => Citas)
            //.ToListAsync();
        }
    }
}
