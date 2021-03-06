﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using UserManagement.Business.Helpers;
using UserManagement.Business.Models;

namespace UserManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserStory UserStory;

        public UserController(IUserStory userStory)
        {
            UserStory = userStory;
        }

        // GET: api/Users
        /// <summary>
        /// Get the list of users registered
        /// </summary>
        /// <returns>List of users</returns>
        [HttpGet(Name = "Users")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<UserModel>> GetUsers()
        {
            return await UserStory
                .UsersList()
                .ConfigureAwait(false);
        }

        // POST: api/Users
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task Post([FromBody] UserModel userModel)
        {
            await UserStory
                .CreateUser(userModel)
                .ConfigureAwait(false);
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "User")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<UserModel> Get(int id)
        {
            return await UserStory
                .GetUser(id)
                .ConfigureAwait(false);
        }

        // PUT: api/Users/5
        [HttpPut("{userId}")]
        public void Put(int userId, [FromBody] UserModel userModel)
        {
            // Method intentionally left empty.
        }

        [HttpPut]
        public async Task UpdateActiveStatus(string email, bool status)
        {
            await UserStory
                .UpdateActiveStatus(email, status)
                .ConfigureAwait(false);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task Delete(int id)
        {
            await UserStory
                .DeleteUser(id)
                .ConfigureAwait(false);
        }
    }
}
