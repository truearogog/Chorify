using System.Text.Json.Serialization;

namespace Chorify.Domain.Dtos
{
    public class ApiResponseDto
    {
        public bool Success { get; set; } = true;
        public string Error { get; set; } = string.Empty;
        [JsonIgnore] public string StackTrace { get; set; } = string.Empty;
        public object? Data { get; set; } = null;

        private ApiResponseDto(Func<object?> func, string? error = null)
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

        public static ApiResponseDto Build(Func<object?> func, string? error = null)
        {
            return new ApiResponseDto(func, error);
        }

        private ApiResponseDto(Func<Task<object?>> func, CancellationToken cancellationToken, string? error = null)
        {
            try
            {
                func = func ?? throw new ArgumentNullException(nameof(func));
                var t = Task.Run(func, cancellationToken);
                Data = t.Result;
                Success = true;
            }
            catch (Exception ex)
            {
                Error = error ?? ex.InnerException?.Message ?? ex.Message;
                StackTrace = ex.InnerException?.StackTrace ?? ex.StackTrace;
                Success = false;
            }
        }

        public static async Task<ApiResponseDto> BuildAsync(Func<Task<object?>> func, CancellationToken? cancellationToken = null, string? error = null)
        {
            return await Task.Run(() => new ApiResponseDto(func, cancellationToken ?? CancellationToken.None, error));
        }
    }
}
