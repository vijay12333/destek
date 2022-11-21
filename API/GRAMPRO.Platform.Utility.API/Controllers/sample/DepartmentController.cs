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
    public class TeamController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private IDepartmentImplementation _departmentImplementation;
        public TeamController(IWebHostEnvironment environment,
                                     IDepartmentImplementation departmentImplementation,
                                     IConfigurationRoot config)
        {
            _environment = environment;
            _departmentImplementation = departmentImplementation;
        }
        [HttpGet]
        [Route("getTeam/")]
        public IActionResult getDepartment()
        {
            var result = this._departmentImplementation.getDepartment();
            return Ok(result);
        }
        [HttpPost]
        [Route("saveTeam/")]
        public IActionResult SaveDepartment(tblTeam sample)
        {
            var result = this._departmentImplementation.SaveDepartment(sample);
            return Ok(result);
        }

        [HttpDelete]
        [Route("deleteTeam/")]
        public IActionResult deleteDepartment(tblTeam sample)
        {
            var result = this._departmentImplementation.deleteDepartment(sample);
            return Ok(result);
        }

        [HttpPut]
        [Route("updateTeam/")]
        public IActionResult UpdateDepartment(tblTeam sample)
        {
            var result = this._departmentImplementation.UpdateDepartment(sample);
            return Ok(result);
        }

    }
}