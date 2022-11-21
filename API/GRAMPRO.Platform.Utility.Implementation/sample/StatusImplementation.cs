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
    public class StatusImplementation : IStatusImplementation
    {
        private Response _response;
        private IConfigurationRoot _config;
        private ApplicationContext _context;
        //private IAssetRepository _assetRepository;
        private IDbConnection con;

        public StatusImplementation(ApplicationContext context, IConfigurationRoot config)
        {
            _context = context ?? throw new System.ArgumentNullException(nameof(context));
            _response = new Response();
            _config = config;

        }
        public Response getStatus()
        {
            try
            {


                _response.Data = this._context.tblStatus.ToList();
                _response.Success = true;
                return _response;
            }
            catch (System.Exception)
            {
                _response.Success = false;
                return _response;
            }
        }

        public Response SaveStatus(tblStatus status)
        {
            try
            {

                this._context.tblStatus.Add(status);
                this._context.SaveChanges();
                _response.Success = true;
                return _response;
            }
            catch (System.Exception)
            {
                _response.Success = false;
                return _response;
            }
        }
         public Response deleteStatus(tblStatus status)
        {
            try
            {
                if (status.Status_Id > 0)
                {
                    var existingStatus = this._context.tblStatus.FirstOrDefault(x => x.Status_Id == status.Status_Id);
                    if (existingStatus != null)
                    {
                        //existingTicket.Product_Id = -1;
                        existingStatus.IsDelete = true;
                        existingStatus.ModifiedBy_Id = 2;
                        existingStatus.ModifiedDate = System.DateTime.UtcNow;
                        //this._context.Entry(existingTicket).State = EntityState.Modified;
                        this._context.SaveChanges();


                    }

                }
               
                _response.Success = true;
                return _response;
            }
            catch (System.Exception)
            {
                _response.Success = false;
                return _response;
            }
        }

        public Response UpdateStatus(tblStatus status)
        {
            try
            {
                if (status.Status_Id > 0)
                {
                    var existingStatus = this._context.tblStatus.FirstOrDefault(x => x.Status_Id == status.Status_Id);
                    if (existingStatus != null)
                    {
                        existingStatus.Status = status.Status;
                        existingStatus.Ticket_Id = status.Ticket_Id;
                        // existingAsset.ModifiedBy = 2;
                        // existingAsset.ModifiedDate = System.DateTime.UtcNow;
                        // this._context.Entry(existingAsset).State = EntityState.Modified;


                    }

                }
                else
                {
                    //ticket.CreatedBy = 1;
                    status.CreatedDate = System.DateTime.UtcNow;
                    this._context.tblStatus.Add(status);


                }

                this._context.SaveChanges();
                    _response.Success = true;
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
