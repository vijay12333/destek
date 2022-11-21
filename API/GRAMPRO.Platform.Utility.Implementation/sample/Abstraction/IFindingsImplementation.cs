using GRAMPRO.Platform.Utility.Model;
using GRAMPRO.Platform.Utility.Model.sample;
using GRAMPRO.Platform.Utility.Model.General;
namespace GRAMPRO.Platform.Utility.Implementation.sample
{
    public interface IFindingsImplementation
    {
        Response getFinding();

        Response SaveFinding(tblFindings sample);

         Response deleteFinding(tblFindings sample);

         Response UpdateFinding(tblFindings sample);
    }
}