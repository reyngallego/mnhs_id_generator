using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication4.Controllers
{
    public class DefaultController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok("Hello, World!");
        }

        // GET api/default/{id}
        public IHttpActionResult Get(int id)
        {
            return Ok($"You requested data with ID: {id}");
        }

        // POST api/default
        public IHttpActionResult Post([FromBody] string value)
        {
            // Process the posted data
            // For example, save it to a database
            return Ok($"Posted data: {value}");
        }

        // PUT api/default/{id}
        public IHttpActionResult Put(int id, [FromBody] string value)
        {
            // Update the resource with the given ID using the provided data
            return Ok($"Updated data with ID {id} to: {value}");
        }

        // DELETE api/default/{id}
        public IHttpActionResult Delete(int id)
        {
            // Delete the resource with the given ID
            return Ok($"Deleted data with ID: {id}");
        }
    }
}
