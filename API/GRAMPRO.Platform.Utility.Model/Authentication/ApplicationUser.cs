using System;
using Microsoft.AspNetCore.Identity;



namespace  GRAMPRO.Platform.Utility.Model.Authentication
{
    public class ApplicationUser : IdentityUser
    {
//        public Int16 CompanyId { get; set; }
        //public Int16 Status { get; set; }
        public string DisplayName { get; set; }
        public int EntityId {get; set;}
        //public int UserRoleId {get; set;}
    }
}