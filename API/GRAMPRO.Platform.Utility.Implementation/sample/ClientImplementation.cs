using System.Linq;
using System.Data;
using GRAMPRO.Platform.Utility.Model;
using GRAMPRO.Platform.Utility.Repository;
using Microsoft.Extensions.Configuration;
using Service.DAL.ConnectionADO;
using GRAMPRO.Platform.Utility.Model.sample;
//using Service.Repository.Asset;
using Microsoft.EntityFrameworkCore;
using GRAMPRO.Platform.Utility.Implementation.sample;


namespace GRAMPRO.Platform.Utility.Implementation.sample
{
    public class ClientImplementation : IClientImplementation
    {
        private Response _response;
        private IConfigurationRoot _config;
        private ApplicationContext _context;
        private IDbConnection con;

        public ClientImplementation(ApplicationContext context, IConfigurationRoot config)
        {
            _context = context ?? throw new System.ArgumentNullException(nameof(context));
            _response = new Response();
            _config = config;
        }
        public Response getclientDatas()
           {
               try
               {
                   _response.Data = this._context.tblClient.ToList();
                   _response.Success = true;
                   //_response.Message = "success";
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

//            public Response savecategory(tblCategory sample)
//            {
//                try
//                {
//                    this._context.tblCategory.Add(sample);
//                    this._context.SaveChanges();
//                    _response.Success = true;
                  
//                    return _response;
//                }
//                catch (System.Exception)
//                {
//                    _response.Success = false;
//                    return _response;
//                }
//            }

//            public Response deletecategory(tblCategory sample)
//         {
//             try
//             {
//                 if (sample.Category_Id > 0)
//                 {
//                     var existingCategory = this._context.tblCategory.FirstOrDefault(x => x.Category_Id == sample.Category_Id);
//                     if (existingCategory != null)
//                     {
//                         //existingTicket.Product_Id = -1;
//                         existingCategory.ModifiedBy_Id = 2;
//                         existingCategory.IsDelete = true;
//                         existingCategory.ModifiedDate = System.DateTime.UtcNow;
//                         //this._context.Entry(existingTicket).State = EntityState.Modified;
//                         this._context.SaveChanges();


//                     }

//                 }
               
//                 _response.Success = true;
//                 return _response;
//             }
//             catch (System.Exception)
//             {
//                 _response.Success = false;
//                 return _response;
//             }
//         }
//         public Response updatecategory(tblCategory sample)
//         {
//             try
//             {
//                 if (sample.Category_Id > 0)
//                 {
//                     var existingCategory = this._context.tblCategory.FirstOrDefault(x => x.Category_Id == sample.Category_Id);
//                     if (existingCategory != null)
//                     {
//                         existingCategory.CategoryName = sample.CategoryName;
//                         //existingCategory.CategoryName = sample.CategoryName;
//                         //existingTicket.ClientPhoneNumber = sample1.ClientPhoneNumber;
//                        // existingTicket.Category_Id = sample1.Category_Id;
//                         //existingTicket.TicketStatus = sample1.TicketStatus;
//                         //existingTicket.TicketAssignedTo = sample1.TicketAssignedTo;
//                         //existingTicket.Description = sample1.Description;
//                         // existingTicket.Finding_Id = sample1.Finding_Id;
//                         // existingTicket.Priority_Id = sample1.Priority_Id;
//                         // existingTicket.SubCategory_Id = sample1.SubCategory_Id;
//                         // existingAsset.WarrantyStartDate = asset.WarrantyStartDate;
//                         // existingAsset.WarrantyEndDate = asset.WarrantyEndDate;
//                         // existingAsset.UserName = asset.UserName;
//                         // existingAsset.SimNumber = asset.SimNumber;
//                         // existingAsset.DateOfPurchase = asset.DateOfPurchase;
//                         // existingAsset.cost = asset.cost;
//                         // existingAsset.InvoiceNumber=asset.InvoiceNumber;
//                         // existingAsset.ModifiedBy = 2;
//                         // existingAsset.PackStartDate=asset.PackStartDate;
//                         // existingAsset.PackEndDate=asset.PackEndDate;
//                         // existingAsset.RecurringDate=asset.RecurringDate;
//                         // existingAsset.ModifiedDate = System.DateTime.UtcNow;
//                         // this._context.Entry(existingAsset).State = EntityState.Modified;


//                     }

//                 }
//                 else
//                 {
//                     //asset.CreatedBy = 1;
//                     sample.CreatedDate = System.DateTime.UtcNow;
//                     this._context.tblCategory.Add(sample);


//                 }


//                 // asset.BrandId = 2;
//                 // asset.ServiceStatus = 0;
//                 // asset.OsStatus = true;
//                 //  asset.ExtendedServiceStatus = 0;
//                 // asset.AssetGuid = System.Guid.NewGuid();
//                 // asset.StatusId = 1;
//                 //this._context.Assets.Add(asset);
//                 this._context.SaveChanges();
//                 _response.Success = true;
//                 return _response;
//             }
//             catch (System.Exception)
//             {
//                 _response.Success = false;
//                 return _response;
//             }
//         }
//     }
// }