using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GRAMPRO.Platform.Utility.Model.sample
{
    [Table("tblTicket")]
    public class tblTicket
    {
        [Column("Ticket_Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       
        public int Ticket_Id { get; set; }


        [Column("ClientName")]
        public string ClientName{ get; set; }

        [Column("ClientPhoneNumber")]
        public string ClientPhoneNumber { get; set; }

         [Column("ClientEmail")]
        public string ClientEmail{ get; set; }

         [Column("Category_Id")]
        public int Category_Id{ get; set; }



         [Column("Status_Id")]
        public int Status_Id{ get; set; }

        [Column("Department_Id")]
        public int Department_Id{ get; set; }
    


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

        [Column("Description")]
        public string Description { get; set; }

        [Column("Finding_Id")]
        public int Finding_Id { get; set; }

        [Column("Priority_Id")]
        public int Priority_Id { get; set; }

        [Column("SubCategory_Id")]
        public int SubCategory_Id { get; set; }
     
    }
}
        
