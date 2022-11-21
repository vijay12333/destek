using System.Data;
using Microsoft.Extensions.Configuration;

namespace Service.DAL.ConnectionADO
{
    public class DataContextFactory
    {
        private static IConfigurationRoot _config;
        public DataContextFactory(IConfigurationRoot config)
        {
            _config = config;
        }
        public static IDbConnection GetDataContext(IConfigurationRoot config)
        {
            IDbConnection dataContext = new DataContextInstance(config).GetDbConnection();
            return dataContext;
        }

        public static IDbConnection GetDataContext(IConfigurationRoot config, string connection)
        {
            IDbConnection dataContext = new DataContextInstance(config).GetDbConnection(connection);
            return dataContext;
        }

        public static IDbConnection GetDataContextTransaction(IConfigurationRoot config)
        {
            IDbConnection dataContext = new DataContextInstance(config).GetDbConnection();
            return dataContext;
        }

        public static IDbConnection GetDataContextTransaction(IConfigurationRoot config, string connection)
        {
            IDbConnection dataContext = new DataContextInstance(config).GetDbConnection(connection);
            return dataContext;
        }

        public static void CommitDataContextTransaction(IDbTransaction transaction)
        {
            if (transaction != null)
            {
                IDbConnection con = transaction.Connection;
                transaction.Commit();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    con.Dispose();
                    con = null;
                }
                transaction.Dispose();
                transaction = null;
            }
        }

        public static void RollbackDataContextTransaction(IDbTransaction transaction)
        {
            if (transaction != null)
            {
                IDbConnection con = transaction.Connection;
                transaction.Rollback();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    con.Dispose();
                    con = null;
                }
                transaction.Dispose();
                transaction = null;
            }
        }

    }
}