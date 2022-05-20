using System.Collections.Generic;

namespace Blog.Models
{
    public class MockContactRepository : IContactRepository
    {
        public IEnumerable<Contact> AllContact => new List<Contact> { };

        public Contact Add(Contact contact)
        {
            throw new System.NotImplementedException();
        }

        public int Commit()
        {
            throw new System.NotImplementedException();
        }

        public Contact Delete(int contactId)
        {
            throw new System.NotImplementedException();
        }

        public Contact GetContactById(int contactId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Contact> GetContactByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public Contact Update(Contact contact)
        {
            throw new System.NotImplementedException();
        }
    }
}
