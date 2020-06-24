using System.Data;
using System.Data.SQLite;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBookAPI.Persistence
{
    /// <summary>
    ///   Defines the implementation for a SQL Server database connection.
    /// </summary>
    internal class SqlDbConnectionFactory : IDbConnectionFactory
    {
        public SqlDbConnectionFactory()
        {
        }

		/// <summary>
		///   Creates and opens a database connection, given a connection string.
		/// </summary>
		/// <param name="connectionString"></param>	
		public async Task<IDbConnection> OpenAsync(string connectionString)
		{
			return await OpenAsync(connectionString, CancellationToken.None);
		}

		/// <param name="connectionString"></param>
		/// <param name="token"></param>
		/// <returns></returns>
		public async Task<IDbConnection> OpenAsync(string connectionString, CancellationToken token)
		{
			var sqlConnection = new SQLiteConnection(connectionString);
			await sqlConnection.OpenAsync(token);
			return sqlConnection;
		}
	}
}
