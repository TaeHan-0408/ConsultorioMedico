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
    public class CitasRepository : ICitasRepository
    {
        private readonly ConsultorioDbContext _context;
        public CitasRepository(ConsultorioDbContext context)
        {
            _context = context;
        }
        public async Task<Cita> GetCitaByIdAsync(int IdCita)
        {
            return await _context.Citas
            .Include(m => m.Medico)
            .Include(p => p.Paciente)
            .FirstOrDefaultAsync(m => m.IdCita == IdCita);
        }

        public async Task<IReadOnlyList<Cita>> GetCitasAsync()
        {
            var citas = await _context.Citas
            .Include(m => m.Medico)
            .Include(p => p.Paciente)
            .ToListAsync();
            return citas;
        }
    }
}
