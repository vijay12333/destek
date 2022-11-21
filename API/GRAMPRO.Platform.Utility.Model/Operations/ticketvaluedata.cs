using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GRAMPRO.Platform.Utility.Model.Operations
{
   
    public class TicketValueData
    {

        public int Ticket_Id { get; set; }


        public string CategoryName{ get; set; }

        public DateTime CreatedOn{ get; set; }

        public string DepartmentName{ get; set; }

        public string Priority{ get; set; }

         public string Status{ get; set; }

    }
}