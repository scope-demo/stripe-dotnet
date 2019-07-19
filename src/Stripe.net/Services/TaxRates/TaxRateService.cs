namespace Stripe
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class TaxRateService : Service<TaxRate>,
        ICreatable<TaxRate, TaxRateCreateOptions>,
        IListable<TaxRate, TaxRateListOptions>,
        IRetrievable<TaxRate, TaxRateGetOptions>,
        IUpdatable<TaxRate, TaxRateUpdateOptions>
    {
        public TaxRateService()
            : base(null)
        {
        }

        public TaxRateService(IStripeClient client)
            : base(client)
        {
        }

        public override string BasePath => "/v1/tax_rates";

        public virtual TaxRate Create(TaxRateCreateOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(options, requestOptions);
        }

        public virtual Task<TaxRate> CreateAsync(TaxRateCreateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.CreateEntityAsync(options, requestOptions, cancellationToken);
        }

        public virtual TaxRate Get(string taxRateId, TaxRateGetOptions options = null, RequestOptions requestOptions = null)
        {
            return this.GetEntity(taxRateId, options, requestOptions);
        }

        public virtual Task<TaxRate> GetAsync(string taxRateId, TaxRateGetOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetEntityAsync(taxRateId, options, requestOptions, cancellationToken);
        }

        public virtual StripeList<TaxRate> List(TaxRateListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(options, requestOptions);
        }

        public virtual Task<StripeList<TaxRate>> ListAsync(TaxRateListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.ListEntitiesAsync(options, requestOptions, cancellationToken);
        }

        public virtual IEnumerable<TaxRate> ListAutoPaging(TaxRateListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntitiesAutoPaging(options, requestOptions);
        }

        public virtual TaxRate Update(string taxRateId, TaxRateUpdateOptions options, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(taxRateId, options, requestOptions);
        }

        public virtual Task<TaxRate> UpdateAsync(string taxRateId, TaxRateUpdateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.UpdateEntityAsync(taxRateId, options, requestOptions, cancellationToken);
        }
    }
}
