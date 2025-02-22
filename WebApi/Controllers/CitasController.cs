using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.Errors;

namespace WebApi.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class CitasController : ControllerBase
        {
            private readonly IGenericRepository<Cita> _citasRepository;
            private readonly IMapper _mapper;

            public CitasController(IGenericRepository<Cita> citasRepository, IMapper mapper)
            {
                _citasRepository = citasRepository;
                _mapper = mapper;
            }

            [HttpGet]
            public async Task<ActionResult<Paginacion<CitasDTO>>> GetCitas([FromQuery] CitasSpecificationParams citasParams)
            {
                var spec = new CitasGetAllSpecification(citasParams);
                var citas = await _citasRepository.GetAllWithSpec(spec);

                var specContar = new CitasForCountingSpecification(citasParams);
                var totalCitas = await _citasRepository.CountAsync(specContar);

                var redondeo = Math.Ceiling(Convert.ToDecimal(totalCitas / citasParams.PageSize));
                var totalPaginas = Convert.ToInt32(redondeo);

                var data = _mapper.Map<IReadOnlyList<Cita>, IReadOnlyList<CitasDTO>>(citas);

                return Ok
                    (
                        new Paginacion<CitasDTO>
                        {
                            Count = totalCitas,
                            Data = data,
                            CantidadPaginas = totalPaginas,
                            PageIndex = citasParams.pageIndex,
                            PageSize = citasParams.PageSize
                        }
                    );
            }

            [HttpGet("{IdCita}")]

            public async Task<ActionResult<CitasDTO>> GetCita(int IdCita)
            {
                var spec = new CitasByIdSpecification(IdCita);
                var citas = await _citasRepository.GetByIdWithSpec(spec);
                if (citas == null)
                {
                    return NotFound(new CodeErrorResponse(404, "El producto no existe"));
                }

                return _mapper.Map<Cita, CitasDTO>(citas);
            }
        }
}
