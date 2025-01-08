using Core.Entities;

namespace WebApi.DTOs
{
    public class MedicoDTO
    {
        public int IdMedico { get; set; }
        public Medic Medic { get; set; }
        public string NombreMedico { get; set; }
        public string ApellidoMedico { get; set; }
        public int EdadMedico { get; set; }
        public string IdentificacionMedico { get; set; }
        public string TelefonoMedico { get; set; }
        public string EspecialidadMedico { get; set; }
        public string CelularMedico { get; set; }
        public string CorreoMedico { get; set; }
        public bool EstatusMedico { get; set; }
        public decimal Tarifa { get; set; }
    }
}
