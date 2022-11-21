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
    public class TicketCountController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private ICountImplementation _countImplementation;
        public TicketCountController(IWebHostEnvironment environment,
                                     ICountImplementation countImplementation,
                                     IConfigurationRoot config)
        {
            _environment = environment;
            _countImplementation = countImplementation;
        }
        [HttpGet]
        [Route("getticketcount/")]
        public IActionResult getticketcount()
        {
            var result = this._countImplementation.getticketcount();
            return Ok(result);
        }
        

    }
}