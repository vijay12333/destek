using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GRAMPRO.Platform.Utility.Model.Operations
{
   
    public class TeamCount
    {

        public int DesignerCount { get; set; }


        public int FECount{ get; set; }

        public int BECount{ get; set; }

        public int CloudCount{ get; set; }

        public int SecurityCount{ get; set; }

    }
}