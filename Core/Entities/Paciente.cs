using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Paciente
    {
        public int IdPaciente { get; set; }
        public string NombrePaciente { get; set; }
        public string ApellidoPaciente { get; set; }
        public int EdadPaciente { get; set; }
        public string TelefonoPaciente { get; set; }
        public string CelularPaciente { get; set; }
        public string IdentificacionPaciente { get; set; }
        public string SeguroMedico { get; set; }
        public string DireccionPaciente { get; set; }
        public int AseguradoraPaciente { get; set; }
        public DateTime FechaNacimientoPaciente { get; set; }
        public bool EstatusPaciente { get; set; }
        public string CorreoPaciente { get; set; }
        public string ContactosPaciente { get; set; }
        public string CelularContactoPaciente { get; set; }
        public string CorreoContactoPaciente { get; set; }
        public DateTime UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime UsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
