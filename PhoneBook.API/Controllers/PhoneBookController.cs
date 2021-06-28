using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneBook.Application.Interfaces;
using PhoneBook.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhoneBookController : ControllerBase
    {
        private readonly IPhoneBookService _phoneBookService;
        private readonly ILogger<PhoneBookController> _logger;

        public PhoneBookController(
          IPhoneBookService phoneBookService,
          ILogger<PhoneBookController> logger)
        {
            _phoneBookService = phoneBookService;
            _logger = logger;
        }

        #region Phonebook
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetPhoneBooks()
        {
            try
            {
                return Ok(await _phoneBookService.GetPhonebooksAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong: GetPhoneBooks " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> AddPhoneBook([FromBody] Phonebook phonebook)
        {
            try
            {
                await _phoneBookService.InsertPhonebooksAsync(phonebook);
                return Ok(phonebook);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong: GetPhoneBooks " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion

        #region Phonbook Entry
        [Route("entry")]
        [HttpPost]
        public async Task<IActionResult> AddPhonebookEntry([FromBody] Entry newEntry)
        {
            try
            {
                if (newEntry == null)
                    _logger.LogError($"Null {{nameof(Entry)}} object");

                if (!ModelState.IsValid)
                {
                    _logger.LogError($"Invalid {{nameof(Entry)}} object");
                    return BadRequest("Invalid Data");
                }

                await _phoneBookService.InsertPhonebookEntryAsync(newEntry);
                return Ok(newEntry);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong: PostPhoneBookEntry " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("{id}/entries")]
        [HttpGet]
        public async Task<IActionResult> GetPhonebookEntries(int id)
        {
            try
            {
                return Ok(await _phoneBookService.GetPhonebookEntriesAsync(id));
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong: GetPhoneBookEntries " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("{id}/entries/search")]
        [HttpGet]
        public async Task<IActionResult> GetPhonebookEntriesBySearchString(int id, [FromQuery] string searchString)
        {
            try
            {
                return Ok(await _phoneBookService.GetPhonebookEntriesBySearchStringAsync(id, searchString));
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong: GetPhonebookEntriesBySearchString " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion
    }
}
