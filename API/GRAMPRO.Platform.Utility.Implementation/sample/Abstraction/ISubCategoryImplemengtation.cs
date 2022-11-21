using GRAMPRO.Platform.Utility.Model;
using GRAMPRO.Platform.Utility.Model.sample;
using GRAMPRO.Platform.Utility.Model.General;
namespace GRAMPRO.Platform.Utility.Implementation.sample
{
    public interface ISubCategoryImplementation
    {
        Response getSubCategory();

        Response SaveSubCategory(tblSubCategory sample);

         Response deleteSubCategory(tblSubCategory sample);

        Response UpdateSubCategory(tblSubCategory sample);
    }
}