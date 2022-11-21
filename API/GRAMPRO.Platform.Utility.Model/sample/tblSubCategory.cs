using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GRAMPRO.Platform.Utility.Model.sample
{
    [Table("tblSubCategory")]
    public class tblSubCategory
    {
        [Column("SubCategory_Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       
        public int SubCategory_Id { get; set; }

        [Column("SubCategoryName")]
        public string SubCategoryName{ get; set; }

        [Column("Category_Id")]
        public int Category_Id{ get; set; }

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