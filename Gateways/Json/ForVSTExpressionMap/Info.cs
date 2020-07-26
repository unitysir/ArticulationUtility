using Newtonsoft.Json;

namespace ArticulationUtility.Gateways.Json.ForVSTExpressionMap
{
    public class Info
    {
        [JsonProperty( "version", Required = Required.Always)]
        public string Version { get; set; }

        [JsonProperty( "name", Required = Required.Always )]
        public string Name { get; set; }

        [JsonProperty( "author" )]
        public string Author { get; set; } = string.Empty;

        [JsonProperty( "product" )]
        public string Product { get; set; } = string.Empty;

        [JsonProperty( "url" )]
        public string Url { get; set; } = string.Empty;
    }
}