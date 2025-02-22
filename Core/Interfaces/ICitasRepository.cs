using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ICitasRepository
    {
        Task<Cita> GetCitaByIdAsync(int IdCita);

        Task<IReadOnlyList<Cita>> GetCitasAsync();
    }
}
