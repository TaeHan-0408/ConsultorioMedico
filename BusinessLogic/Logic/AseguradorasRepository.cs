using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace BusinessLogic.Logic
{
    public class AseguradorasRepository : IAseguradorasRepository
    {
        public Task<IReadOnlyList<Aseguradoras>> GetAseguradorasAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Aseguradoras> GetAseguradoraByIdAsync(int IdAseguradora)
        {
            throw new NotImplementedException();
        }
    }
}
