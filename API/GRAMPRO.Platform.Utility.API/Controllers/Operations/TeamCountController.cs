using GRAMPRO.Platform.Utility.Implementation.Operations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using GRAMPRO.Platform.Utility.Model.Operations;
using GRAMPRO.Platform.Utility.Model;

namespace GRAMPRO.Platform.Utility.API.Controllers.Operations
{
    [ApiController]
    [Route("GBSSupport/")]
    public class TeamCountController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private ITeamCountImplementation _teamcountImplementation;
        public TeamCountController(IWebHostEnvironment environment,
                                     ITeamCountImplementation teamcountImplementation,
                                     IConfigurationRoot config)
        {
            _environment = environment;
            _teamcountImplementation = teamcountImplementation;
        }
        [HttpGet]
        [Route("getteamcount/")]
        public IActionResult getteamcount()
        {
            var result = this._teamcountImplementation.getteamcount();
            return Ok(result);
        }
        

    }
}