using Blog.Models;
using Blog.Models.ViewModels.Contacts;
using System.Threading.Tasks;

namespace Blog.Services
{
    public class ContactServices : IContactServices
    {
        private readonly IContactRepository _contactRepository;

        public ContactServices(IContactRepository contactRepository)
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


    }
}
