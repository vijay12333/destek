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
    public class DepartmentImplementation : IDepartmentImplementation
    {
        private Response _response;
        private IConfigurationRoot _config;
        private ApplicationContext _context;
        //private IAssetRepository _assetRepository;
        private IDbConnection con;

        public DepartmentImplementation(ApplicationContext context, IConfigurationRoot config)
        {
            _context = context ?? throw new System.ArgumentNullException(nameof(context));
            _response = new Response();
            _config = config;

        }
        public Response getDepartment()
        {
            try
            {


                _response.Data = this._context.tblTeam.ToList();
                _response.Success = true;
                return _response;
            }
            catch (System.Exception)
            {
                _response.Success = false;
                return _response;
            }
        }

        public Response SaveDepartment(tblTeam sample)
        {
            try
            {

                this._context.tblTeam.Add(sample);
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
         public Response deleteDepartment(tblTeam sample)
        {
            try
            {
                if (sample.Department_Id > 0)
                {
                    var existingDepartment = this._context.tblTeam.FirstOrDefault(x => x.Department_Id == sample.Department_Id);
                    if (existingDepartment != null)
                    {
                        //existingTicket.Product_Id = -1;
                        existingDepartment.IsDelete = true;
                        existingDepartment.ModifiedBy_Id = 2;
                        existingDepartment.ModifiedDate = System.DateTime.UtcNow;
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
    public Response UpdateDepartment(tblTeam sample)
        {
            try
            {
                if (sample.Department_Id > 0)
                {
                    var existingDepartment = this._context.tblTeam.FirstOrDefault(x => x.Department_Id == sample.Department_Id);
                    if (existingDepartment != null)
                    {
                        existingDepartment.DepartmentName = sample.DepartmentName;
                        existingDepartment.Ticket_Id = sample.Ticket_Id;
                        // existingAsset.ModifiedBy = 2;
                        // existingAsset.ModifiedDate = System.DateTime.UtcNow;
                        // this._context.Entry(existingAsset).State = EntityState.Modified;


                    }

                }
                else
                {
                    //ticket.CreatedBy = 1;
                    sample.CreatedDate = System.DateTime.UtcNow;
                    this._context.tblTeam.Add(sample);


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



