using ClarkCodingChallenge.DataAccess;
using ClarkCodingChallenge.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace ClarkCodingChallenge.Tests.BusinessLogicTests
{
    [TestClass]
    public class ContactsBusinessLogicTests
    {
        private Mock<IDataAccess<Contact>> dataAccess;
        private ContactsRepository repository;

        [TestInitialize]
        public void Setup()
        {
            this.dataAccess = new Mock<IDataAccess<Contact>>();
            this.repository = new ContactsRepository(dataAccess.Object);
        }

        [TestMethod]
        public void ContactsRepository_TestAdd()
        {
            var contact = new Contact() { FirstName = "Phil", LastName = "Gathany", Email = "test@email.com" };

            repository.AddContact(contact);
            
            dataAccess.Verify(a => a.Add(contact));
        }

        [TestMethod]
        public void ContactsRepository_GetContacts()
        {
            var contact = new Contact() { FirstName = "Phil", LastName = "Gathany", Email = "test@email.com" };
            GivenContacts(contact);
            var expectedContacts = new List<Contact> { contact };

            var contacts = repository.QueryByLastName("", false);

            CollectionAssert.AreEquivalent(expectedContacts, contacts.ToArray());
        }

        [TestMethod]
        public void ContactsRepository_GetContacts_ReturnsOnlyLastName()
        {
            var contact = new Contact() { FirstName = "Phil", LastName = "Gathany", Email = "test@email.com" };
            var contact2 = new Contact() { FirstName = "Phil", LastName = "Smith", Email = "test@email.com" };
            GivenContacts(contact, contact2);
            var expectedContacts = new List<Contact> { contact };

            var contacts = repository.QueryByLastName("Gathany", false);

            CollectionAssert.AreEquivalent(expectedContacts, contacts.ToArray());
        }

        [TestMethod]
        public void ContactsRepository_GetContacts_OrdersByDescending()
        {
            var contact = new Contact() { FirstName = "Phil", LastName = "Gathany", Email = "test@email.com" };
            var contact2 = new Contact() { FirstName = "Phil", LastName = "Smith", Email = "test@email.com" };
            GivenContacts(contact, contact2);
            var expectedContacts = new List<Contact> { contact2, contact };

            var contacts = repository.QueryByLastName("", true);

            CollectionAssert.AreEqual(expectedContacts, contacts.ToArray());
        }


        [TestMethod]
        public void ContactsRepository_GetContacts_OrdersByAscending()
        {
            var contact = new Contact() { FirstName = "Phil", LastName = "Gathany", Email = "test@email.com" };
            var contact2 = new Contact() { FirstName = "Phil", LastName = "Smith", Email = "test@email.com" };
            GivenContacts(contact, contact2);
            var expectedContacts = new List<Contact> { contact, contact2 };

            var contacts = repository.QueryByLastName("", false);

            CollectionAssert.AreEqual(expectedContacts, contacts.ToArray());
        }

        [TestMethod]
        public void ContactsRepository_GetContacts_OrdersByFirstNameDesc()
        {
            var contact = new Contact() { FirstName = "Phil", LastName = "Gathany", Email = "test@email.com" };
            var contact2 = new Contact() { FirstName = "Riley", LastName = "Gathany", Email = "test@email.com" };
            GivenContacts(contact, contact2);
            var expectedContacts = new List<Contact> { contact2, contact };

            var contacts = repository.QueryByLastName("Gathany", true);

            CollectionAssert.AreEqual(expectedContacts, contacts.ToArray());
        }
        
        // and so on...

        private void GivenContacts(params Contact[] contacts)
        {
            dataAccess.Setup(a => a.GetAll()).Returns(contacts);
        }
    }
}
