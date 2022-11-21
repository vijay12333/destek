using System.Data;
using System.Data.Common;
using Microsoft.Extensions.Configuration;

namespace Service.DAL.ConnectionADO
{
    public class DataConnectionFactory
    {
        private readonly DbProviderFactory _dbProvider;
        private readonly string _connectionString;
        private readonly string _providerName; private IConfigurationRoot _config;
        public DataConnectionFactory(IConfigurationRoot config)
        {
            _config = config;
        }

        public DataConnectionFactory(IConfigurationRoot config, string connectionName)
        {
            _connectionString = config["ConnectionStrings:DbConnection"];
            _providerName = config["ConnectionStrings:ProviderName"];
            _dbProvider = DbProviderFactories.GetFactory(_providerName);
        }

        public IDbConnection Create() 
        {
            var connection = _dbProvider.CreateConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();
            return connection;
        }
    }
}