using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Versioning.Controllers.V2
{

    [ApiVersion("2.0")]
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [MapToApiVersion("2.0")]
        [HttpGet]
        public void TestController()
        {

        }
    }
}
