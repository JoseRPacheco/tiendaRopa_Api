
namespace tiendaRopa_Api.Models
{
    public class ApiResponse<T>
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public void Success(int status, string message, T data)
        {
            Status = status;
            Message = message;
            Data = data;
        }

        public void Failed(int status, string message)
        { Status = status; Message = message; Data = default; }
    }
}
