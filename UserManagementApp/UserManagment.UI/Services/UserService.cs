using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Business.Models;

namespace UserManagment.UI.Services
{
    public class UserService : IUserService
    {
        private HttpClient HttpClient { get; }

        public UserService(HttpClient httpClient)
        {
            HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<UserModel>> GetUsers()
        {
            var response = await HttpClient.GetAsync("/api/user").ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<List<UserModel>>(content);
        }

        public async Task Create(UserModel user)
        {
            var content = new StringContent(
                JsonConvert.SerializeObject(user),
                Encoding.UTF8,
                MediaTypeNames.Application.Json);

            await HttpClient.PostAsync("api/user", content).ConfigureAwait(false);
        }

        public async Task Delete(Guid id)
        {
            await HttpClient
                .DeleteAsync($"api/user/{id}")
                .ConfigureAwait(false);
        }
    }
}
