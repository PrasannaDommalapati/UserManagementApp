using System.Net.Http;
using System.Threading.Tasks;

namespace UserManagement.Business.Http
{
    public interface IEndpoint
    {
        EndpointConfiguration Configuration { get; }

        HttpClient HttpClient { get; }

        Task<TResponse> PostAsync<TRequest, TResponse>(TRequest data) where TRequest : class where TResponse : class;

        Task<TResponse> GetAsync<TResponse>(params string[] parameters) where TResponse : class;

        Task<TResponse> GetAsync<TResponse>(params (string,string)[] parameters) where TResponse : class;

        void AddHeader(string name, string value);
    }
}
