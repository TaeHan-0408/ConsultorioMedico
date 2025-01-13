using AutoMapper;
using BusinessLogic.Logic;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.Errors;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly IGenericRepository<Medico> _medicoRepository;
        private readonly IMapper _mapper;

        public MedicoController(IGenericRepository<Medico> medicoRepository, IMapper mapper)
        {
            _medicoRepository = medicoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Paginacion<MedicoDTO>>> GetMedicos([FromQuery]MedicoSpecificationParams medicoParams)
        {
            var spec = new MedicosGetAllSpecification(medicoParams);
            var medicos = await _medicoRepository.GetAllWithSpec(spec);

            var specContar = new MedicosForCountingSpecification(medicoParams);
            var totalMedicos =  await _medicoRepository.CountAsync(specContar);

            var redondeo = Math.Ceiling(Convert.ToDecimal(totalMedicos / medicoParams.PageSize));
            var totalPaginas = Convert.ToInt32(redondeo);

            var data = _mapper.Map<IReadOnlyList<Medico>, IReadOnlyList<MedicoDTO>>(medicos);

            return Ok
                (
                    new Paginacion<MedicoDTO>
                    {
                        Count = totalMedicos,
                        Data = data,
                        CantidadPaginas = totalPaginas,
                        PageIndex = medicoParams.pageIndex,
                        PageSize = medicoParams.PageSize
                    }
                );
        }

        [HttpGet("{IdMedico}")]

        public async Task<ActionResult<MedicoDTO>> GetMedico (int IdMedico)
        {
            var spec = new MedicoByIdSpecification(IdMedico);
            var medico = await _medicoRepository.GetByIdWithSpec(spec);
            if (medico == null)
            {
                return NotFound(new CodeErrorResponse(404, "El producto no existe"));
            }

            return _mapper.Map<Medico, MedicoDTO>(medico);
        }
    }
}

