using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using UserManagement.Business.Models;

namespace UserManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IStory Story;

        public UsersController(IStory story)
        {
            Story = story;
        }

        // GET: api/Users
        /// <summary>
        /// Get the list of users registered
        /// </summary>
        /// <returns>List of users</returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            return await Story
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
            await Story
                .CreateUser(userModel)
                .ConfigureAwait(false);
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<UserModel> Get(int id)
        {
            return await Story
                .GetUser(id)
                .ConfigureAwait(false);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
