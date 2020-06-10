using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Business.Models;
using UserManagment.UI.Services;

namespace UserManagment.UI.Components.Users
{
    public class UsersBase : ComponentBase
    {
        public List<UserModel> UserList { get; set; }

        public UserModel UserModel { get; set; }

        public bool ShowModel { set; get; } = false;

        public string ShowAddUser => ShowModel ? "d-none" : "d-block";

        public string ShowAddUserForm => ShowModel ? "d-block" : "d-none";

        [Inject]
        public IUserService UserService { get; set; }

        protected override void OnInitialized()
        {
            UserModel = new UserModel();
            UserModel.Birthday = DateTime.UtcNow.Date;
            UserList = UserService.GetUsers().GetAwaiter().GetResult();
        }

        public void AddUser() => ShowModel = true;

        public async Task HandleValidSubmit()
        {
            await UserService.Create(UserModel).ConfigureAwait(false);
            UserList = await UserService.GetUsers().ConfigureAwait(false);

            ShowModel = false;
        }

        public async Task DeleteUser(int id)
        {
            await UserService.Delete(id).ConfigureAwait(false);
        }
    }
}
