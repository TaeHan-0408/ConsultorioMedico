using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Citas
    {
        public int IdCita { get; set; }
        public int IdPaciente { get; set; } //Me va a tocar llamar con la clase de Paciente luego
        public int IdMedico { get; set; } //Lo mismo que arriba
        public bool PrimeraVez { get; set; }
        public string Motivo { get; set; }
        public string DescripcionDiagnostico {  get; set; }
        public string DescripcionTratamiento {  get; set; }
        public string DescripcionEvolucion {  get; set; }
        public bool Estatus { get; set; }
        public DateTime Fecha {  get; set; }
        public DateTime CitaCreacion { get; set; }
        public DateTime FechaCreacionCita { get; set; }
        public DateTime CitaModificacion { get; set; }
        public DateTime FechaModificacionCita { get; set; }
    }
}
