namespace Shared.Common
{
    public class OsinergminException : Exception
    {
        public string CodeError { get; }
        public int StatusCode { get; }
        public OsinergminException(
            string? message, 
            string codeError = "-1", 
            int statusCode = 503) :
            base( message ?? OsinermingErrorCatalog.GetMessage(codeError))
        {
            CodeError = codeError;
            StatusCode = statusCode;
        }
    }
}
