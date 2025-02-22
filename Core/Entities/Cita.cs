#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Core.Entities
{
    [Table("Citas")]
    public class Cita : ClaseBase
    {
        [Key]
        public int IdCita { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico {get; set;}
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

        [ForeignKey(nameof(IdPaciente))]
        public virtual Paciente Paciente {get;set;}

        [ForeignKey(nameof(IdMedico))]
        public virtual Medico Medico { get; set; }
    }
}
