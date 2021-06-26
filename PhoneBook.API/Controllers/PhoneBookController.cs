using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneBook.Application.Interfaces;
using PhoneBook.Domain;

namespace PhoneBook.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhoneBookController : ControllerBase
    {
        private readonly IPhoneBookService _phoneBookService;
        private readonly ILogger<PhoneBookController> _logger;

        public PhoneBookController(IPhoneBookService phoneBookService, ILogger<PhoneBookController> logger)
        {
            _phoneBookService = phoneBookService;
            _logger = logger;
        }

        [Route("entry")]
        [HttpPost]
        public IActionResult PostPhoneBookEntry([FromBody] Entry newEntry)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");

            _phoneBookService.InsertEntryAsync(newEntry);
            return Ok();
        }
    }
}
