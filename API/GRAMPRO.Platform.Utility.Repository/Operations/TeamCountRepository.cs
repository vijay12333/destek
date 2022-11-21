using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;
using Service.Repository.Core;
using Service.Repository.Operations;
using GRAMPRO.Platform.Utility.Model.Operations;

namespace Service.Repository.Operations
{
    public class TeamCountRepository : DBRepositoryBase, ITeamCountRepository
    {

        public IEnumerable<TeamCount> getteamcount()
        {
            var teamcountList = new List<TeamCount>();
            SqlCommand command = base.CreateCommand("usp_getTeamCount", CommandType.StoredProcedure) as SqlCommand;
            if (command != null)
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader != null && (reader as SqlDataReader) != null && (reader as SqlDataReader).HasRows)
                    {
                        while (reader.Read())
                        {
                            teamcountList.Add(new TeamCount
                            {
                                DesignerCount = !reader.IsDBNull("DesignerCount") ? reader.GetInt32("DesignerCount") : 0,
                                FECount = !reader.IsDBNull("FECount") ? reader.GetInt32("FECount") : 0,
                                BECount = !reader.IsDBNull("BECount") ? reader.GetInt32("BECount") : 0,
                                CloudCount = !reader.IsDBNull("CloudCount") ? reader.GetInt32("CloudCount") :0,
                                SecurityCount = !reader.IsDBNull("SecurityCount") ? reader.GetInt32("SecurityCount") :0,

                            }


                            );

                        }

                    }

                }


            }
            return teamcountList;
        }
    }
}