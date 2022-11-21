using System.Threading.Tasks;
using GRAMPRO.Platform.Utility.Model.General;
using GRAMPRO.Platform.Utility.Model.Authentication;
using GRAMPRO.Platform.Utility.Model;

namespace GRAMPRO.Platform.Utility.Implementation.Authentication
{
    public interface IAuthenticateImplementation
    {
        Task<Response> Login(LoginModel model);
        Task<Response> Register(RegisterModel model);
        Task<Response> RegisterAdmin(RegisterModel model);
        Response GetEntityType(string filter);
        Response userRole(string filter);
    //      Response   getRegister ();
    //    Response getRegisterForEdit(string Id);
    //     Response deleteUser(RegisterModel model);


    }

}