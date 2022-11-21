using GRAMPRO.Platform.Utility.Model;
using GRAMPRO.Platform.Utility.Model.sample;
using GRAMPRO.Platform.Utility.Model.General;
namespace GRAMPRO.Platform.Utility.Implementation.sample
{
    public interface IPriorityImplementation
    {
        Response getPriority();

        Response SavePriority(tblPriority sample);

         Response deletePriority(tblPriority sample);

        Response UpdatePriority(tblPriority sample);
    }
}