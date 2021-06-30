using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using PhoneBook.API.Controllers;
using PhoneBook.Application.Interfaces;
using PhoneBook.Domain;
using PhoneBook.Tests.Tools;
using Xunit;

namespace PhoneBook.Tests.API
{
    public class PhonebookControllerTests
    {
        private readonly Mock<IPhoneBookService> _mockPhonebookService;
        private readonly PhoneBookController _controller;

        public PhonebookControllerTests()
        {
            _mockPhonebookService = new Mock<IPhoneBookService>();
            _controller = new PhoneBookController(_mockPhonebookService.Object);
        }

        [Fact]
        public void GetPhonebooks_EmptyData_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetPhoneBooks();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public async Task GetPhonebooks_WithData_ReturnsOkResult()
        {
            // Arrange
            var mockData = new List<Phonebook>
            {
                    new Phonebook
                    {
                        Id = 1,
                        Name = "test"
                    }
            };
            _mockPhonebookService
                .Setup(d => d.GetPhonebooksAsync())
                .ReturnsAsync(mockData);

            // Act
            var result = await _controller.GetPhoneBooks() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            var objectResult = Assert.IsType<OkObjectResult>(result);
            ComparePhonebook.Compare(mockData, (IReadOnlyList<Phonebook>)objectResult.Value);

        }

        [Fact]
        public void GetPhonebookEntires_IdDoesNotExist_ReturnsEmpty()
        {
            // Act
            var okResult = _controller.GetPhonebookEntries(9999999);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
    }
}
