using LoggingRequestsAndResponses.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoggingRequestsAndResponses.Controllers
{
    public class ValuesController : ApiController
    {

        // GET api/values/5
        [HttpPut]
        public IHttpActionResult Put([Required] Request request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            IList<Person> persons = AllPersons().Where(p => p.Age == request.Age).ToList();

            return Ok(new Response() { Persons = persons, Messages = persons.Select(p => p.FirstName + " " + p.LastName).ToList() });
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }


        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        private IList<Person> AllPersons()
        {
            return new List<Person> { new Person("Tom", "Hanks", 50), new Person("John", "Wick", 45) };
        }

    }
}
