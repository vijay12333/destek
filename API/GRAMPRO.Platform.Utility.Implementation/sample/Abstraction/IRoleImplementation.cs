using GRAMPRO.Platform.Utility.Model;
using GRAMPRO.Platform.Utility.Model.sample;
using GRAMPRO.Platform.Utility.Model.General;

namespace GRAMPRO.Platform.Utility.Implementation.sample
{
    public interface IRoleImplementation
    {
        Response getroleData();
        Response saverole(tblRole sample);
        // Response deleterole(tblRole sample);

    }
}