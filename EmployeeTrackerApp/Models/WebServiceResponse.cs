namespace EmployeeTrackerApp.Models
{
    public record WebServiceResponse
    {
        public string Token { get; set; }
        public string Expires { get; set; }
    }
}
