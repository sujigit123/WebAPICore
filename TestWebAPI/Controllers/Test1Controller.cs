using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebAPI.Filters;
using TestWebAPI.Models;
using TestWebAPI.Services;

namespace TestWebAPI.Controllers
{
    [Route("api/{v:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class Test1Controller : Controller
    {
        private readonly IServiceLayer _services;

        public Test1Controller(IServiceLayer services)
        {
            _services = services;
        }

        [HttpGet("{key}")]
        [ValidateKey]
        public string Get(string key)
        {
            return _services.GetDataByKey(key);
        }

        [HttpPost("{key}")]
        [ValidateKey]
        public int Add(string key, RequestPayload requestPayload)
        {
            return _services.AddData(key, requestPayload);
        }

        [HttpPut("{key}")]
        [ValidateKey]
        public int Update(string key, RequestPayload requestPayload)
        {
            return _services.UpdateData(key, requestPayload);
        }
    }
}
