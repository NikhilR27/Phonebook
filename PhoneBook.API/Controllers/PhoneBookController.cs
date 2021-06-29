using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.Interfaces;
using PhoneBook.Domain;
using System.Threading.Tasks;

namespace PhoneBook.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhoneBookController : ControllerBase
    {
        private readonly IPhoneBookService _phoneBookService;

        public PhoneBookController(
          IPhoneBookService phoneBookService)
        {
            _phoneBookService = phoneBookService;
        }

        #region Phonebook
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetPhoneBooks()
        {
            return Ok(await _phoneBookService.GetPhonebooksAsync());
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> AddPhoneBook([FromBody] Phonebook phonebook)
        {
            await _phoneBookService.InsertPhonebooksAsync(phonebook);
            return Ok(phonebook.Id);
        }
        #endregion

        #region Phonbook Entry
        [Route("entry")]
        [HttpPost]
        public async Task<IActionResult> AddPhonebookEntry([FromBody] Entry newEntry)
        {
            await _phoneBookService.InsertPhonebookEntryAsync(newEntry);
            return Ok(newEntry.Id);
        }

        [Route("{id}/entries")]
        [HttpGet]
        public async Task<IActionResult> GetPhonebookEntries(int id)
        {
            return Ok(await _phoneBookService.GetPhonebookEntriesAsync(id));
        }

        [Route("{id}/entries/search")]
        [HttpGet]
        public async Task<IActionResult> GetPhonebookEntriesBySearchString(int id, [FromQuery] string searchString)
        {
            return Ok(await _phoneBookService.GetPhonebookEntriesBySearchStringAsync(id, searchString));
        }
        #endregion
    }
}
