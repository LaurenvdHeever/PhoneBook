using System.Data;
using System.Threading.Tasks;

namespace PhoneBookAPI.Persistence
{
    /// <summary>
    ///   Defines the interface for a database connection.
    /// </summary
    public interface IDbConnectionFactory
    {
        /// <summary>
		///   Creates and opens a database connection, given a connection string.
		/// </summary>
		/// <param name="connectionString">The connection string providing details about the connection.</param>
		/// <returns>The opened connection.</returns>
		Task<IDbConnection> OpenAsync(string connectionString);
    }
}
