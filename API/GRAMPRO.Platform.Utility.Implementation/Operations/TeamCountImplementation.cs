using System.Linq;
using System.Data;
using GRAMPRO.Platform.Utility.Model;
using GRAMPRO.Platform.Utility.Repository;
using Microsoft.Extensions.Configuration;
using Service.DAL.ConnectionADO;
using GRAMPRO.Platform.Utility.Model.Operations;
using GRAMPRO.Platform.Utility.Implementation.Operations;
using Service.Repository.Operations;
using Microsoft.EntityFrameworkCore;


namespace GRAMPRO.Platform.Utility.Implementation.Operations
{
    public class TeamCountImplementation : ITeamCountImplementation
    {
        private Response _response;
        private IConfigurationRoot _config;
        private ApplicationContext _context;
        private ITeamCountRepository _teamcountRepository;
        private IDbConnection con;

        public TeamCountImplementation(ApplicationContext context, IConfigurationRoot config,ITeamCountRepository teamcountRepository)
        {
            _context = context ?? throw new System.ArgumentNullException(nameof(context));
            _response = new Response();
            _config = config;
            _teamcountRepository=teamcountRepository;

        }
        public Response getteamcount()
        {
            try
            {
                using (con = DataContextFactory.GetDataContext(_config))
                {
                  using(IDbTransaction trn = con.BeginTransaction())
                  {
                _response.Success = true;
                _teamcountRepository.DbConnection = con;
                _teamcountRepository.DbTransaction = trn;
                _response.Data = _teamcountRepository.getteamcount();
                trn.Commit();
                return _response;
            }
                }
            }
            catch (System.Exception )
            {
                _response.Success = false;
                return _response;
            }
        }
    }
}