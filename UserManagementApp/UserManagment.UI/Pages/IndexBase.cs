using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using UserManagment.UI.Services;

namespace UserManagment.UI.Pages
{
    public class IndexBase : ComponentBase
    {
        public string Hello { get; set; } = "Hello, prasanna!";

        [Inject]
        public IUsersService UsersService { get; set; }


        public async Task GetUsers()
        {
            var result = await UsersService.GetUsers().ConfigureAwait(false);

            Hello = "Prasanna";
        }

    }
}
