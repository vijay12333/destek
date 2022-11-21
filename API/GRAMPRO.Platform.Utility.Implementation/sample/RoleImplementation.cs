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
    public class RoleImplementation : IRoleImplementation
    {
        private Response _response;
        private IConfigurationRoot _config;
        private ApplicationContext _context;
        private IDbConnection con;

        public RoleImplementation(ApplicationContext context, IConfigurationRoot config)
        {
            _context = context ?? throw new System.ArgumentNullException(nameof(context));
            _response = new Response();
            _config = config;
        }
        public Response getroleData()
           {
               try
               {
                   _response.Data = this._context.tblRole.ToList();
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

           public Response saverole(tblRole sample)
           {
               try
               {
                   this._context.tblRole.Add(sample);
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

        //    public Response deleterole(tblRole sample)
        // {
        //     try
        //     {
        //         if (sample.Ticket_Id > 0)
        //         {
        //             var existingTicket = this._context.tblTicket.FirstOrDefault(x => x.Ticket_Id == sample.Ticket_Id);
        //             if (existingTicket != null)
        //             {
        //                 //existingTicket.Product_Id = -1;
        //                 existingTicket.ModifiedBy_Id = 2;
        //                 existingTicket.IsDelete = true;
        //                 existingTicket.ModifiedDate = System.DateTime.UtcNow;
        //                 //this._context.Entry(existingTicket).State = EntityState.Modified;
        //                 this._context.SaveChanges();


        //             }

        //         }
               
        //         _response.Success = true;
        //         return _response;
        //     }
        //     catch (System.Exception)
        //     {
        //         _response.Success = false;
        //         return _response;
        //     }
        // }
    }
}