namespace WebApi.Errors
{
    public class CodeErrorException : CodeErrorResponse
    {
        public CodeErrorException(int statusCode, string message = null, string details = null) : base(statusCode, message)
        {
            details = details;
        }
        public string details { get; set; }
    }
}
