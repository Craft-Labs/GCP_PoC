using GCP_SA_POC.Configuration;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Iam.v1;
using Google.Apis.Iam.v1.Data;

using System.Xml.Linq;

namespace GCP_SA_POC.Services
{
    public class ServiceAccountsService
    {
        private readonly GoogleClientFactory googleClientFactory;
        private readonly APIConfig config;

        public ServiceAccountsService(GoogleClientFactory googleClientFactory, APIConfig config) {
            this.googleClientFactory = googleClientFactory;
            this.config = config;
        }

        public ServiceAccount CreateServiceAccount(CreateServiceAccountRequest request)
        {
            var clientService = googleClientFactory.GetClientService<IamService>(new[] { IamService.Scope.CloudPlatform });

            var serviceAccount = clientService.Projects.ServiceAccounts.Create(
                request, "projects/" + config.GCPProjectId).Execute();

            Console.WriteLine("Created service account: " + serviceAccount.Email);
            return serviceAccount;
        }
    }
}
