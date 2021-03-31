namespace FrontEnd.Models
{
    public class Resource
    {
        public ApiName ApiName { get; set; }

        public string Uri { get; set; }

        public string TargetClientId { get; set; }

        public string[] Scopes => new string[] { $"api://{TargetClientId.Trim()}/.default" };
    }
}