using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace BusinessLogic.Logic
{
    public class TiposImagenRepository : ITiposImagenRepository
    {
        public Task<IReadOnlyList<TiposImagen>> GetTiposImagenAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TiposImagen> GetTiposImagenByIdAsync(int IdMedico)
        {
            throw new NotImplementedException();
        }
    }
}
