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
    public class FindingsImplementation : IFindingsImplementation
    {
        private Response _response;
        private IConfigurationRoot _config;
        private ApplicationContext _context;
        //private IAssetRepository _assetRepository;
        private IDbConnection con;

        public FindingsImplementation(ApplicationContext context, IConfigurationRoot config)
        {
            _context = context ?? throw new System.ArgumentNullException(nameof(context));
            _response = new Response();
            _config = config;

        }
        public Response getFinding()
        {
            try
            {


                _response.Data = this._context.tblFindings.ToList();
                _response.Success = true;
                return _response;
            }
            catch (System.Exception)
            {
                _response.Success = false;
                return _response;
            }
        }

        public Response SaveFinding(tblFindings sample)
        {
            try
            {

                this._context.tblFindings.Add(sample);
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
         public Response deleteFinding(tblFindings sample)
        {
            try
            {
                if (sample.Findings_Id > 0)
                {
                    var existingFinding = this._context.tblFindings.FirstOrDefault(x => x.Findings_Id == sample.Findings_Id);
                    if (existingFinding != null)
                    {
                        //existingTicket.Product_Id = -1;
                        existingFinding.IsDelete = true;
                        existingFinding.ModifiedBy_Id = 2;
                        existingFinding.ModifiedDate = System.DateTime.UtcNow;
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
        public Response UpdateFinding(tblFindings sample)
        {
            try
            {
                if (sample.Findings_Id > 0)
                {
                    var existingFinding = this._context.tblFindings.FirstOrDefault(x => x.Findings_Id == sample.Findings_Id);
                    if (existingFinding != null)
                    {
                        existingFinding.Findings = sample.Findings;
                        // existingAsset.ModifiedBy = 2;
                        // existingAsset.ModifiedDate = System.DateTime.UtcNow;
                        // this._context.Entry(existingAsset).State = EntityState.Modified;


                    }

                }
                else
                {
                    //ticket.CreatedBy = 1;
                    sample.CreatedDate = System.DateTime.UtcNow;
                    this._context.tblFindings.Add(sample);


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
