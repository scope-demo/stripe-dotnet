namespace Stripe.Checkout
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Stripe.Infrastructure;

    public class SessionSubscriptionDataOptions : INestedOptions
    {
        /// <summary>
        /// A non-negative decimal between 0 and 100, with at most two decimal places. This
        /// represents the percentage of the subscription invoice subtotal that will be transferred
        /// to the application owner’s Stripe account. The request must be made with an OAuth key in
        /// order to set an application fee percentage. For more information, see the application
        /// fees <see href="https://stripe.com/docs/connect/subscriptions#collecting-fees-on-subscriptions">documentation</see>.
        /// </summary>
        [JsonProperty("application_fee_percent")]
        public decimal? ApplicationFeePercent { get; set; }

        /// <summary>
        /// List of items, each with an attached plan.
        /// </summary>
        [JsonProperty("items")]
        public List<SessionSubscriptionDataItemOptions> Items { get; set; }

        /// <summary>
        /// Set of key-value pairs that you can attach to an object. This can be useful for storing
        /// additional information about the object in a structured format.
        /// </summary>
        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// Unix timestamp representing the end of the trial period the customer will get before
        /// being charged for the first time. Has to be at least 48h in the future.
        /// </summary>
        [JsonProperty("trial_end")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? TrialEnd { get; set; }

        /// <summary>
        /// Integer representing the number of trial period days before the customer is charged for the first time.
        /// </summary>
        [JsonProperty("trial_period_days")]
        public long? TrialPeriodDays { get; set; }
    }
}
