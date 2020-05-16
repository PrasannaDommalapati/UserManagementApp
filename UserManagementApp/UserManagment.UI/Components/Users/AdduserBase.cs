using Microsoft.AspNetCore.Components;
using System;
using UserManagement.Business.Models;

namespace UserManagment.UI.Components.Users
{
    public class AdduserBase : ComponentBase
    {
        public UserModel UserModel { get; set; }

        public void HandleValidSubmit()
        {
            UserModel = new UserModel();
            Console.WriteLine("OnValidSubmit");
        }
    }
}
