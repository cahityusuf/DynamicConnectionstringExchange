namespace DynamicConnectionstringExchangeApi.Models
{
    public class ResponseModel<T>
    {
        public ResponseModel(T data, string message)
        {
            Data = data;
            Message = message;
        }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}
