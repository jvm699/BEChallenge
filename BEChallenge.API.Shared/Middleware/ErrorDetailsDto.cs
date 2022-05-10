using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BEChallenge.API.Shared.Middleware
{
    public class ErrorDetailsDto
    {
        #region Properties

        public String Message { get; set; }

        #endregion

        #region Methods

        public override String ToString()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            return JsonConvert.SerializeObject(this, settings);
        }

        #endregion
    }
}
