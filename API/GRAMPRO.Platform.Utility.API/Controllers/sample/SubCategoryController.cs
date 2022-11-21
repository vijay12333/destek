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
    public class SubCategoryController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private ISubCategoryImplementation _subcategoryImplementation;
        public SubCategoryController(IWebHostEnvironment environment,
                                     ISubCategoryImplementation subcategoryImplementation,
                                     IConfigurationRoot config)
        {
            _environment = environment;
            _subcategoryImplementation = subcategoryImplementation;
        }
        [HttpGet]
        [Route("getsubcategory/")]
        public IActionResult getSubCategory()
        {
            var result = this._subcategoryImplementation.getSubCategory();
            return Ok(result);
        }
        [HttpPost]
        [Route("savesubcategory/")]
        public IActionResult SaveSubCategory(tblSubCategory sample)
        {
            var result = this._subcategoryImplementation.SaveSubCategory(sample);
            return Ok(result);
        }

        [HttpDelete]
        [Route("deletesubcategory/")]
        public IActionResult deleteSubCategory(tblSubCategory sample)
        {
            var result = this._subcategoryImplementation.deleteSubCategory(sample);
            return Ok(result);
        }

         [HttpPut]
        [Route("updatesubcategory/")]
        public IActionResult UpdateSubCategory(tblSubCategory sample)
        {
            var result = this._subcategoryImplementation.UpdateSubCategory(sample);
            return Ok(result);
        }

    }
}