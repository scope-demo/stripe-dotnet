namespace Stripe
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Stripe.Infrastructure;

    public class CapabilityRequirements : StripeEntity
    {
        /// <summary>
        /// The date the fields in <c>currently_due</c> must be collected by to keep the capability
        /// enabled for the account.
        /// </summary>
        [JsonProperty("current_deadline")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? CurrentDeadline { get; set; }

        /// <summary>
        /// The fields that need to be collected to keep the capability enabled. If not collected
        /// by the <c>current_deadline</c>, these fields appear in  <c>past_due</c> as well, and
        /// the capability is disabled.
        /// </summary>
        [JsonProperty("currently_due")]
        public List<string> CurrentlyDue { get; set; }

        /// <summary>
        /// If the capability is disabled, this string describes why. Possible values are
        /// <c>requirement.fields_needed</c>, <c>pending.onboarding</c>, <c>pending.review</c>,
        /// <c>rejected_fraud</c>, or <c>rejected.other</c>.
        /// </summary>
        [JsonProperty("disabled_reason")]
        public string DisabledReason { get; set; }

        /// <summary>
        /// The fields that need to be collected assuming all volume thresholds are reached. As
        /// they become required, these fields appear in <c>currently_due</c> as well, and the
        /// <c>current_deadline</c> is set.
        /// </summary>
        [JsonProperty("eventually_due")]
        public List<string> EventuallyDue { get; set; }

        /// <summary>
        /// The fields that weren’t collected by the <c>currently_due</c>. These fields need to be
        /// collected to enable the capability for the account.
        /// </summary>
        [JsonProperty("past_due")]
        public List<string> PastDue { get; set; }

        /// <summary>
        /// Additional fields that may be required depending on the results of verification or
        /// review for provided requirements. If any of these fields become required, they appear in
        /// <see cref="CurrentlyDue"/> or <see cref="PastDue"/>.
        /// </summary>
        [JsonProperty("pending_verification")]
        public List<string> PendingVerification { get; set; }
    }
}
