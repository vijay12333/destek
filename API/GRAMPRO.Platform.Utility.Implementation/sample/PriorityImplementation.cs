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
    public class PriorityImplementation : IPriorityImplementation
    {
        private Response _response;
        private IConfigurationRoot _config;
        private ApplicationContext _context;
        //private IAssetRepository _assetRepository;
        private IDbConnection con;

        public PriorityImplementation(ApplicationContext context, IConfigurationRoot config)
        {
            _context = context ?? throw new System.ArgumentNullException(nameof(context));
            _response = new Response();
            _config = config;

        }
        public Response getPriority()
        {
            try
            {


                _response.Data = this._context.tblPriority.ToList();
                _response.Success = true;
                return _response;
            }
            catch (System.Exception)
            {
                _response.Success = false;
                return _response;
            }
        }

        public Response SavePriority(tblPriority sample)
        {
            try
            {

                this._context.tblPriority.Add(sample);
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
        public Response deletePriority(tblPriority sample)
        {
            try
            {
                if (sample.Priority_Id > 0)
                {
                    var existingPriority = this._context.tblPriority.FirstOrDefault(x => x.Priority_Id == sample.Priority_Id);
                    if (existingPriority != null)
                    {
                        //existingTicket.Product_Id = -1;
                        existingPriority.IsDelete = true;
                        existingPriority.ModifiedBy_Id = 2;
                        existingPriority.ModifiedDate = System.DateTime.UtcNow;
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
        public Response UpdatePriority(tblPriority sample)
        {
            try
            {
                if (sample.Priority_Id > 0)
                {
                    var existingPriority = this._context.tblPriority.FirstOrDefault(x => x.Priority_Id == sample.Priority_Id);
                    if (existingPriority != null)
                    {
                        existingPriority.Priority = sample.Priority;
                        // existingAsset.ModifiedBy = 2;
                        // existingAsset.ModifiedDate = System.DateTime.UtcNow;
                        // this._context.Entry(existingAsset).State = EntityState.Modified;


                    }

                }
                else
                {
                    //ticket.CreatedBy = 1;
                    sample.CreatedDate = System.DateTime.UtcNow;
                    this._context.tblPriority.Add(sample);


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
