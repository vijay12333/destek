using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;
using Service.Repository.Core;
using Service.Repository.Operations;
using GRAMPRO.Platform.Utility.Model.Operations;

namespace Service.Repository.Operations
{
    public class StatusDataRepository : DBRepositoryBase, IStatusDataRepository
    {

        public IEnumerable<StatusData> getStatusdata()
        {
            var statusdataList = new List<StatusData>();
            SqlCommand command = base.CreateCommand("usp_getStatusValue", CommandType.StoredProcedure) as SqlCommand;
            if (command != null)
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader != null && (reader as SqlDataReader) != null && (reader as SqlDataReader).HasRows)
                    {
                        while (reader.Read())
                        {
                            statusdataList.Add(new StatusData
                            {
                                Ticket_Id = !reader.IsDBNull("Ticket_Id") ? reader.GetInt32("Ticket_Id") : 0,
                                Status = !reader.IsDBNull("Status") ? reader.GetString("Status") : "",
                                // BECount = !reader.IsDBNull("BECount") ? reader.GetInt32("BECount") : 0,
                                // CloudCount = !reader.IsDBNull("CloudCount") ? reader.GetInt32("CloudCount") :0,
                                // SecurityCount = !reader.IsDBNull("SecurityCount") ? reader.GetInt32("SecurityCount") :0,

                            }


                            );

                        }

                    }

                }


            }
            return statusdataList;
        }
    }
}