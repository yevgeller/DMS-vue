using DMS.Vue.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Vue.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestingController : ControllerBase
    {
        [HttpGet(Name ="GetBlah")]//, Route("GetStudents")]
        public string Get()
        {
            return "return";
        }

    }
}
