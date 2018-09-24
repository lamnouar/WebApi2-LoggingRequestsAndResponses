using System.Collections.Generic;

namespace LoggingRequestsAndResponses.Models
{
    public class Response
    {
        public IList<Person> Persons { get; set; }
        public IList<string> Messages { get; set; }
    }
}