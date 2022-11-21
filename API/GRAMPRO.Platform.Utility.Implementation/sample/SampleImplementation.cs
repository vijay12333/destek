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
    public class SampleImplementation : ISampleImplementation
    {
        private Response _response;
        private IConfigurationRoot _config;
        private ApplicationContext _context;
        //private IAssetRepository _assetRepository;
        private IDbConnection con;

        public SampleImplementation(ApplicationContext context, IConfigurationRoot config)
        {
            _context = context ?? throw new System.ArgumentNullException(nameof(context));
            _response = new Response();
            _config = config;

        }
        public Response getdata1()
        {
            try
            {


                _response.Data = this._context.tblTicket.ToList();
                _response.Success = true;
                return _response;
            }
            catch (System.Exception)
            {
                _response.Success = false;
                return _response;
            }
        }

        public Response SaveData(tblTicket sample)
        {
            try
            {

                this._context.tblTicket.Add(sample);
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
         public Response deleteTicket(tblTicket sample)
        {
            try
            {
                if (sample.Ticket_Id > 0)
                {
                    var existingTicket = this._context.tblTicket.FirstOrDefault(x => x.Ticket_Id == sample.Ticket_Id);
                    if (existingTicket != null)
                    {
                        //existingTicket.Product_Id = -1;
                        existingTicket.IsDelete = true;
                        existingTicket.ModifiedBy_Id = 2;
                        existingTicket.ModifiedDate = System.DateTime.UtcNow;
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

        public Response UpdateTicket(tblTicket ticket)
        {
            try
            {
                if (ticket.Ticket_Id > 0)
                {
                    var existingTicket = this._context.tblTicket.FirstOrDefault(x => x.Ticket_Id == ticket.Ticket_Id);
                    if (existingTicket != null)
                    {
                       
                        existingTicket.ClientName = ticket.ClientName;
                        existingTicket.ClientEmail = ticket.ClientEmail;
                        existingTicket.ClientPhoneNumber = ticket.ClientPhoneNumber;
                        existingTicket.Category_Id = ticket.Category_Id;
                        existingTicket.Status_Id = ticket.Status_Id;
                        existingTicket.Department_Id = ticket.Department_Id;
                        existingTicket.Description = ticket.Description;
                        existingTicket.Finding_Id = ticket.Finding_Id;
                        existingTicket.Priority_Id = ticket.Priority_Id;
                         existingTicket.SubCategory_Id = ticket.SubCategory_Id;
                        // existingAsset.ModifiedBy = 2;
                        // existingAsset.ModifiedDate = System.DateTime.UtcNow;
                        // this._context.Entry(existingAsset).State = EntityState.Modified;


                    }

                }
                else
                {
                    //ticket.CreatedBy = 1;
                    ticket.CreatedDate = System.DateTime.UtcNow;
                    this._context.tblTicket.Add(ticket);


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



