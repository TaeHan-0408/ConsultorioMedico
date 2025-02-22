
namespace WebApi.DTOs
{
    public class CitasDTO
    {
        public int IdCita { get; set; }
        public string NombrePaciente { get; set; } = string.Empty;//Llamando a la variable desde su respectiva clase
        public string NombreMedico { get; set; } = string.Empty; //Llamando a la variable desde su respectiva clase
        public bool PrimeraVez { get; set; }
        public string Motivo { get; set; } = string.Empty;
        public string DescripcionDiagnostico { get; set; } = string.Empty;
        public string DescripcionTratamiento { get; set; } = string.Empty;
        public string DescripcionEvolucion { get; set; } = string.Empty;
        public bool Estatus { get; set; }
    }
}
