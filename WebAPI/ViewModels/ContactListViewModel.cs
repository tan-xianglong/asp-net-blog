using Data.Entities;
using System.Collections.Generic;

namespace WebAPI.ViewModels
{
    public class ContactListViewModel
    {
        public IEnumerable<Contact> Contacts { get; set; }
        public string TempMessage { get; set; }
    }
}
