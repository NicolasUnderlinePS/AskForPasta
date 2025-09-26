namespace Application.AskForPasta.DTOs.Responses
{
    namespace Application.Common.Responses
    {
        public class GenericResponse<T>
        {
            public bool Success { get; set; }
            public int StatusCode { get; set; }
            public required string Message { get; set; }
            public T? Data { get; set; }
            public List<string> Errors { get; set; } = new();

            public static GenericResponse<T> Ok(T? data, string message = "")
            {
                return new GenericResponse<T>
                {
                    Success = true,
                    Message = message,
                    Data = data
                };
            }

            public static GenericResponse<T> Fail(string message, List<string>? errors = null)
            {
                return new GenericResponse<T>
                {
                    Success = false,
                    Message = message,
                    Errors = errors ?? new List<string>()
                };
            }

            public bool IsInvalidReturn()
            {
                return (Success == false || Data == null);
            }
        }
    }

}
