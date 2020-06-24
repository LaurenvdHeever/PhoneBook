namespace PhoneBookAPI.Models
{
    public class Contact
	{
		/// <summary>
		///   The Phone Book Id the contact belongs to.
		/// </summary>
		public int PhoneBookId { get; set; }

		/// <summary>
		///   The name of the contact.
		/// </summary>
		public string Name { get; set; }

		// <summary>
		///   The Phone Number of the contact.
		/// </summary>
		public string PhoneNumber { get; set; }

	}
}
