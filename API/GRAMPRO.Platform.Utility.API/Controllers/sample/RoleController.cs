using GRAMPRO.Platform.Utility.Implementation.sample;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using GRAMPRO.Platform.Utility.Model.sample;


namespace GRAMPRO.Platform.Utility.API.Controllers.sample
{
    [ApiController]
    [Route("GBSSupport/")]
    public class RoleController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private IRoleImplementation _roleImplementation;
        public RoleController(IWebHostEnvironment environment,
                                     IRoleImplementation roleImplementation,
                                     IConfigurationRoot config)
        {
            _environment = environment;
            _roleImplementation = roleImplementation;
        }
        [HttpGet]
        [Route("v1/role/")]
        public IActionResult getroleData()
        {
            var result = this._roleImplementation.getroleData();
            return Ok(result);
        }

        [HttpPost]
        [Route("saverole/")]
        public IActionResult saverole(tblRole sample)
        {
            var result = this._roleImplementation.saverole(sample);
            return Ok(result);
        }
        
        // [HttpDelete]
        // [Route("deleteticket/")]
        // public IActionResult deleteticket(tblTicket sample)
        // {
        //     var result = this._ticketImplementation.deleteticket(sample);
        //     return Ok(result);
        // }

    }
}