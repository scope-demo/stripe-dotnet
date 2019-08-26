namespace Stripe
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Stripe.Infrastructure;

    public class InvoiceItem : StripeEntity<InvoiceItem>, IHasId, IHasMetadata, IHasObject
    {
        /// <summary>
        /// Unique identifier for the object.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// String representing the object’s type. Objects of the same type share the same value.
        /// </summary>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <summary>
        /// Amount (in the currency specified) of the invoice item. This should always be equal to
        /// <c>unit_amount * quantity</c>.
        /// </summary>
        [JsonProperty("amount")]
        public long Amount { get; set; }

        /// <summary>
        /// Three-letter ISO currency code, in lowercase. Must be a supported currency.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        #region Expandable Customer

        /// <summary>
        /// ID of the customer who will be billed when this invoice item is billed.
        /// </summary>
        [JsonIgnore]
        public string CustomerId
        {
            get => this.InternalCustomer?.Id;
            set => this.InternalCustomer = SetExpandableFieldId(value, this.InternalCustomer);
        }

        /// <summary>
        /// The customer who will be billed when this invoice item is billed (if it was expanded).
        /// </summary>
        [JsonIgnore]
        public Customer Customer
        {
            get => this.InternalCustomer?.ExpandedObject;
            set => this.InternalCustomer = SetExpandableFieldObject(value, this.InternalCustomer);
        }

        [JsonProperty("customer")]
        [JsonConverter(typeof(ExpandableFieldConverter<Customer>))]
        internal ExpandableField<Customer> InternalCustomer { get; set; }
        #endregion

        /// <summary>
        /// Date at which the invoice item was created.
        /// </summary>
        [JsonProperty("date")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Date { get; set; }

        /// <summary>
        /// Whether this object is deleted or not.
        /// </summary>
        [JsonProperty("deleted", NullValueHandling=NullValueHandling.Ignore)]
        public bool? Deleted { get; set; }

        /// <summary>
        /// An arbitrary string attached to the object. Often useful for displaying to users.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// If <c>true</c>, discounts will apply to this invoice item. Always <c>false</c> for
        /// prorations.
        /// </summary>
        [JsonProperty("discountable")]
        public bool Discountable { get; set; }

        #region Expandable Invoice

        /// <summary>
        /// ID of the invoice this invoice item belongs to.
        /// </summary>
        [JsonIgnore]
        public string InvoiceId
        {
            get => this.InternalInvoice?.Id;
            set => this.InternalInvoice = SetExpandableFieldId(value, this.InternalInvoice);
        }

        /// <summary>
        /// The invoice this invoice item belongs to (if it was expanded).
        /// </summary>
        [JsonIgnore]
        public Invoice Invoice
        {
            get => this.InternalInvoice?.ExpandedObject;
            set => this.InternalInvoice = SetExpandableFieldObject(value, this.InternalInvoice);
        }

        [JsonProperty("invoice")]
        [JsonConverter(typeof(ExpandableFieldConverter<Invoice>))]
        internal ExpandableField<Invoice> InternalInvoice { get; set; }
        #endregion

        /// <summary>
        /// Has the value <c>true</c> if the object exists in live mode or the value
        /// <c>false</c> if the object exists in test mode.
        /// </summary>
        [JsonProperty("livemode")]
        public bool Livemode { get; set; }

        /// <summary>
        /// A set of key/value pairs that you can attach to a subscription object.
        /// </summary>
        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// Period this invoice item was created for.
        /// </summary>
        [JsonProperty("period")]
        public Period Period { get; set; }

        /// <summary>
        /// If the invoice item is a proration, the plan of the subscription that the proration was
        /// computed for.
        /// </summary>
        [JsonProperty("plan")]
        public Plan Plan { get; set; }

        /// <summary>
        /// Whether the invoice item was created automatically as a proration adjustment when the
        /// customer switched plans.
        /// </summary>
        [JsonProperty("proration")]
        public bool Proration { get; set; }

        /// <summary>
        /// Quantity of units for the invoice item. If the invoice item is a proration, the quantity
        /// of the subscription that the proration was computed for.
        /// </summary>
        [JsonProperty("quantity")]
        public long? Quantity { get; set; }

        #region Expandable Subscription

        /// <summary>
        /// ID of the subscription that this invoice item has been created for, if any.
        /// </summary>
        [JsonIgnore]
        public string SubscriptionId
        {
            get => this.InternalSubscription?.Id;
            set => this.InternalSubscription = SetExpandableFieldId(value, this.InternalSubscription);
        }

        /// <summary>
        /// The subscription that this invoice item has been created for, if any (if it was
        /// expanded).
        /// </summary>
        [JsonIgnore]
        public Subscription Subscription
        {
            get => this.InternalSubscription?.ExpandedObject;
            set => this.InternalSubscription = SetExpandableFieldObject(value, this.InternalSubscription);
        }

        [JsonProperty("subscription")]
        [JsonConverter(typeof(ExpandableFieldConverter<Subscription>))]
        internal ExpandableField<Subscription> InternalSubscription { get; set; }
        #endregion

        /// <summary>
        /// ID of the subscription item associated with this invoice item.
        /// </summary>
        [JsonProperty("subscription_item")]
        public string SubscriptionItemId { get; set; }

        /// <summary>
        /// The tax rates which apply to the invoice item. When set, the <see cref="Invoice.DefaultTaxRates"/>
        /// on the invoice do not apply to this invoice item.
        /// </summary>
        [JsonProperty("tax_rates")]
        public List<TaxRate> TaxRates { get; set; }

        /// <summary>
        /// For prorations this indicates whether Stripe automatically grouped multiple related
        /// debit and credit line items into a single combined line item.
        /// </summary>
        [JsonProperty("unified_proration")]
        public bool UnifiedProration { get; set; }

        /// <summary>
        /// Unit Amount (in the currency specified) of the invoice item.
        /// </summary>
        [JsonProperty("unit_amount")]
        public long? UnitAmount { get; set; }

        /// <summary>
        /// Same as <see cref="UnitAmount"/>, but contains a decimal value with at most 12 decimal
        /// places.
        /// </summary>
        [JsonProperty("unit_amount_decimal")]
        public decimal? UnitAmountDecimal { get; set; }
    }
}
