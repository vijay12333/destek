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
    public class SubCategoryImplementation : ISubCategoryImplementation
    {
        private Response _response;
        private IConfigurationRoot _config;
        private ApplicationContext _context;
        //private IAssetRepository _assetRepository;
        private IDbConnection con;

        public SubCategoryImplementation(ApplicationContext context, IConfigurationRoot config)
        {
            _context = context ?? throw new System.ArgumentNullException(nameof(context));
            _response = new Response();
            _config = config;

        }
        public Response getSubCategory()
        {
            try
            {


                _response.Data = this._context.tblSubCategory.ToList();
                _response.Success = true;
                return _response;
            }
            catch (System.Exception)
            {
                _response.Success = false;
                return _response;
            }
        }

        public Response SaveSubCategory(tblSubCategory sample)
        {
            try
            {

                this._context.tblSubCategory.Add(sample);
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
         public Response deleteSubCategory(tblSubCategory sample)
        {
            try
            {
                if (sample.SubCategory_Id > 0)
                {
                    var existingSubCategory = this._context.tblSubCategory.FirstOrDefault(x => x.SubCategory_Id == sample.SubCategory_Id);
                    if (existingSubCategory != null)
                    {
                        //existingTicket.Product_Id = -1;
                        existingSubCategory.IsDelete = true;
                        existingSubCategory.ModifiedBy_Id = 2;
                        existingSubCategory.ModifiedDate = System.DateTime.UtcNow;
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

        public Response UpdateSubCategory(tblSubCategory sample)
        {
            try
            {
                if (sample.SubCategory_Id > 0)
                {
                    var existingSubCategory = this._context.tblSubCategory.FirstOrDefault(x => x.SubCategory_Id == sample.SubCategory_Id);
                    if (existingSubCategory != null)
                    {
                        existingSubCategory.SubCategoryName = sample.SubCategoryName;
                        existingSubCategory.Category_Id = sample.Category_Id;
                        
                        // existingAsset.ModifiedBy = 2;
                        // existingAsset.ModifiedDate = System.DateTime.UtcNow;
                        // this._context.Entry(existingAsset).State = EntityState.Modified;


                    }

                }
                else
                {
                    //ticket.CreatedBy = 1;
                    sample.CreatedDate = System.DateTime.UtcNow;
                    this._context.tblSubCategory.Add(sample);


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
