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
    public class TicketController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private ISampleImplementation _sampleImplementation;
        public TicketController(IWebHostEnvironment environment,
                                     ISampleImplementation sampleImplementation,
                                     IConfigurationRoot config)
        {
            _environment = environment;
            _sampleImplementation = sampleImplementation;
        }
        [HttpGet]
        [Route("getTicket/")]
        public IActionResult getdata1()
        {
            var result = this._sampleImplementation.getdata1();
            return Ok(result);
        }
        [HttpPost]
        [Route("saveTicket/")]
        public IActionResult SaveData(tblTicket sample)
        {
            var result = this._sampleImplementation.SaveData(sample);
            return Ok(result);
        }

        [HttpDelete]
        [Route("deleteTicket/")]
        public IActionResult deleteTicket(tblTicket sample)
        {
            var result = this._sampleImplementation.deleteTicket(sample);
            return Ok(result);
        }

        [HttpPut]
        [Route("updateTicket/")]
        public IActionResult UpdateTicket(tblTicket sample)
        {
            var result = this._sampleImplementation.UpdateTicket(sample);
            return Ok(result);
        }

    }
}