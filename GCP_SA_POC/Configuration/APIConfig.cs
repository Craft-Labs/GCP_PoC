using GCP_SA_POC.Models;

namespace GCP_SA_POC.Configuration
{
    public class APIConfig
    {
        public string? GCPApiKey { get; set; }
        public string? GCPProjectId { get; set; }
        public ServiceAccountCredentials? SACredentials { get; set; }
    }
}
