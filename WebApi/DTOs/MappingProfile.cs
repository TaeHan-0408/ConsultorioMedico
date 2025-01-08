using AutoMapper;
using Core.Entities;

namespace WebApi.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Sirve como configuracion basica de automapper para mappear medico a MedicoDTO
            // Si necesitas mapear una propiedad específica con un nombre distinto:
            // Por ejemplo, mapear "NombreMedico" en Medico a "Nombre" en MedicoDTO:
            // .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.NombreMedico));
            CreateMap<Medico, MedicoDTO>();
            //.ForMember(m => m.NombreMedico, x => x.MapFrom(a => a.NombreMedico));

        }
    }
}
