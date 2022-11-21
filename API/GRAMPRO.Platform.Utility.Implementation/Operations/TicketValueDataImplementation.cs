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
    public class TicketValueDataImplementation : ITicketValueDataImplementation
    {
        private Response _response;
        private IConfigurationRoot _config;
        private ApplicationContext _context;
        private ITicketValueDataRepository _ticketvaluedataRepository;
        private IDbConnection con;

        public TicketValueDataImplementation(ApplicationContext context, IConfigurationRoot config,ITicketValueDataRepository ticketvaluedataRepository)
        {
            _context = context ?? throw new System.ArgumentNullException(nameof(context));
            _response = new Response();
            _config = config;
            _ticketvaluedataRepository=ticketvaluedataRepository;

        }
        public Response getTicketValueData()
        {
            try
            {
                using (con = DataContextFactory.GetDataContext(_config))
                {
                  using(IDbTransaction trn = con.BeginTransaction())
                  {
                _response.Success = true;
                _ticketvaluedataRepository.DbConnection = con;
                _ticketvaluedataRepository.DbTransaction = trn;
                _response.Data = _ticketvaluedataRepository.getTicketValueData();
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
