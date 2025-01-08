using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Medico : ClaseBase
    {
        public int IdMedico { get; set; }
        public Medic Medic { get; set; }
        public string NombreMedico {  get; set; }
        public string ApellidoMedico { get; set; }
        public int EdadMedico { get; set; }
        public string IdentificacionMedico { get; set; }
        public string TelefonoMedico { get; set; }
        public string EspecialidadMedico { get; set; }
        public string CelularMedico { get; set; }
        public string CorreoMedico { get; set; }
        public bool EstatusMedico { get; set; }
        public decimal Tarifa { get; set; }
        public DateTime usuarioCreacion { get; set; }
        public DateTime fechaDeCreacion { get; set; }
        public DateTime usuarioModificacion { get; set; }
        public DateTime fechaDeModificacion { get; set; }
    }
}
