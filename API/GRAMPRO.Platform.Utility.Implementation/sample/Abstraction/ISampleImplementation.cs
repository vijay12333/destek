using GRAMPRO.Platform.Utility.Model;
using GRAMPRO.Platform.Utility.Model.sample;
using GRAMPRO.Platform.Utility.Model.General;
namespace GRAMPRO.Platform.Utility.Implementation.sample
{
    public interface ISampleImplementation
    {
        Response getdata1();

        Response SaveData(tblTicket sample);

         Response deleteTicket(tblTicket sample);

        Response UpdateTicket(tblTicket sample);
    }
}