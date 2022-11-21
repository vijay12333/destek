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
    public class StatusDataController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private IStatusDataImplementation _statusdataImplementation;
        public StatusDataController(IWebHostEnvironment environment,
                                     IStatusDataImplementation statusdataImplementation,
                                     IConfigurationRoot config)
        {
            _environment = environment;
            _statusdataImplementation = statusdataImplementation;
        }
        [HttpGet]
        [Route("getstatusdata/")]
        public IActionResult getStatusdata()
        {
            var result = this._statusdataImplementation.getStatusdata();
            return Ok(result);
        }
        

    }
}