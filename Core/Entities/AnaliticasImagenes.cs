using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class AnaliticasImagenes
    {
        public int IdAnaliticasImagenes { get; set; }
        public int IdPaciente { get; set; }
        public string Imagen { get; set; }
        public DateTime Fecha {  get; set; }
    }
}
