using GRAMPRO.Platform.Utility.Implementation.sample;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using GRAMPRO.Platform.Utility.Model.sample;


namespace GRAMPRO.Platform.Utility.API.Controllers.sample
{
    [ApiController]
    [Route("GBSSupport/")]
    public class ClientController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private IClientImplementation _clientImplementation;
        public ClientController(IWebHostEnvironment environment,
                                     IClientImplementation clientImplementation,
                                     IConfigurationRoot config)
        {
            _environment = environment;
            _clientImplementation = clientImplementation;
        }
        [HttpGet]
        [Route("v1/client/")]
        public IActionResult getclientDatas()
        {
            var result = this._clientImplementation.getclientDatas();
            return Ok(result);
        }
    }
}

//         [HttpPost]
//         [Route("savecategory/")]
//         public IActionResult savecategory(tblCategory sample)
//         {
//             var result = this._categoryImplementation.savecategory(sample);
//             return Ok(result);
//         }
        
//         [HttpDelete]
//         [Route("deletecategory/")]
//         public IActionResult deletecategory(tblCategory sample)
//         {
//             var result = this._categoryImplementation.deletecategory(sample);
//             return Ok(result);
//         }
//         [HttpPut]
//         [Route("updatecategory/")]
//         public IActionResult updatecategory(tblCategory sample)
//         {
//             var result = this._categoryImplementation.updatecategory(sample);
//             return Ok(result);
//         }

//     }
// }