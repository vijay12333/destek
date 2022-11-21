using System.Data;

namespace Service.Repository.Core
{
    public interface IDBRepository
    {
        IDbConnection DbConnection { get; set; }
        IDbTransaction DbTransaction { get; set; }
    }
}