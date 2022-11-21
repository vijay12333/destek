using GRAMPRO.Platform.Utility.Model;
using GRAMPRO.Platform.Utility.Model.sample;
using GRAMPRO.Platform.Utility.Model.General;
namespace GRAMPRO.Platform.Utility.Implementation.sample
{
    public interface IDepartmentImplementation
    {
        Response getDepartment();

        Response SaveDepartment(tblTeam sample);

         Response deleteDepartment(tblTeam sample);

        Response UpdateDepartment(tblTeam sample);
    }
}