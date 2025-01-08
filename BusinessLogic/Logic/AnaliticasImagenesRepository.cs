using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace BusinessLogic.Logic
{
    public class AnaliticasImagenesRepository : IAnaliticasImagenesRepository
    {
        public Task<IReadOnlyList<AnaliticasImagenes>> GetAnaliticasImagenesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AnaliticasImagenes> GetAnaliticasImageneByIdAsync(int IdAnaliticasImagenes)
        {
            throw new NotImplementedException();
        }
    }
}
