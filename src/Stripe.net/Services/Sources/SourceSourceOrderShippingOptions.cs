namespace Stripe
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class SourceSourceOrderShippingOptions : ShippingOptions
    {
        [JsonProperty("carrier")]
        public string Carrier { get; set; }

        [JsonProperty("tracking_number")]
        public string TrackingNumber { get; set; }
    }
}
