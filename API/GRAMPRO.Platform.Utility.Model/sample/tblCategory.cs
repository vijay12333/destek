using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GRAMPRO.Platform.Utility.Model.sample
{
    [Table("tblCategory")]
    public class tblCategory
    {
        [Column("Category_Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       
        public int Category_Id { get; set; }

        [Column("CategoryName")]
        public string CategoryName{ get; set; }

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