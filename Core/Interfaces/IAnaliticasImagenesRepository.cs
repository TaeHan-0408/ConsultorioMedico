using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IAnaliticasImagenesRepository
    {
        Task<AnaliticasImagenes> GetAnaliticasImageneByIdAsync(int IdAnaliticasImagenes);

        Task<IReadOnlyList<AnaliticasImagenes>> GetAnaliticasImagenesAsync();
    }
}
