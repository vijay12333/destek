using System.Collections.Generic;
using GRAMPRO.Platform.Utility.Model.Operations;
using Service.Repository.Core;

namespace Service.Repository.Operations
{
        public interface ITeamCountRepository : IDBRepository
        {
            IEnumerable<TeamCount> getteamcount();
        }



}