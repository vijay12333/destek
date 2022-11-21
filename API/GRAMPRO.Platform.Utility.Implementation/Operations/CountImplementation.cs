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
    public class CountImplementation : ICountImplementation
    {
        private Response _response;
        private IConfigurationRoot _config;
        private ApplicationContext _context;
        private ITicketRepository _ticketRepository;
        private IDbConnection con;

        public CountImplementation(ApplicationContext context, IConfigurationRoot config,ITicketRepository ticketRepository)
        {
            _context = context ?? throw new System.ArgumentNullException(nameof(context));
            _response = new Response();
            _config = config;
            _ticketRepository=ticketRepository;

        }
        public Response getticketcount()
        {
            try
            {
                using (con = DataContextFactory.GetDataContext(_config))
                {
                  using(IDbTransaction trn = con.BeginTransaction())
                  {
                _response.Success = true;
                _ticketRepository.DbConnection = con;
                _ticketRepository.DbTransaction = trn;
                _response.Data = _ticketRepository.getticketcount();
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

        