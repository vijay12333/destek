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
    public class FindingsController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private IFindingsImplementation _findingsImplementation;
        public FindingsController(IWebHostEnvironment environment,
                                     IFindingsImplementation findingsImplementation,
                                     IConfigurationRoot config)
        {
            _environment = environment;
            _findingsImplementation = findingsImplementation;
        }
        [HttpGet]
        [Route("getFinding/")]
        public IActionResult getFinding()
        {
            var result = this._findingsImplementation.getFinding();
            return Ok(result);
        }
        [HttpPost]
        [Route("saveFinding/")]
        public IActionResult SaveFinding(tblFindings sample)
        {
            var result = this._findingsImplementation.SaveFinding(sample);
            return Ok(result);
        }

        [HttpDelete]
        [Route("deleteFinding/")]
        public IActionResult deleteFinding(tblFindings sample)
        {
            var result = this._findingsImplementation.deleteFinding(sample);
            return Ok(result);
        }
        
        [HttpPut]
        [Route("updateFinding/")]
        public IActionResult UpdateFinding(tblFindings sample)
        {
            var result = this._findingsImplementation.UpdateFinding(sample);
            return Ok(result);
        }
        

    }
}