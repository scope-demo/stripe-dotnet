namespace Stripe
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class SourceSourceOrderOptions : INestedOptions
    {
        [JsonProperty("items")]
        public List<SourceSourceOrderItemOptions> Items { get; set; }

        [JsonProperty("shipping")]
        public SourceSourceOrderShippingOptions Shipping { get; set; }
    }
}
