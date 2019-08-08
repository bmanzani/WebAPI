using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class HttpModel
    {
        public HttpClient Http { get; set; }
        public string _urlBase { get; set; }
    }
}
