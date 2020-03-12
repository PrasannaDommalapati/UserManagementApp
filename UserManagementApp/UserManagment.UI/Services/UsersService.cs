using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using UserManagement.Business.Models;

namespace UserManagment.UI.Services
{
    public class UsersService : IUsersService
    {
        private HttpClient HttpClient { get; }

        public UsersService(HttpClient httpClient)
        {
            HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<UserModel>> GetUsers()
        {
            var response = await HttpClient.GetAsync("/").ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<List<UserModel>>(content);
        }
    }
}
