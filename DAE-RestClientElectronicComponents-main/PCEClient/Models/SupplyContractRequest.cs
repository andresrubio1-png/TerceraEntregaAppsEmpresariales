using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PCEClient.Models
{
    public class SupplyContractRequest
    {
        [JsonProperty("contractNumber")]
        public string ContractNumber { get; set; }

        [JsonProperty("totalValue")]
        public double TotalValue { get; set; }

        [JsonProperty("durationMonths")]
        public int DurationMonths { get; set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ContractStatus Status { get; set; }

        [JsonProperty("signedAt")]
        public DateTime SignedAt { get; set; }

        [JsonProperty("manufacturerId")]
        public int ManufacturerId { get; set; }
    }
}
