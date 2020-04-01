using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserManagement.API.Controllers
{
    [Route("api/organisation")]
    [ApiController]
    public class OrganisationController : ControllerBase
    {
        // GET: api/Organisation
        [HttpGet(Name="Organisations")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Organisation/5
        [HttpGet("{id}", Name = "Organisation")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Organisation
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Organisation/5
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
