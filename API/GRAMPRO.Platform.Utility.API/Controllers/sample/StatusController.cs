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
    public class StatusController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private IStatusImplementation _statusImplementation;
        public StatusController(IWebHostEnvironment environment,
                                     IStatusImplementation statusImplementation,
                                     IConfigurationRoot config)
        {
            _environment = environment;
            _statusImplementation = statusImplementation;
        }
        [HttpGet]
        [Route("getStatus/")]
        public IActionResult getStatus()
        {
            var result = this._statusImplementation.getStatus();
            return Ok(result);
        }
        [HttpPost]
        [Route("saveStatus/")]
        public IActionResult SaveStatus(tblStatus status)
        {
            var result = this._statusImplementation.SaveStatus(status);
            return Ok(result);
        }

        [HttpDelete]
        [Route("deleteStatus/")]
        public IActionResult deleteStatus(tblStatus status)
        {
            var result = this._statusImplementation.deleteStatus(status);
            return Ok(result);
        }

        [HttpPut]
        [Route("updateStatus/")]
        public IActionResult UpdateStatus(tblStatus status)
        {
            var result = this._statusImplementation.UpdateStatus(status);
            return Ok(result);
        }

    }
}