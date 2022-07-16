using Newtonsoft.Json;

namespace ApiApplication.Tests.Models
{
    public class BuyEnergyRequest
    {

        [JsonProperty("id")]
        public int EnergyType { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
