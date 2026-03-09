using iLoveBillBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iLoveBillBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("ObtenerDato/{id:int}")]
        public string Get(int id)
        {
            return id.ToString();
        }

        [HttpPost("RecibirJSON")]
        public string Post(Test test)
        {
            return test.NameTest + test.ApellidoTest;
        }
    }
}
