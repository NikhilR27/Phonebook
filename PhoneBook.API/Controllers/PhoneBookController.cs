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
            this._phoneBookService = phoneBookService;
            this._logger = logger;
        }

        [Route("entry")]
        [HttpPost]
        public async Task<IActionResult> PostPhoneBookEntry([FromBody] Entry newEntry)
        {
            try
            {
                if (newEntry == null)
                    this._logger.LogError("Null Entry object");
                if (!this.ModelState.IsValid)
                {
                    this._logger.LogError("Invalid Entry object");
                    return (IActionResult)this.BadRequest((object)"Invalid Data");
                }
                await this._phoneBookService.InsertEntryAsync(newEntry);
                return (IActionResult)this.Ok((object)newEntry);
            }
            catch (Exception ex)
            {
                this._logger.LogError("Something went wrong: PostPhoneBookEntry " + ex.Message);
                return (IActionResult)this.StatusCode(500);
            }
        }

        [Route("entry")]
        [HttpGet]
        public async Task<IActionResult> GetPhoneBook()
        {
            try
            {
                IEnumerable<Entry> phonebookEntries = await this._phoneBookService.GetPhonebookEntries();
                return (IActionResult)this.Ok((object)phonebookEntries);
            }
            catch (Exception ex)
            {
                this._logger.LogError("Something went wrong: GetPhoneBook " + ex.Message);
                return (IActionResult)this.StatusCode(500);
            }
        }

        [Route("search")]
        [HttpGet]
        public async Task<IActionResult> GetPhoneBookEntriesBySearchCriteria(
          string searchString)
        {
            try
            {
                IEnumerable<Entry> entriesBySearchString = await this._phoneBookService.GetPhonebookEntriesBySearchString(searchString);
                return (IActionResult)this.Ok((object)entriesBySearchString);
            }
            catch (Exception ex)
            {
                this._logger.LogError("Something went wrong: GetPhoneBookEntriesBySearchCriteria " + ex.Message);
                return (IActionResult)this.StatusCode(500);
            }
        }
    }
}
