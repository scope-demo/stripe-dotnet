namespace Stripe
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Stripe.Infrastructure;

    public class Plan : StripeEntity<Plan>, IHasId, IHasMetadata, IHasObject
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
        /// Whether the plan is currently available for new subscriptions.
        /// </summary>
        [JsonProperty("active")]
        public bool Active { get; set; }

        /// <summary>
        /// Specifies a usage aggregation strategy for plans where <see cref="UsageType"/> is
        /// <c>metered</c>. Allowed values are <c>sum</c> for summing up all usage during a period,
        /// <c>last_during_period</c> for picking the last usage record reported within a period,
        /// <c>last_ever</c> for picking the last usage record ever (across period bounds) or
        /// <c>max</c> which picks the usage record with the maximum reported usage during a
        /// period. Defaults to <c>sum</c>.
        /// </summary>
        [JsonProperty("aggregate_usage")]
        public string AggregateUsage { get; set; }

        /// <summary>
        /// The amount in cents to be charged on the interval specified.
        /// </summary>
        [JsonProperty("amount")]
        public long? Amount { get; set; }

        /// <summary>
        /// Same as <see cref="Amount"/>, but contains a decimal value with at most 12 decimal
        /// places.
        /// </summary>
        [JsonProperty("amount_decimal")]
        public decimal? AmountDecimal { get; set; }

        /// <summary>
        /// Describes how to compute the price per period. Either <c>per_unit</c> or <c>tiered</c>.
        /// <c>per_unit</c> indicates that the fixed amount (specified in amount) will be charged
        /// per unit in quantity (for plans with usage_type=licensed), or per unit of total usage
        /// (for plans with usage_type=metered). <c>tiered</c> indicates that the unit pricing will
        /// be computed using a tiering strategy as defined using the <see cref="Tiers"/> and
        /// <see cref="TiersMode"/> attributes.
        /// </summary>
        [JsonProperty("billing_scheme")]
        public string BillingScheme { get; set; }

        /// <summary>
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        /// </summary>
        [JsonProperty("created")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Created { get; set; }

        /// <summary>
        /// Three-letter ISO currency code, in lowercase. Must be a supported currency.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Whether this object is deleted or not.
        /// </summary>
        [JsonProperty("deleted", NullValueHandling=NullValueHandling.Ignore)]
        public bool? Deleted { get; set; }

        /// <summary>
        /// One of <c>day</c>, <c>week</c>, <c>month</c> or <c>year</c>. The frequency with which a
        /// subscription should be billed.
        /// </summary>
        [JsonProperty("interval")]
        public string Interval { get; set; }

        /// <summary>
        /// The number of intervals (specified in the interval property) between subscription
        /// billings.
        /// </summary>
        [JsonProperty("interval_count")]
        public long IntervalCount { get; set; }

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
        /// A brief description of the plan, hidden from customers.
        /// </summary>
        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        #region Expandable Product

        /// <summary>
        /// ID of the product linked to this plan.
        /// <para>You can expand the Product by setting the ExpandProduct property on the service to true</para>
        /// </summary>
        [JsonIgnore]
        public string ProductId
        {
            get => this.InternalProduct?.Id;
            set => this.InternalProduct = SetExpandableFieldId(value, this.InternalProduct);
        }

        /// <summary>
        /// The product linked to this plan (if it was expanded).
        /// </summary>
        [JsonIgnore]
        public Product Product
        {
            get => this.InternalProduct?.ExpandedObject;
            set => this.InternalProduct = SetExpandableFieldObject(value, this.InternalProduct);
        }

        [JsonProperty("product")]
        [JsonConverter(typeof(ExpandableFieldConverter<Product>))]
        internal ExpandableField<Product> InternalProduct { get; set; }
        #endregion

        /// <summary>
        /// Each element represents a pricing tier. This parameter requires <see cref="BillingScheme"/>
        /// to be set to <c>tiered</c>.
        /// </summary>
        [JsonProperty("tiers")]
        public List<PlanTier> Tiers { get; set; }

        /// <summary>
        /// Defines if the tiering price should be <c>graduated</c> or <c>volume</c> based. In
        /// volume-based tiering, the maximum quantity within a period determines the per unit
        /// price, in <c>graduated</c> tiering pricing can successively change as the quantity
        /// grows.
        /// </summary>
        [JsonProperty("tiers_mode")]
        public string TiersMode { get; set; }

        /// <summary>
        /// Apply a transformation to the reported usage or set quantity before computing the
        /// billed price. Cannot be combined with <see cref="Tiers"/>.
        /// </summary>
        [JsonProperty("transform_usage")]
        public PlanTransformUsage TransformUsage { get; set; }

        /// <summary>
        /// Default number of trial days when subscribing a customer to this plan using
        /// <c>trial_from_plan=true</c>.
        /// </summary>
        [JsonProperty("trial_period_days")]
        public long? TrialPeriodDays { get; set; }

        /// <summary>Configures how the quantity per period should be determined, can be either
        /// <c>metered</c> or <c>licensed</c>. <c>licensed</c> will automatically bill the quantity
        /// set for a plan when adding it to a subscription, <c>metered</c> will aggregate the total
        /// usage based on usage records. Defaults to <c>licensed</c>.
        /// </summary>
        [JsonProperty("usage_type")]
        public string UsageType { get; set; }
    }
}
