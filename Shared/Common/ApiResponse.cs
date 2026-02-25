using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Common
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public static ApiResponse<T> Ok(T data, string message = "Operación exitosa")
            => new ApiResponse<T>
            {
                Success = true,
                StatusCode = 200,
                Message = message,
                Data = data
            };

        public static ApiResponse<T> Fail(string message, int statusCode = 400, List<string>? errors = null)
            => new ApiResponse<T>
            {
                Success = false,
                StatusCode = statusCode,
                Message = message,
                Errors = errors
            };
    }
}
