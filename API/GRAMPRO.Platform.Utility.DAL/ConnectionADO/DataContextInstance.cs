using System.Data;
using Microsoft.Extensions.Configuration;

namespace Service.DAL.ConnectionADO
{
    public class DataContextInstance
    {
        private IConfigurationRoot _config;
        public DataContextInstance(IConfigurationRoot config)
        {
            _config = config;
        }
        public IDbConnection GetDbConnection()
        {
            string connection = _config["Data:ConnectionString"];
            return GetDbConnection(connection);
        }

        public IDbConnection GetDbConnection(string connection)
        {
            return new DataConnectionFactory(_config, connection).Create();
        }
    }
}