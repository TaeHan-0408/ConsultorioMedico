using AutoMapper;
using BusinessLogic.Logic;
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
    public class PacienteController : ControllerBase
    {
        private readonly IGenericRepository<Paciente> _pacienteRepository;
        private readonly IMapper _mapper;

        public PacienteController(IGenericRepository<Paciente> pacienteRepository, IMapper mapper)
        {
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Paginacion<PacienteDTO>>> GetPacientes([FromQuery]PacienteSpecificationParams pacienteParams)
        {
            var spec = new PacientesGetAllSpecification(pacienteParams);
            var pacientes = await _pacienteRepository.GetAllWithSpec(spec);

            var specContar = new PacientesForCountingSpecification(pacienteParams);
            var totalPacientes = await _pacienteRepository.CountAsync(specContar);

            var redondeo = Math.Ceiling(Convert.ToDecimal(totalPacientes / pacienteParams.PageSize));
            var totalPaginas = Convert.ToInt32(redondeo);

            var data = _mapper.Map<IReadOnlyList<Paciente>, IReadOnlyList<PacienteDTO>>(pacientes);

            return Ok
                (
                    new Paginacion<PacienteDTO>
                    {
                        Count = totalPacientes,
                        Data = data,
                        CantidadPaginas = totalPaginas,
                        PageIndex = pacienteParams.pageIndex,
                        PageSize = pacienteParams.PageSize
                    }
                );
        }

        [HttpGet("{IdPaciente}")]

        public async Task<ActionResult<PacienteDTO>> GetPaciente(int IdPaciente)
        {
            var spec = new PacienteByIdSpecification(IdPaciente);
            var paciente = await _pacienteRepository.GetByIdWithSpec(spec);
            if (paciente == null)
            {
                return NotFound(new CodeErrorResponse(404, "El producto no existe"));
            }

            return _mapper.Map<Paciente, PacienteDTO>(paciente);
        }
    }
}
