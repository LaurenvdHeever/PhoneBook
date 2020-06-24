namespace PhoneBookAPI
{
    internal static class DataQuery
    {
		//Phone Book Data Access Commands
		//Queries would usually be stored on the database within stored procedures or functions
		internal static string GetPhoneBooks = "SELECT Id, Name FROM PhoneBook";
		internal static string GetPhoneBookName = "SELECT Name FROM PhoneBook WHERE Id = {0}";
		internal static string GetContacts = "SELECT PhoneBookId, Name, PhoneNumber FROM Contacts WHERE PhoneBookId = {0} ORDER BY Name";
		internal static string AddContact = "INSERT OR IGNORE INTO CONTACTS(PhoneBookId, Name, PhoneNumber) VALUES({0}, '{1}', '{2}')";
	}
}
