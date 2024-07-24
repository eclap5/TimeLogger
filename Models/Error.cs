namespace TimeLogger.Models
{
    public class Error
    {
        public string? StatusCode { get; set; }
        public string? Message { get; set; }
        public string? StackTrace { get; set; }
        public string? InstanceId { get; set; }
        public bool IsError { get; set; }
    }
}
