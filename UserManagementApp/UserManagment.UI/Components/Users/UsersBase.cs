using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using UserManagement.Business.Models;
using UserManagment.UI.Services;

namespace UserManagment.UI.Components.Users
{
    public class UsersBase : ComponentBase
    {
        public List<UserModel> UserList { get; set; }

        public bool ShowModel { set; get; } = false;

        [Inject]
        public IUserService UsersService { get; set; }

        protected override void OnInitialized()
        {
            UserList = UsersService.GetUsers().GetAwaiter().GetResult();
        }

        public void AddUser()
        {
            ShowModel = true;
        }
    }
}
