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
    public class TeamMembersController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private ITeamMembersImplementation _teammembersImplementation;
        public TeamMembersController(IWebHostEnvironment environment,
                                     ITeamMembersImplementation teammembersImplementation,
                                     IConfigurationRoot config)
        {
            _environment = environment;
            _teammembersImplementation = teammembersImplementation;
        }
        [HttpGet]
        [Route("getteamMembers/")]
        public IActionResult getTeamMembers()
        {
            var result = this._teammembersImplementation.getTeamMembers();
            return Ok(result);
        }
        [HttpPost]
        [Route("saveTeamMembers/")]
        public IActionResult SaveTeamMembers(tblTeamMembers sample)
        {
            var result = this._teammembersImplementation.SaveTeamMembers(sample);
            return Ok(result);
        }

        [HttpDelete]
        [Route("deleteTeamMembers/")]
        public IActionResult deleteTeamMembers(tblTeamMembers sample)
        {
            var result = this._teammembersImplementation.deleteTeamMembers(sample);
            return Ok(result);
        }

        [HttpPut]
        [Route("updateTeamMembers/")]
        public IActionResult UpdateTeamMembers(tblTeamMembers sample)
        {
            var result = this._teammembersImplementation.UpdateTeamMembers(sample);
            return Ok(result);
        }

    }
}