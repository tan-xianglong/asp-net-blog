using Data;
using Data.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Services;
using WebAPI.ViewModels;
using Xunit;

namespace BlogTest.WebApiTests
{
    public class ContactServicesWebApiTests
    {
        private readonly Mock<IContactRepository> contactRepositoryMock;

        public ContactServicesWebApiTests()
        {
            contactRepositoryMock = new Mock<IContactRepository>();
        }

        [Fact]
        public async Task SaveContactAsync_ContactSaveSuccessfully_MustReturnSavedMessage()
        {
            //Arrange
            var expectedMessage = "Your request to contact has been submitted.";

            var contactServices = new ContactServicesWebApi(contactRepositoryMock.Object);

            //Act
            var msg = await contactServices.SaveContactAsync(new ContactViewModel());

            //Assert
            Assert.Equal(expectedMessage, msg);
        }

        [Fact]
        public async Task SaveContactAsync_ContactSaveFail_MustReturnErrorMessage()
        {
            //Arrange
            var expectedMessage = "Your request to contact has encountered an error." +
                " Please contact the IT administrator for more assistance.";

            contactRepositoryMock.Setup(method => method.CommitAsync())
                .Throws(new Exception());
            var contactServices = new ContactServicesWebApi(contactRepositoryMock.Object);

            //Act
            var msg = await contactServices.SaveContactAsync(new ContactViewModel());

            //Assert
            Assert.Equal(expectedMessage, msg);
        }

        [Fact]
        public async Task GetContactListAsync_NullStringProvided_MustReturnSameNumberOfResultFromRepo()
        {
            //Arrange
            var expectedNumOfResults = 3;
            contactRepositoryMock.Setup(method => method.GetContactByNameAsync(It.IsAny<string>()))
                .ReturnsAsync(new List<Contact>
                {
                    new Contact
                    {
                        ContactId = 1,
                        Name = "Jack",
                        PhoneNumber = "1234",
                        Email = "a@a.com",
                        Message = "test",
                        CreateDate = DateTime.Now

                    },
                    new Contact
                    {
                        ContactId = 2,
                        Name = "Jack",
                        PhoneNumber = "1234",
                        Email = "a@a.com",
                        Message = "test",
                        CreateDate = DateTime.Now
                    },
                    new Contact
                    {
                        ContactId = 3,
                        Name = "Jack",
                        PhoneNumber = "1234",
                        Email = "a@a.com",
                        Message = "test",
                        CreateDate = DateTime.Now
                    }
                });
            var contactServices = new ContactServicesWebApi(contactRepositoryMock.Object);

            //Act
            var contactListViewModel = await contactServices.GetContactListAsync(null);

            //Assert
            Assert.Equal(expectedNumOfResults, contactListViewModel.Contacts.Count());
        }
    }
}
