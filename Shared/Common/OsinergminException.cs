using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Common
{
    public class OsinergminException : Exception
    {
        public string CodeError { get; }
        public int StatusCode { get; }
        public OsinergminException(string message, string codeError, int statusCode = 503) : base(OsinermingErrorCatalog.GetMessage(codeError))
        {
            CodeError = codeError;
            StatusCode = statusCode;
        }
    }
}
