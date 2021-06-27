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

        [Route("entry")]
        [HttpPost]
        public async Task<IActionResult> PostPhoneBookEntry([FromBody] Entry newEntry)
        {
            try
            {
                if (newEntry == null)
                    _logger.LogError("Null Entry object");

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Entry object");
                    return BadRequest("Invalid Data");
                }

                await _phoneBookService.InsertEntryAsync(newEntry);
                return Ok(newEntry);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong: PostPhoneBookEntry " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("entry")]
        [HttpGet]
        public async Task<IActionResult> GetPhoneBook()
        {
            try
            {
                IEnumerable<Entry> phonebookEntries = await _phoneBookService.GetPhonebookEntries();
                return Ok(phonebookEntries);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong: GetPhoneBook " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("search")]
        [HttpGet]
        public async Task<IActionResult> GetPhoneBookEntriesBySearchCriteria(
          string searchString)
        {
            try
            {
                IEnumerable<Entry> entriesBySearchString = await _phoneBookService.GetPhonebookEntriesBySearchString(searchString);
                return Ok(entriesBySearchString);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong: GetPhoneBookEntriesBySearchCriteria " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
