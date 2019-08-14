namespace Stripe
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class AccountCardOptions : INestedOptions, IHasMetadata
    {
        [JsonProperty("object")]
        internal string Object => "card";

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("default_for_currency")]
        public bool? DefaultForCurrency { get; set; }

        [JsonProperty("exp_month")]
        public long? ExpMonth { get; set; }

        [JsonProperty("exp_year")]
        public long? ExpYear { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("address_city")]
        public string AddressCity { get; set; }

        [JsonProperty("address_country")]
        public string AddressCountry { get; set; }

        [JsonProperty("address_line1")]
        public string AddressLine1 { get; set; }

        [JsonProperty("address_line2")]
        public string AddressLine2 { get; set; }

        [JsonProperty("address_state")]
        public string AddressState { get; set; }

        [JsonProperty("address_zip")]
        public string AddressZip { get; set; }

        [JsonProperty("cvc")]
        public string Cvc { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
