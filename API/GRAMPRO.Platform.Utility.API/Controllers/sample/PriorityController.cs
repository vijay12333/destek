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
    public class PriorityController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private IPriorityImplementation _priorityImplementation;
        public PriorityController(IWebHostEnvironment environment,
                                     IPriorityImplementation priorityImplementation,
                                     IConfigurationRoot config)
        {
            _environment = environment;
            _priorityImplementation = priorityImplementation;
        }
        [HttpGet]
        [Route("getpriority/")]
        public IActionResult getPriority()
        {
            var result = this._priorityImplementation.getPriority();
            return Ok(result);
        }
        [HttpPost]
        [Route("savePriority/")]
        public IActionResult SavePriority(tblPriority sample)
        {
            var result = this._priorityImplementation.SavePriority(sample);
            return Ok(result);
        }

        [HttpDelete]
        [Route("deletePriority/")]
        public IActionResult deletePriority(tblPriority sample)
        {
            var result = this._priorityImplementation.deletePriority(sample);
            return Ok(result);
        }

        [HttpPut]
        [Route("updatePriority/")]
        public IActionResult Updateriority(tblPriority sample)
        {
            var result = this._priorityImplementation.UpdatePriority(sample);
            return Ok(result);
        }


    }
}