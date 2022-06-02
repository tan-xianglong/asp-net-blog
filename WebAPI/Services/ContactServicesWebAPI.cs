using Blog.Models;
using Blog.Models.ViewModels.Contacts;
using Blog.Services;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public class ContactServicesWebAPI : IContactServices
    {
        private readonly IContactRepository _contactRepository;

        public ContactServicesWebAPI(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<string> SaveContactAsync(ContactViewModel contactViewModel)
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
