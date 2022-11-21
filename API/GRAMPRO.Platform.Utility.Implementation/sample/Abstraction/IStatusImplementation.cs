using GRAMPRO.Platform.Utility.Model;
using GRAMPRO.Platform.Utility.Model.sample;
using GRAMPRO.Platform.Utility.Model.General;
namespace GRAMPRO.Platform.Utility.Implementation.sample
{
    public interface IStatusImplementation
    {
        Response getStatus();

        Response SaveStatus(tblStatus status);

         Response deleteStatus(tblStatus status);

        Response UpdateStatus(tblStatus status);
    }
}