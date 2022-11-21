using GRAMPRO.Platform.Utility.Model;
using GRAMPRO.Platform.Utility.Model.sample;
using GRAMPRO.Platform.Utility.Model.General;
namespace GRAMPRO.Platform.Utility.Implementation.sample
{
    public interface ITeamMembersImplementation
    {
        Response getTeamMembers();

        Response SaveTeamMembers(tblTeamMembers sample);

         Response deleteTeamMembers(tblTeamMembers sample);

         Response UpdateTeamMembers(tblTeamMembers sample);
    }
}