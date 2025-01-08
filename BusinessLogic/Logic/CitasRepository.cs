using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace BusinessLogic.Logic
{
    public class CitasRepository : ICitasRepository
    {
        public Task<IReadOnlyList<Citas>> GetCitasAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Citas> GetCitaByIdAsync(int IdCita)
        {
            throw new NotImplementedException();
        }
    }
}
