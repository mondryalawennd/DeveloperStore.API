namespace DeveloperStore.WebAPI.Common
{
    public class ApiResponseWithData<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T Data { get; set; } 

        public static ApiResponseWithData<T> CreateSuccess(T data) =>
            new() { Success = true, Data = data, Message = null };
    }
}
