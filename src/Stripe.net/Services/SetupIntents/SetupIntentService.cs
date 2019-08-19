namespace Stripe
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class SetupIntentService : Service<SetupIntent>,
        ICreatable<SetupIntent, SetupIntentCreateOptions>,
        IListable<SetupIntent, SetupIntentListOptions>,
        IRetrievable<SetupIntent, SetupIntentGetOptions>,
        IUpdatable<SetupIntent, SetupIntentUpdateOptions>
    {
        public SetupIntentService()
            : base(null)
        {
        }

        public SetupIntentService(IStripeClient client)
            : base(client)
        {
        }

        public override string BasePath => "/v1/setup_intents";

        public virtual SetupIntent Cancel(string setupIntentId, SetupIntentCancelOptions options, RequestOptions requestOptions = null)
        {
            return this.Request(HttpMethod.Post, $"{this.InstanceUrl(setupIntentId)}/cancel", options, requestOptions);
        }

        public virtual Task<SetupIntent> CancelAsync(string setupIntentId, SetupIntentCancelOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.RequestAsync(HttpMethod.Post, $"{this.InstanceUrl(setupIntentId)}/cancel", options, requestOptions, cancellationToken);
        }

        public virtual SetupIntent Confirm(string setupIntentId, SetupIntentConfirmOptions options, RequestOptions requestOptions = null)
        {
            return this.Request(HttpMethod.Post, $"{this.InstanceUrl(setupIntentId)}/confirm", options, requestOptions);
        }

        public virtual Task<SetupIntent> ConfirmAsync(string setupIntentId, SetupIntentConfirmOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.RequestAsync(HttpMethod.Post, $"{this.InstanceUrl(setupIntentId)}/confirm", options, requestOptions, cancellationToken);
        }

        public virtual SetupIntent Create(SetupIntentCreateOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(options, requestOptions);
        }

        public virtual Task<SetupIntent> CreateAsync(SetupIntentCreateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.CreateEntityAsync(options, requestOptions, cancellationToken);
        }

        public virtual SetupIntent Get(string setupIntentId, SetupIntentGetOptions options = null, RequestOptions requestOptions = null)
        {
            return this.GetEntity(setupIntentId, options, requestOptions);
        }

        public virtual Task<SetupIntent> GetAsync(string setupIntentId, SetupIntentGetOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetEntityAsync(setupIntentId, options, requestOptions, cancellationToken);
        }

        public virtual StripeList<SetupIntent> List(SetupIntentListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(options, requestOptions);
        }

        public virtual Task<StripeList<SetupIntent>> ListAsync(SetupIntentListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.ListEntitiesAsync(options, requestOptions, cancellationToken);
        }

        public virtual IEnumerable<SetupIntent> ListAutoPaging(SetupIntentListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntitiesAutoPaging(options, requestOptions);
        }

        public virtual SetupIntent Update(string setupIntentId, SetupIntentUpdateOptions options, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(setupIntentId, options, requestOptions);
        }

        public virtual Task<SetupIntent> UpdateAsync(string setupIntentId, SetupIntentUpdateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.UpdateEntityAsync(setupIntentId, options, requestOptions, cancellationToken);
        }
    }
}
