using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoggingRequestsAndResponses.Models
{
    [Serializable]
    public class Request
    {
        [Required]
        [Range(1,int.MaxValue)]
        public int Age { get; set; }
    }
}