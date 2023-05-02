namespace WorkTimeTracker.Grpc.Models
{
    public class ApiException
    {
        public ApiException(string message, string details = null)
        {
            Message = message;
            Details = details;
        }

        public string Message { get; set; }
        public string Details { get; set; }
    }
}
