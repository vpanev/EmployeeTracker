namespace EmployeeTrackerApp
{
    public static class Utils
    {
        private const string WebServiceURL = "http://localhost:51396/api/clients/subscribe";

        private const string CallBackURL = "https://localhost:44309/api/webhook";

        public static string Token = "";

        public static string GetWebServiceURL(string date)
        {
            return WebServiceURL + $"?date={date}&callback={CallBackURL}";
        }
    }
}
