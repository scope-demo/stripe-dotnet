namespace Stripe
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class SourceUpdateOptions : BaseOptions, IHasMetadata
    {
        /// <summary>
        /// Information about a mandate possiblity attached to a source object (generally for bank debits) as well as its acceptance status.
        /// </summary>
        [JsonProperty("mandate")]
        public SourceMandateOptions Mandate { get; set; }

        /// <summary>
        /// A set of key/value pairs that you can attach to a source object. It can be useful for storing additional information about the source in a structured format. You can unset individual keys if you POST an empty value for that key. You can clear all keys if you POST an empty value for metadata.
        /// </summary>
        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// Information about the owner of the payment instrument that may be used or required by particular source types.
        /// </summary>
        [JsonProperty("owner")]
        public SourceOwnerOptions Owner { get; set; }

        /// <summary>
        /// Information about the items and shipping associated with the source.
        /// Required for transactional credit (for example Klarna) sources
        /// before you can charge it.
        /// </summary>
        [JsonProperty("source_order")]
        public SourceSourceOrderOptions SourceOrder { get; set; }

        /// <summary>
        /// Properties that can be updated on a Card Source.
        /// </summary>
        [JsonProperty("card")]
        public SourceCardUpdateOptions Card { get; set; }
    }
}
