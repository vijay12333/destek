using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GRAMPRO.Platform.Utility.Model.Operations
{
   
    public class TicketCount
    {

        public int Status_Id { get; set; }


        public string Status{ get; set; }

        public int TotalCount{ get; set; }

        public int TotalTicketCount{ get; set; }


    }
}