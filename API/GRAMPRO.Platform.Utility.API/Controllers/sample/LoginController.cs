using GRAMPRO.Platform.Utility.Implementation.sample;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using GRAMPRO.Platform.Utility.Model.sample;
using GRAMPRO.Platform.Utility.Model;

namespace GRAMPRO.Platform.Utility.API.Controllers.sample
{
    [ApiController]
    [Route("GBSSupport/")]
    public class LoginController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private ILoginImplementation _loginImplementation;
        public LoginController(IWebHostEnvironment environment,
                                     ILoginImplementation loginImplementation,
                                     IConfigurationRoot config)
        {
            _environment = environment;
            _loginImplementation = loginImplementation;
        }
        [HttpPost]
        [Route("v1/Login")]
        public IActionResult getLogin(tblRole sample)
        {
            var result = this._loginImplementation.getLogin(sample);
            return Ok(result);
        }
    }
}