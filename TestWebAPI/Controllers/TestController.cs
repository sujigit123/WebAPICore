using Microsoft.AspNetCore.Mvc;
using TestWebAPI.Filters;
using TestWebAPI.Models;
using TestWebAPI.Services;

namespace TestWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IServiceLayer _services;

        public TestController(IServiceLayer services)
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
        public int Add(string key,RequestPayload requestPayload)
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
