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
    public class StatusDataImplementation : IStatusDataImplementation
    {
        private Response _response;
        private IConfigurationRoot _config;
        private ApplicationContext _context;
        private IStatusDataRepository _statusdataRepository;
        private IDbConnection con;

        public StatusDataImplementation(ApplicationContext context, IConfigurationRoot config,IStatusDataRepository statusdataRepository)
        {
            _context = context ?? throw new System.ArgumentNullException(nameof(context));
            _response = new Response();
            _config = config;
            _statusdataRepository=statusdataRepository;

        }
        public Response getStatusdata()
        {
            try
            {
                using (con = DataContextFactory.GetDataContext(_config))
                {
                  using(IDbTransaction trn = con.BeginTransaction())
                  {
                _response.Success = true;
                _statusdataRepository.DbConnection = con;
                _statusdataRepository.DbTransaction = trn;
                _response.Data = _statusdataRepository.getStatusdata();
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

        