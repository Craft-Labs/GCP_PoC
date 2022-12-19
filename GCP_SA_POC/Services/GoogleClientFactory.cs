using GCP_SA_POC.Configuration;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Iam.v1;
using Google.Apis.Services;

namespace GCP_SA_POC.Services
{
    public class GoogleClientFactory
    {
        private readonly APIConfig config;

        public GoogleClientFactory(APIConfig config) {
            this.config = config;
        }

        public T GetClientService<T>(string[] scopes) where T : BaseClientService
        {
            ServiceAccountCredential credential = new(
              new ServiceAccountCredential.Initializer(config.SACredentials!.ClientEmail)
              {
                  Scopes = scopes
              }.FromPrivateKey(config.SACredentials.PrivateKey));

            var service = (T)Activator.CreateInstance(typeof(T), new BaseClientService.Initializer
            {
                HttpClientInitializer = credential
            })!;

            return service;
        }
    }
}
