namespace WebApi.DTOs
{
    public class Paginacion<T> where T : class
    {
        public int Count { get; set; } //Representa la cantidad de elementos
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public IReadOnlyList<T> Data { get; set; } 
        public int CantidadPaginas { get; set; }   
    }
}
