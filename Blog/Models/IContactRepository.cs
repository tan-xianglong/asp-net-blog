using System.Collections.Generic;

namespace Blog.Models
{
    public interface IContactRepository
    {
        IEnumerable<Contact> AllContact { get; }
        IEnumerable<Contact> GetContactByName(string name);

        Contact GetContactById(int contactId);

        Contact Update(Contact contact);

        Contact Add(Contact contact);

        Contact Delete(int contactId);

        int Commit();
    }
}
