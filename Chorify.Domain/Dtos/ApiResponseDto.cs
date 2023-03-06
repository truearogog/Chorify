using System.Text.Json.Serialization;

namespace Chorify.Domain.Dtos
{
    public class ApiResponseDto
    {
        public bool Success { get; set; } = true;
        public string Error { get; set; } = string.Empty;
        [JsonIgnore] public string StackTrace { get; set; } = string.Empty;
        public object? Data { get; set; } = null;

        public ApiResponseDto() { }

        public ApiResponseDto(Action func, string? error = null)
        {
            try
            {
                func = func ?? throw new ArgumentNullException(nameof(func));
                func();
                Success = true;
            }
            catch (Exception ex)
            {
                Error = error ?? ex.InnerException?.Message ?? ex.Message;
                StackTrace = ex.InnerException?.StackTrace ?? ex.StackTrace;
                Success = false;
            }
        }

        public ApiResponseDto(Func<object?> func, string? error = null)
        {
            try
            {
                func = func ?? throw new ArgumentNullException(nameof(func));
                Data = func();
                Success = true;
            }
            catch (Exception ex)
            {
                Error = error ?? ex.InnerException?.Message ?? ex.Message;
                StackTrace = ex.InnerException?.StackTrace ?? ex.StackTrace;
                Success = false;
            }
        }
    }
}
