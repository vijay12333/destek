using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GRAMPRO.Platform.Utility.Model.sample
{
    [Table("tblTeamMembers")]
    public class tblTeamMembers
    {
        [Column("Member_Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       
        public int Member_Id { get; set; }

        [Column("MemberName")]
        public string MemberName{ get; set; }

        [Column("MemberEmail")]
        public string MemberEmail{ get; set; }

        [Column("MemberPhonenumber")]

        public string MemberPhonenumber{ get; set; }


         [Column("Department_Id")]
        
        public int Department_Id { get; set; }

        [Column("CreatedBy_Id")]
        public int CreatedBy_Id{ get; set; }

        [Column("CreatedDate")]
        public DateTime CreatedDate{ get; set; }

        [Column("ModifiedBy_Id")]
        public int ModifiedBy_Id{ get; set; }

        [Column("ModifiedDate")]
        public DateTime ModifiedDate{ get; set; }

        [Column("IsDelete")]
        public bool IsDelete{ get; set; }

        [Column("IsActive")]
        public bool IsActive {get; set; }
     
    }
}