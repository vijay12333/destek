using System;
using System.ComponentModel.DataAnnotations;

namespace GRAMPRO.Platform.Utility.Model.Authentication
{
    public class RegisterModel 
    {
        [Key]

        public string Id { get; set; }
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }
        public string DisplayName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

       // [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public string PhoneNumber { get; set; }
        // public int CompanyId { get; set; }
        public string Token { get; set; }
        public int EntityId { get; set; }
        public string EntityName { get; set; }
        //public int UserRoleId { get; set; }
       // public string UserType { get; set; }
        //public short Status {get; set; }


    }
}