using Microsoft.AspNetCore.Components;
using UserManagment.UI.Services;

namespace UserManagment.UI.Pages
{
    public class IndexBase : ComponentBase
    {
        public string Hello { get; set; } = "Hello, prasanna!";

        public object Data { get; set; }

        [Inject]
        public IUsersService UsersService { get; set; }
    }
}
