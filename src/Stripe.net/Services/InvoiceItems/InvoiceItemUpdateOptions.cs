namespace Stripe
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class InvoiceItemUpdateOptions : BaseOptions, IHasMetadata
    {
        [JsonProperty("amount")]
        public long? Amount { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("discountable")]
        public bool? Discountable { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        [JsonProperty("quantity")]
        public long? Quantity { get; set; }

        /// <summary>
        /// Ids of the tax rates to apply to this invoice item.
        /// </summary>
        [JsonProperty("tax_rates")]
        public List<string> TaxRates { get; set; }

        [JsonProperty("unit_amount")]
        public long? UnitAmount { get; set; }
    }
}
