using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GRAMPRO.Platform.Utility.Model.sample
{
    [Table("tblStatus")]
    public class tblStatus
    {
        [Column("Status_Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       
        public int Status_Id { get; set; }

        [Column("Status")]

        public string Status{ get; set; }

        [Column("Ticket_Id")]
        public int Ticket_Id{ get; set; }


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