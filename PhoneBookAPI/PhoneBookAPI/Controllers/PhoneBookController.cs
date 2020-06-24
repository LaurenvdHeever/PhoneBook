using Microsoft.AspNetCore.Mvc;
using PhoneBookAPI.Persistence;
using PhoneBookAPI.Models;
using System.Threading.Tasks;

namespace PhoneBookAPI.Controllers
{
    [Route("api/phonebook")]
    [ApiController]
    public class PhoneBookController : Controller
    {
        private readonly PhoneBookDataAccess _dataAccess;

        /// <summary>
        /// </summary>
        /// <param name="dataAccess"></param>
        public PhoneBookController(PhoneBookDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        /// <summary>
        /// Returns a list of phone books.
        /// </summary>		
        /// <returns></returns>
        [HttpGet(Name = "GetPhoneBooks")]
        public async Task<ActionResult> GetPhonebooks()
        {
            var phoneBooks = await _dataAccess.GetPhoneBooksAsync().ConfigureAwait(false);

            return Ok(phoneBooks);
        }

        /// <summary>
        /// Returns a name of the requested phone book.
        /// </summary>		
        /// <returns></returns>
        [HttpGet("{Id}", Name = "GetPhonebookName")]
        public async Task<ActionResult> GetPhonebookName(int Id)
        {
            var name = await _dataAccess.GetPhoneBookNameAsync(Id).ConfigureAwait(false);

            return Ok(name);
        }

        /// <summary>
        /// Returns a list of contacts for the requested phone book.
        /// </summary>		
        /// <returns></returns>
        [HttpGet("contacts/{phoneBookId:int}", Name = "GetContacts")]
        public async Task<ActionResult> GetContacts(int phoneBookId)
        {
            var contacts = await _dataAccess.GetContactsAsync(phoneBookId).ConfigureAwait(false);

            return Ok(contacts);
        }

        /// <summary>
        /// Add a contact to the contact list for the requested phonebook.
        /// </summary>		
        /// <returns></returns>
        [HttpPut(Name = "Contact")]
        public async Task<ActionResult> AddContact([FromBody] Contact contact)
        {
            await _dataAccess.AddContactAsync(contact).ConfigureAwait(false);

            return Ok();
        } 
    }
}
