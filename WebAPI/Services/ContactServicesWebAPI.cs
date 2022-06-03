using Blog.Models;
using System;
using System.Threading.Tasks;
using WebAPI.ViewModels;

namespace WebAPI.Services
{
    public class ContactServicesWebAPI : IContactServicesWebAPI
    {
        private readonly IContactRepository _contactRepository;

        public ContactServicesWebAPI(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<string> SaveContactAsync(ContactViewModel contactViewModel)
        {
            try
            {
                var contact = new Contact
                {
                    Name = contactViewModel.Name,
                    Email = contactViewModel.Email,
                    PhoneNumber = contactViewModel.PhoneNumber,
                    Message = contactViewModel.Message,
                    CreateDate = System.DateTime.Now
                };
                _contactRepository.Add(contact);
                await _contactRepository.CommitAsync();
                return "Your request to contact has been submitted.";
            }
            catch (Exception)
            {
                return "Your request to contact has encountered an error. Please contact the IT administrator for more assistance.";
            }
        }

        public async Task<ContactListViewModel> GetContactListAsync(string searchString)
        {
            var contacts = await _contactRepository.GetContactByNameAsync(searchString);
            var contactListViewModel = new ContactListViewModel
            {
                Contacts = contacts
            };
            return contactListViewModel;
        }

        public async Task<string> DeleteContactAsync(int contactId)
        {
            var contact = await _contactRepository.DeleteAsync(contactId);
            await _contactRepository.CommitAsync();
            return contact == null ? "Contact Not Found" : "Contact has been deleted.";
        }
    }
}
