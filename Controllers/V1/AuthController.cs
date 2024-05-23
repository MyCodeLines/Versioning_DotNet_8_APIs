using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Versioning.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [MapToApiVersion("1.0")]
        [HttpGet]

        public void TestController()
        {

        }
    }
}
