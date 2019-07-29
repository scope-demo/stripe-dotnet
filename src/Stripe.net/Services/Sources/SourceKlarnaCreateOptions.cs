namespace Stripe
{
    using Newtonsoft.Json;

    public class SourceKlarnaCreateOptions : INestedOptions
    {
        /// <summary>
        /// A public URL for a background image, must be served over HTTPS.
        /// </summary>
        [JsonProperty("background_image_url")]
        public string BackgroundImageUrl { get; set; }

        /// <summary>
        /// Used to initialize the client side Klarna SDK.
        /// </summary>
        [JsonProperty("client_token")]
        public string ClientToken { get; set; }

        /// <summary>
        /// The first name of the customer (Klarna requires the customer's name
        /// to be passed as separate first and last name values).
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the customer.
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Format locales as a language tag consisting of a two-letter language
        /// code combined with a two-letter country code, according to RFC 1766.
        /// Examples are en-us for U.S. English, en-gb for British English, and
        /// sv-se for Swedish (in Sweden). (RFC1766).
        /// </summary>
        [JsonProperty("locale")]
        public string Locale { get; set; }

        /// <summary>
        /// A public URL for your businesses logo, must be served over HTTPS.
        /// </summary>
        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }

        /// <summary>
        /// Title displayed on the top of the Klarna Hosted Payment Page.
        /// </summary>
        [JsonProperty("page_title")]
        public string PageTitle { get; set; }

        [JsonProperty("pay_later_asset_urls_descriptive")]
        public string PayLaterAssetUrlsDescriptive { get; set; }

        [JsonProperty("pay_later_asset_urls_standard")]
        public string PayLaterAssetUrlsStandard { get; set; }

        [JsonProperty("pay_later_name")]
        public string PayLaterName { get; set; }

        [JsonProperty("pay_later_redirect_url")]
        public string PayLaterRedirectUrl { get; set; }

        [JsonProperty("pay_now_asset_urls_descriptive")]
        public string PayNowAssetUrlsDescriptive { get; set; }

        [JsonProperty("pay_now_asset_urls_standard")]
        public string PayNowAssetUrlsStandard { get; set; }

        [JsonProperty("pay_now_name")]
        public string PayNowName { get; set; }

        [JsonProperty("pay_now_redirect_url")]
        public string PayNowRedirectUrl { get; set; }

        [JsonProperty("pay_over_time_asset_urls_descriptive")]
        public string PayOverTimeAssetUrlsDescriptive { get; set; }

        [JsonProperty("pay_over_time_asset_urls_standard")]
        public string PayOverTimeAssetUrlsStandard { get; set; }

        [JsonProperty("pay_over_time_name")]
        public string PayOverTimeName { get; set; }

        [JsonProperty("pay_over_time_redirect_url")]
        public string PayOverTimeRedirectUrl { get; set; }

        [JsonProperty("payment_method_categories")]
        public string PaymentMethodCategories { get; set; }

        /// <summary>
        /// The ISO-3166 2-letter country code of the customer's location.
        /// </summary>
        [JsonProperty("purchase_country")]
        public string PurchaseCountry { get; set; }

        /// <summary>
        /// The buy button type, accepted values are <c>buy</c>, <c>rent</c>,
        /// <c>book</c>, <c>subscribe</c>, <c>download</c>, <c>order</c>,
        /// <c>continue</c>.
        /// </summary>
        [JsonProperty("purchase_type")]
        public string PurchaseType { get; set; }

        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; }

        /// <summary>
        /// The first name used on the shipping address (Klarna requires the
        /// shipping name to be passed as separate first and last name values).
        /// </summary>
        [JsonProperty("shipping_first_name")]
        public string ShippingFirstName { get; set; }

        /// <summary>
        /// The last name used on the shipping address.
        /// </summary>
        [JsonProperty("shipping_last_name")]
        public string ShippingLastName { get; set; }
    }
}
