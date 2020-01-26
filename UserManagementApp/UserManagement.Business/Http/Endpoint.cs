using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using UserManagement.Business.Extensions;
using UserManagement.Business.Helpers;

namespace UserManagement.Business.Http
{
    public class Endpoint : IEndpoint
    {
        public EndpointConfiguration Configuration { get; }

        public HttpClient HttpClient { get; }

        public Endpoint(IOptions<EndpointConfiguration> configuration) : this(configuration.Value)
        {
        }

        public Endpoint(EndpointConfiguration configuration) : this(new HttpClient(), configuration)
        {
        }

        public Endpoint(HttpClient client, EndpointConfiguration configuration)
        {
            HttpClient = client;
            Configuration = configuration;
        }

        public string Uri
        {
            get
            {
                return (Configuration.Host ?? "").CombineUri(Configuration.Path);
            }
        }

        public void AddHeader(string name, string value)
        {
            HttpClient.DefaultRequestHeaders.Add(name, value);
        }

        public async Task<TResponse> GetAsync<TResponse>() where TResponse : class
        {
            var uri = new Uri(Uri);

            return await GetAsync<TResponse>(uri).ConfigureAwait(false);
        }

        public async Task<TResponse> GetAsync<TResponse>(params string[] parameters) where TResponse : class
        {
            var uri = new Uri(string.Format(Uri, parameters));

            return await GetAsync<TResponse>(uri).ConfigureAwait(false);
        }

        public async Task<TResponse> GetAsync<TResponse>(params (string, string)[] parameters) where TResponse : class
        {
            var queryValues = HttpUtility.ParseQueryString(string.Empty);
            foreach(var (key, value) in parameters)
            {
                queryValues.Add(key, value);
            }

            var builder = new UriBuilder
            {
                Scheme = string.Empty,
                Host = string.Empty,
                Path = Uri,
                Query = queryValues.ToString()
            };

            return await GetAsync<TResponse>(builder.Uri).ConfigureAwait(false);
        }

        public async Task<TResponse> GetAsync<TResponse>(Uri uri) where TResponse : class
        {
            uri.ValidateNotNull();

            var response = await HttpClient.GetAsync(uri).ConfigureAwait(false);
            if(response.StatusCode == HttpStatusCode.OK)
            {
                return Utility.Deserialize<TResponse>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }
            else
            {
                var content = await response
                    .Content
                    .ReadAsStringAsync()
                    .ConfigureAwait(false);

                throw new UserManagementException($"Response Status:'{response.StatusCode}' Content: '{content}'");
            }
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(TRequest data)
            where TRequest : class
            where TResponse : class
        {
            var requestData = new StringContent(
                Utility.Serialize(data),
                Encoding.UTF8,
                MediaTypeNames.Application.Json);

            var response = await HttpClient
                .PostAsync(Uri, requestData)
                .ConfigureAwait(false);

            var responseContent = await response
                .Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            try
            {
                return Utility.Deserialize<TResponse>(responseContent);
            }
            catch(Exception ex)
            {
                throw new UserManagementException(string.Format(
                    "Failed to deserialize - {0} - {1}",
                    responseContent, ex.Message));
            }
        }
    }
}
