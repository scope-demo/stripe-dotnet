namespace Stripe
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class SkuService : Service<Sku>,
        ICreatable<Sku, SkuCreateOptions>,
        IDeletable<Sku>,
        IListable<Sku, SkuListOptions>,
        IRetrievable<Sku, SkuGetOptions>,
        IUpdatable<Sku, SkuUpdateOptions>
    {
        public SkuService()
            : base(null)
        {
        }

        public SkuService(IStripeClient client)
            : base(client)
        {
        }

        public override string BasePath => "/v1/skus";

        public virtual Sku Create(SkuCreateOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(options, requestOptions);
        }

        public virtual Task<Sku> CreateAsync(SkuCreateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.CreateEntityAsync(options, requestOptions, cancellationToken);
        }

        public virtual Sku Delete(string skuId, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(skuId, null, requestOptions);
        }

        public virtual Task<Sku> DeleteAsync(string skuId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.DeleteEntityAsync(skuId, null, requestOptions, cancellationToken);
        }

        public virtual Sku Get(string skuId, SkuGetOptions options = null, RequestOptions requestOptions = null)
        {
            return this.GetEntity(skuId, options, requestOptions);
        }

        public virtual Task<Sku> GetAsync(string skuId, SkuGetOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetEntityAsync(skuId, options, requestOptions, cancellationToken);
        }

        public virtual StripeList<Sku> List(SkuListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(options, requestOptions);
        }

        public virtual Task<StripeList<Sku>> ListAsync(SkuListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.ListEntitiesAsync(options, requestOptions, cancellationToken);
        }

        public virtual IEnumerable<Sku> ListAutoPaging(SkuListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntitiesAutoPaging(options, requestOptions);
        }

        public virtual Sku Update(string skuId, SkuUpdateOptions options, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(skuId, options, requestOptions);
        }

        public virtual Task<Sku> UpdateAsync(string skuId, SkuUpdateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.UpdateEntityAsync(skuId, options, requestOptions, cancellationToken);
        }
    }
}
