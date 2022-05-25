using System.Collections.Generic;

namespace Blog.Models.ViewModels.Contacts
{
    public class ContactListViewModel
    {
        public IEnumerable<Contact> Contacts { get; set; }
        public string Message { get; set; }
    }
}
