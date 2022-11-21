using System.Linq;
using System.Data;
using GRAMPRO.Platform.Utility.Model;
using GRAMPRO.Platform.Utility.Model.sample;
using GRAMPRO.Platform.Utility.Repository;
using Microsoft.Extensions.Configuration;
using GRAMPRO.Platform.Utility.Implementation.sample;
using Service.DAL.ConnectionADO;
using GRAMPRO.Platform.Utility.Model.General;
//using Service.Repository.Asset;
using Microsoft.EntityFrameworkCore;


namespace GRAMPRO.Platform.Utility.Implementation.sample
{
    public class LoginImplementation : ILoginImplementation
    {
        private Response _response;
        private IConfigurationRoot _config;
        private ApplicationContext _context;
        //private IAssetRepository _assetRepository;
        private IDbConnection con;

        public LoginImplementation(ApplicationContext context, IConfigurationRoot config)
        {
            _context = context ?? throw new System.ArgumentNullException(nameof(context));
            _response = new Response();
            _config = config;

        }
        public Response getLogin(tblRole sample)
        {
            try
            {

                 var existingLogin = this._context.tblRole.Where(x => x.UserName == sample.UserName && x.Password == sample.Password).ToList();
                 if(existingLogin.Count > 0)
                 {
                _response.Success = true;
                _response.Message = "Login Success";
            }
            return _response;
            }
            catch (System.Exception)
            {
                _response.Success = false;
                return _response;
            }
        }
    }
}
        