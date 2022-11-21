using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GRAMPRO.Platform.Utility.Model.General
{
    [Table("user_role")]
    public class UserRole
    {        
        [Column("UserRoleId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserRoleId { get; set; }       


        [Column("userType")]
        public string UserType { get; set; }

        


       
    }
}