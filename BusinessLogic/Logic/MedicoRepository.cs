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
    public class MedicoRepository : IMedicoRepository
    {
        private readonly ConsultorioDbContext _context;
        public MedicoRepository(ConsultorioDbContext context)
        {
            _context = context;
        }
        public async Task<Medico> GetMedicoByIdAsync(int IdMedico)
        {
            return await _context.Medico.FindAsync(IdMedico);
                            //.Include(c => c.Citas)
                            //.FirstOrDefaultAsync(m => m.IdMedico == IdMedico);
        }

        public async Task<IReadOnlyList<Medico>> GetMedicosAsync()
        {
            return await _context.Medico.ToListAsync();
                            //.Include(c => Citas)
                            //.ToListAsync();
        }
    }
}
