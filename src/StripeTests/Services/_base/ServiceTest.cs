namespace StripeTests
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Stripe;
    using Xunit;

    public class ServiceTest : BaseStripeTest
    {
        [Fact]
        public void Get_ExpandProperties()
        {
            var client = new TestClient();
            var service = new TestService(client);

            service.ExpandSimple = true;
            service.ExpandMultiWordProperty = true;
            service.Get("foo");

            Assert.Equal(2, client.LastOptions.Expand.Count);
            Assert.Contains("simple", client.LastOptions.Expand);
            Assert.Contains("multi_word_property", client.LastOptions.Expand);
        }

        [Fact]
        public void Get_ThrowsIfIdIsNull()
        {
            var client = new TestClient();
            var service = new TestService(client);

            Assert.Throws<ArgumentException>(() => service.Get(null));
        }

        [Fact]
        public void Get_ThrowsIfIdIsEmpty()
        {
            var client = new TestClient();
            var service = new TestService(client);

            Assert.Throws<ArgumentException>(() => service.Get(string.Empty));
        }

        [Fact]
        public void Get_ThrowsIfIdIsWhitespace()
        {
            var client = new TestClient();
            var service = new TestService(client);

            Assert.Throws<ArgumentException>(() => service.Get(" "));
        }

        [Fact]
        public void List_ExpandProperties()
        {
            var client = new TestClient();
            var service = new TestService(client);

            service.ExpandSimple = true;
            service.ExpandMultiWordProperty = true;
            var options = new ListOptions();

            service.List(options);

            Assert.Equal(2, client.LastOptions.Expand.Count);
            Assert.Contains("data.simple", client.LastOptions.Expand);
            Assert.Contains("data.multi_word_property", client.LastOptions.Expand);

            // Do a second request to check that expand properties are not duplicated
            service.List(options);

            Assert.Equal(2, client.LastOptions.Expand.Count);
            Assert.Contains("data.simple", client.LastOptions.Expand);
            Assert.Contains("data.multi_word_property", client.LastOptions.Expand);
        }

        private class TestClient : IStripeClient
        {
            public string ApiBase { get; }

            public string ApiKey { get; }

            public string ClientId { get; }

            public string ConnectBase { get; }

            public string FilesBase { get; }

            public BaseOptions LastOptions { get; protected set; }

            public Task<T> RequestAsync<T>(
                HttpMethod method,
                string path,
                BaseOptions options,
                RequestOptions requestOptions,
                CancellationToken cancellationToken = default(CancellationToken))
                where T : IStripeEntity
            {
                this.LastOptions = options;
                return Task.FromResult(default(T));
            }
        }

        private class TestEntity : StripeEntity, IHasId
        {
            [JsonProperty("id")]
            public string Id { get; set; }
        }

        private class TestService : Service<TestEntity>,
            IListable<TestEntity, ListOptions>,
            IRetrievable<TestEntity, BaseOptions>
        {
            public TestService(IStripeClient client)
                : base(client)
            {
            }

            public override string BasePath => "/v1/test_entities";

            public bool ExpandSimple { get; set; }

            public bool ExpandMultiWordProperty { get; set; }

            public virtual TestEntity Get(string id, BaseOptions options = null, RequestOptions requestOptions = null)
            {
                return this.GetEntity(id, options, requestOptions);
            }

            public virtual Task<TestEntity> GetAsync(string id, BaseOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
            {
                return this.GetEntityAsync(id, options, requestOptions, cancellationToken);
            }

            public virtual StripeList<TestEntity> List(ListOptions options = null, RequestOptions requestOptions = null)
            {
                return this.ListEntities(options, requestOptions);
            }

            public virtual Task<StripeList<TestEntity>> ListAsync(ListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
            {
                return this.ListEntitiesAsync(options, requestOptions, cancellationToken);
            }

            public virtual IEnumerable<TestEntity> ListAutoPaging(ListOptions options = null, RequestOptions requestOptions = null)
            {
                return this.ListEntitiesAutoPaging(options, requestOptions);
            }
        }
    }
}
