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
    public class TicketValueDataController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private ITicketValueDataImplementation _ticketvaluedataImplementation;
        public TicketValueDataController(IWebHostEnvironment environment,
                                     ITicketValueDataImplementation ticketvaluedataImplementation,
                                     IConfigurationRoot config)
        {
            _environment = environment;
            _ticketvaluedataImplementation = ticketvaluedataImplementation;
        }
        [HttpGet]
        [Route("getTicketValuedata/")]
        public IActionResult getTicketValueData()
        {
            var result = this._ticketvaluedataImplementation.getTicketValueData();
            return Ok(result);
        }
        

    }
}