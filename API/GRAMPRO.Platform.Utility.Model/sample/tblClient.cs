using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GRAMPRO.Platform.Utility.Model.sample
{
    [Table("tblClient")]

    public class tblClient
    {
        [Column("Client_Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       
        public int Client_Id { get; set; }
        [Column("ClientName")]
       
        public string ClientName { get; set; }
        [Column("ClientEmail")]
       
        public string ClientEmail { get; set; }
        [Column("ClientPhoneNumber")]
       
        public string ClientPhoneNumber { get; set; }
         [Column("ClientAddress")]
       
        public string ClientAddress { get; set; }
         [Column("CompanyName")]
       
        public string CompanyName { get; set; }
         [Column("CreatedBy_Id")]
       
        public int CreatedBy_Id { get; set; }

        [Column("CreatedDate")]
       
        public DateTime CreatedDate { get; set; }
        [Column("ModifiedBy_Id")]
       
        public int ModifiedBy_Id { get; set; }
        [Column("ModifiedDate")]
       
        public DateTime ModifiedDate { get; set; }
        [Column("IsDelete")]
       
        public bool IsDelete { get; set; }
        [Column("IsActive")]
       
        public bool IsActive { get; set; }

    }
}