namespace Ums.Domain.Settings
{
    public class AzureAd
    {
        public string Instance { get; set; }

        public string TenantId { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string GraphResource { get; set; }
    }
}