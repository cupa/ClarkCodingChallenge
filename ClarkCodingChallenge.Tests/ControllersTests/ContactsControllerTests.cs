using ClarkCodingChallenge.Controllers;
using ClarkCodingChallenge.DataAccess;
using ClarkCodingChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ClarkCodingChallenge.Tests.ControllerTest
{
    [TestClass]
    public class ContactsControllerTests
    {
        private Mock<IContactsRepository> contactRepo;
        private ContactsController contactsController;

        [TestInitialize]
        public void Setup()
        {
            this.contactRepo = new Mock<IContactsRepository>();
            this.contactsController = new ContactsController(contactRepo.Object);
        }

        [TestMethod]
        public void ContactsController_Add_AddsContact()
        {
            var contact = new Contact() { FirstName = "Phil", LastName = "Gathany", Email = "asdf@asdf.com" };

            contactsController.Add(contact);

            contactRepo.Verify(c => c.AddContact(contact));
        }

        [TestMethod]
        public void ContactsController_Add_ReturnsSuccess()
        {
            var contact = new Contact() { FirstName = "Phil", LastName = "Gathany", Email = "asdf@asdf.com" };

            var result = contactsController.Add(contact);

            Assert.AreEqual("Success", ((ViewResult) result).ViewName);
        }

        [TestMethod]
        public void ContactsController_Get_ReturnsRepoResult()
        {
            var contact = new Contact() { FirstName = "Phil", LastName = "Gathany", Email = "asdf@asdf.com" };
            var contacts = new Contact[] { contact };
            contactRepo.Setup(r => r.QueryByLastName("test", true)).Returns(contacts);

            var result = contactsController.Get("test", true);

            CollectionAssert.AreEqual(contacts, result.Value as Contact[]);
        }
    }
}
