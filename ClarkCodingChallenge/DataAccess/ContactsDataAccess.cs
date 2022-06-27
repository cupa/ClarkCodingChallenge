using ClarkCodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClarkCodingChallenge.DataAccess
{
    public class ContactsDataAccess : IDataAccess<Contact>
    {
        private List<Contact> Contacts = new List<Contact>();
        public void Add(Contact Contact)
        {
            Contacts.Add(Contact);
        }

        public IEnumerable<Contact> GetAll()
        {
            return Contacts;
        }
    }

    public interface IDataAccess<T> where T : class
    {
        public void Add(T t);
        public IEnumerable<T> GetAll();
    }
}
