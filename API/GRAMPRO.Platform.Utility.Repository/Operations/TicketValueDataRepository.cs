using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;
using Service.Repository.Core;
using Service.Repository.Operations;
using GRAMPRO.Platform.Utility.Model.Operations;

namespace Service.Repository.Operations
{
    public class TicketValueDataRepository : DBRepositoryBase, ITicketValueDataRepository
    {

        public IEnumerable<TicketValueData> getTicketValueData()
        {
            var ticketvaluedataList = new List<TicketValueData>();
            SqlCommand command = base.CreateCommand("usp_getTicketDataValue", CommandType.StoredProcedure) as SqlCommand;
            if (command != null)
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader != null && (reader as SqlDataReader) != null && (reader as SqlDataReader).HasRows)
                    {
                        while (reader.Read())
                        {
                            ticketvaluedataList.Add(new TicketValueData
                            {
                                 Ticket_Id = !reader.IsDBNull("Ticket_Id") ? reader.GetInt32("Ticket_Id") : 0,
                                 CategoryName = !reader.IsDBNull("CategoryName") ? reader.GetString("CategoryName") : "",
                                 CreatedOn =  reader.GetDateTime("CreatedOn"),
                                 DepartmentName = !reader.IsDBNull("DepartmentName") ?reader.GetString("DepartmentName") : "",
                                 Priority = !reader.IsDBNull("Priority")? reader.GetString("Priority") : "",
                                 Status = !reader.IsDBNull("Status") ? reader.GetString("Status") : "",

                            }


                            );

                        }

                    }

                }


            }
            return ticketvaluedataList;
        }
    }
}