using System.Text.Json;

namespace GCP_SA_POC.Models
{
    public class JsonWithoutUnderscorePolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            return name.Replace("_", "");
        }
    }
}
