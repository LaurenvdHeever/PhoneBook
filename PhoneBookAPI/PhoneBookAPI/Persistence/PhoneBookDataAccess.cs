using Dapper;
using PhoneBookAPI.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace PhoneBookAPI.Persistence
{
    public class PhoneBookDataAccess
    {
        private readonly IDbConnectionFactory _connectionFactory;
        private readonly ISQLDatabaseSettings _sqlDatabaseSettings;
		private static SQLiteConnection _dbConnection;

		public PhoneBookDataAccess(IDbConnectionFactory connectionFactory, ISQLDatabaseSettings sqlDatabaseSettings)
        {
            _connectionFactory = connectionFactory;
            _sqlDatabaseSettings = sqlDatabaseSettings;

			InitialiseDatabase();
		}

        public async Task<IEnumerable<PhoneBook>> GetPhoneBooksAsync()
        {
            using (var connection = await _connectionFactory.OpenAsync(_sqlDatabaseSettings.ConnectionString).ConfigureAwait(false))
            {
                var phoneBooks = (await connection.QueryAsync<PhoneBook>(DataQuery.GetPhoneBooks, commandType: CommandType.Text, commandTimeout: _sqlDatabaseSettings.DbQueryTimeoutInSeconds).ConfigureAwait(false)).AsList();

                return phoneBooks;
            }
        }

		public async Task<string> GetPhoneBookNameAsync(int Id)
		{
			using (var connection = await _connectionFactory.OpenAsync(_sqlDatabaseSettings.ConnectionString).ConfigureAwait(false))
			{
				var name = await connection.QueryFirstOrDefaultAsync<string>(string.Format(DataQuery.GetPhoneBookName, Id), commandType: CommandType.Text, commandTimeout: _sqlDatabaseSettings.DbQueryTimeoutInSeconds).ConfigureAwait(false);

				return name;
			}
		}

		public async Task<IEnumerable<Contact>> GetContactsAsync(int phoneBookId)
        {
            using (var connection = await _connectionFactory.OpenAsync(_sqlDatabaseSettings.ConnectionString).ConfigureAwait(false))
            {
				var contacts = (await connection.QueryAsync<Contact>(string.Format(DataQuery.GetContacts, phoneBookId), commandType: CommandType.Text, commandTimeout: _sqlDatabaseSettings.DbQueryTimeoutInSeconds).ConfigureAwait(false)).AsList();

                return contacts;
            }
        }

        public async Task AddContactAsync(Contact contact)
        {
            using (var connection = await _connectionFactory.OpenAsync(_sqlDatabaseSettings.ConnectionString).ConfigureAwait(false))
            {
				var endpoint = string.Format(DataQuery.AddContact, contact.PhoneBookId, contact.Name, contact.PhoneNumber);

                await connection.ExecuteAsync(endpoint, commandType: CommandType.Text, commandTimeout: _sqlDatabaseSettings.DbQueryTimeoutInSeconds).ConfigureAwait(false);
            }
        }

		private void InitialiseDatabase()
		{
			if (!File.Exists(_sqlDatabaseSettings.DatabaseFileName))
			{
			SQLiteConnection.CreateFile(_sqlDatabaseSettings.DatabaseFileName);
			_dbConnection = new SQLiteConnection(_sqlDatabaseSettings.ConnectionString);
			_dbConnection.OpenAsync();

			createPhoneBookTable();
			createContactsTable();

			_dbConnection.Close();

			}
		}

		private void createPhoneBookTable()
		{
			// Create product table
			string productTable = @"
								CREATE TABLE IF NOT EXISTS[PhoneBook]
								(
								[Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
								[Name] NVARCHAR(60) NOT NULL
								)";

			SQLiteCommand command = new SQLiteCommand(productTable, _dbConnection);
			command.ExecuteNonQuery();

			// Insert product date
			string productData = @"
								INSERT INTO PhoneBook (Name)
								VALUES	('Laurens Phone Book')";

			command = new SQLiteCommand(productData, _dbConnection);
			command.ExecuteNonQuery();

		}

		private void createContactsTable()
		{
			// Create contacts table
			string contactTable = @"
								CREATE TABLE IF NOT EXISTS[Contacts]
								(
								[Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
								[PhoneBookId] INTEGER NOT NULL,
								[Name] NVARCHAR(60) NOT NULL,
								[PhoneNumber] NVARCHAR(20)  NOT NULL,
								FOREIGN KEY (PhoneBookId) REFERENCES PhoneBook(Id)
								)";

			SQLiteCommand command = new SQLiteCommand(contactTable, _dbConnection);
			command.ExecuteNonQuery();

			// Insert contact date
			string contactData = @"
								INSERT INTO Contacts (PhoneBookId, Name, PhoneNumber)
								VALUES
								(1, 'Paul McCartney', '0877898787'),
								(1, 'John Lennon' ,'0768765463'),
								(1, 'Ringo Starr', '0986546372'),
								(1, 'George Harrison', '0875437765'),
								(1, 'Caleb Followill', '0234657487'),
								(1, 'Matthew Followill', '0982435265'),
								(1, 'Jared Followill', '0113425364'),
								(1, 'Nathan Followill', '0453427654')";

			command = new SQLiteCommand(contactData, _dbConnection);
			command.ExecuteNonQuery();
		}
	}
}
