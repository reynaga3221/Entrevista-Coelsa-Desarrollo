using CoelsaEntrevista.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace CoelsaEntrevista.Repositories
{
    public abstract class BaseRepository {

        IConnectionParameters _connectionParameters;

        public BaseRepository(IConnectionParameters connectionParameters)
        {
            this._connectionParameters = connectionParameters;
        }

        protected IDbConnection GetConnection()
        {
            return new SqlConnection(_connectionParameters.ConnectionString());
        }
    }
}
