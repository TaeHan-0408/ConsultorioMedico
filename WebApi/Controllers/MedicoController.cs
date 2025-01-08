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
        public async Task<ActionResult<List<Medico>>> GetMedicos()
        {
            var spec = new MedicosActivosSpecification();
            var medicos = await _medicoRepository.GetAllWithSpec(spec);


            return Ok(_mapper.Map<IReadOnlyList<Medico>, IReadOnlyList<MedicoDTO>>(medicos));
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

