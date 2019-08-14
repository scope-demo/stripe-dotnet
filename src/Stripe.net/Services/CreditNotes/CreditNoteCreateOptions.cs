namespace Stripe
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CreditNoteCreateOptions : BaseOptions, IHasMetadata
    {
        /// <summary>
        /// Credit note amount.
        /// </summary>
        [JsonProperty("amount")]
        public long? Amount { get; set; }

        /// <summary>
        /// Amount to credit the customer balance.
        /// </summary>
        [JsonProperty("credit_amount")]
        public long? CreditAmount { get; set; }

        /// <summary>
        /// ID of the invoice.
        /// </summary>
        [JsonProperty("invoice")]
        public string InvoiceId { get; set; }

        /// <summary>
        /// Credit note memo.
        /// </summary>
        [JsonProperty("memo")]
        public string Memo { get; set; }

        /// <summary>
        /// Set of key-value pairs that you can attach to an object. This can be useful for storing
        /// additional information about the object in a structured format.
        /// </summary>
        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// Reason for issuing this credit note, one of <c>duplicate</c>, <c>fraudulent</c>,
        /// <c>order_change</c>, or <c>product_unsatisfactory</c>.
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }

        /// <summary>
        /// ID of an existing refund to link this credit note to.
        /// </summary>
        [JsonProperty("refund")]
        public string RefundId { get; set; }

        /// <summary>
        /// Amount to refund. If set, a refund will be created for the charge associated with the
        /// invoice.
        /// </summary>
        [JsonProperty("refund_amount")]
        public long? RefundAmount { get; set; }
    }
}
