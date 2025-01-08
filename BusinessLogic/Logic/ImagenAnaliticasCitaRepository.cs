using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace BusinessLogic.Logic
{
    public class ImagenAnaliticasCitaRepository : IImagenAnaliticasCitaRepository
    {
        public Task<ImagenAnaliticasCita> GetImagenAnaliticasCitaByIdAsync(int IdDeAnalitica)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<ImagenAnaliticasCita>> GetImagenAnaliticasCitasAsync()
        {
            throw new NotImplementedException();
        }
    }
}
