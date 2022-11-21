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
    public class TeamMembersImplementation : ITeamMembersImplementation
    {
        private Response _response;
        private IConfigurationRoot _config;
        private ApplicationContext _context;
        //private IAssetRepository _assetRepository;
        private IDbConnection con;

        public TeamMembersImplementation(ApplicationContext context, IConfigurationRoot config)
        {
            _context = context ?? throw new System.ArgumentNullException(nameof(context));
            _response = new Response();
            _config = config;

        }
        public Response getTeamMembers()
        {
            try
            {


                _response.Data = this._context.tblTeamMembers.ToList();
                _response.Success = true;
                return _response;
            }
            catch (System.Exception)
            {
                _response.Success = false;
                return _response;
            }
        }

        public Response SaveTeamMembers(tblTeamMembers sample)
        {
            try
            {

                this._context.tblTeamMembers.Add(sample);
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
        public Response deleteTeamMembers(tblTeamMembers sample)
        {
            try
            {
                if (sample.Member_Id > 0)
                {
                    var existingTeamMembers = this._context.tblTeamMembers.FirstOrDefault(x => x.Member_Id == sample.Member_Id);
                    if (existingTeamMembers != null)
                    {
                        //existingTicket.Product_Id = -1;
                        existingTeamMembers.IsDelete = true;
                        existingTeamMembers.ModifiedBy_Id = 2;
                        existingTeamMembers.ModifiedDate = System.DateTime.UtcNow;
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
        public Response UpdateTeamMembers(tblTeamMembers sample)
        {
            try
            {
                if (sample.Member_Id > 0)
                {
                    var existingTeamMembers = this._context.tblTeamMembers.FirstOrDefault(x => x.Member_Id == sample.Member_Id);
                    if (existingTeamMembers != null)
                    {
                        existingTeamMembers.MemberName = sample.MemberName;
                        existingTeamMembers.MemberEmail = sample.MemberEmail;
                        existingTeamMembers.MemberPhonenumber = sample.MemberPhonenumber;
                        existingTeamMembers.Department_Id = sample.Department_Id;
                        existingTeamMembers.CreatedBy_Id = sample.CreatedBy_Id;
                        // existingAsset.ModifiedBy = 2;
                        // existingAsset.ModifiedDate = System.DateTime.UtcNow;
                        // this._context.Entry(existingAsset).State = EntityState.Modified;


                    }

                }
                else
                {
                    //ticket.CreatedBy = 1;
                    sample.CreatedDate = System.DateTime.UtcNow;
                    this._context.tblTeamMembers.Add(sample);


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
