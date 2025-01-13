using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class MedicoSpecificationParams
    {
        public int? InfoMedico { get; set; }
        public string? Sort { get; set; }
        public int pageIndex { get; set; } = 1;
        private const int maxPageize = 50;
        private int _pageSize = 3;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageize) ? maxPageize : value;
        }

        public string? Busqueda {  get; set; }
    }
}
