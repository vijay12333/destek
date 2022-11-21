using System.Collections.Generic;
using GRAMPRO.Platform.Utility.Model.Operations;
using Service.Repository.Core;

namespace Service.Repository.Operations
{
        public interface IStatusDataRepository : IDBRepository
        {
            IEnumerable<StatusData> getStatusdata();
        }



}