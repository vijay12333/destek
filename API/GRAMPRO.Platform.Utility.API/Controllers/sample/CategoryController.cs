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
    public class CategoryController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private ICategoryImplementation _categoryImplementation;
        public CategoryController(IWebHostEnvironment environment,
                                     ICategoryImplementation categoryImplementation,
                                     IConfigurationRoot config)
        {
            _environment = environment;
            _categoryImplementation = categoryImplementation;
        }
        [HttpGet]
        [Route("getcategory/")]
        public IActionResult getCategory()
        {
            var result = this._categoryImplementation.getCategory();
            return Ok(result);
        }
        [HttpPost]
        [Route("savecategory/")]
        public IActionResult SaveCategory(tblCategory sample)
        {
            var result = this._categoryImplementation.SaveCategory(sample);
            return Ok(result);
        }

        [HttpDelete]
        [Route("deletecategory/")]
        public IActionResult deleteCategory(tblCategory sample)
        {
            var result = this._categoryImplementation.deleteCategory(sample);
            return Ok(result);
        }

        [HttpPut]
        [Route("updateategory/")]
        public IActionResult UpdateCategory(tblCategory sample)
        {
            var result = this._categoryImplementation.UpdateCategory(sample);
            return Ok(result);
        }

    }
}