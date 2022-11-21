using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Service.Repository.Core
{
    public abstract class DBRepositoryBase : IDBRepository, IDisposable
    {     
           
        private IDbConnection _dbConnection;
        public IDbConnection DbConnection
        {
            get {
                return _dbConnection;
            }
            set {
                _dbConnection = value;
            }
        }

        private IDbTransaction _dbTransaction;
        private bool disposedValue;

        public IDbTransaction DbTransaction
        {
            get {
                return _dbTransaction;
            }
            set {
                _dbTransaction = value;
            }
        }

        protected virtual IDbCommand CreateCommand(string commandString, CommandType commandType = CommandType.StoredProcedure)
        {
            SqlCommand sqlCommand = null;
            if (DbTransaction == null)
            {
                sqlCommand = new SqlCommand(commandString, (SqlConnection)(DbConnection));
            }
            else
            {
                sqlCommand = new SqlCommand(commandString, (SqlConnection)(DbConnection), DbTransaction as SqlTransaction);
            }

            sqlCommand.CommandType = commandType;
            if (sqlCommand.Connection.State == ConnectionState.Closed)
            {
                sqlCommand.Connection.Open();
            }
            return sqlCommand;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (DbTransaction != null)
                    {
                        if (DbConnection.State != ConnectionState.Closed)
                        {
                            DbConnection.Close();
                        }
                        DbConnection.Dispose();
                        DbConnection = null;
                    }

                    if (DbTransaction != null)
                    {
                        DbTransaction.Dispose();
                        DbTransaction = null;
                    }
                }
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~DBRepositoryBase()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            //GC.SuppressFinalize(this);
        }


        public int ExecuteNonQuery(string query)
        {   


            SqlConnection cnn = new SqlConnection();
            SqlCommand cmd = new SqlCommand(query, cnn);
            if ((query.StartsWith("INSERT") | query.StartsWith("insert") | query.StartsWith("UPDATE") | query.StartsWith("update") | query.StartsWith("DELETE") | query.StartsWith("delete") | query.StartsWith("exec")))
                cmd.CommandType = CommandType.Text;
            else
                cmd.CommandType = CommandType.StoredProcedure;
            int retval=-1;
            try
            {
                cnn.Open();
                retval = cmd.ExecuteNonQuery();
            }
            catch (System.Exception)
            {
                  return retval;
            }
          
            finally
            {
                if ((cnn.State == ConnectionState.Open))
                    cnn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                SqlConnection.ClearPool(cnn);
                cnn.Dispose();
            }
            return retval;
        }
    }
}