using GRAMPRO.Platform.Utility.Model;
using GRAMPRO.Platform.Utility.Model.sample;
using GRAMPRO.Platform.Utility.Model.General;
namespace GRAMPRO.Platform.Utility.Implementation.sample
{
    public interface ICategoryImplementation
    {
        Response getCategory();

        Response SaveCategory(tblCategory sample);

         Response deleteCategory(tblCategory sample);

        Response UpdateCategory(tblCategory sample);
    }
}