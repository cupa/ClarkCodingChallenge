using ClarkCodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClarkCodingChallenge.DataAccess
{
    public class ContactsRepository : IContactsRepository
    {
        private IDataAccess<Contact> contactDataAccess;

        public ContactsRepository(IDataAccess<Contact> ContactRepo)
        {
            this.contactDataAccess = ContactRepo;
        }

        public void AddContact(Contact Contact)
        {
            contactDataAccess.Add(Contact);
        }

        public IEnumerable<Contact> QueryByLastName(string LastName, bool OrderDesc)
        {
            IEnumerable<Contact> contacts = contactDataAccess.GetAll();
            if (!string.IsNullOrEmpty(LastName))
            {
                contacts = contacts.Where(c => c.LastName == LastName);
            }
            var orderedContacts = OrderDesc ?
                contacts.OrderByDescending(c => c.LastName).ThenByDescending(c => c.FirstName) :
                contacts.OrderBy(c => c.LastName).ThenBy(c => c.FirstName);
            return orderedContacts;
        }
    }

    public interface IContactsRepository
    {
        void AddContact(Contact Contact);
        IEnumerable<Contact> QueryByLastName(string LastName, bool OrderDesc);
    }
}
