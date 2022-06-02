using Blog.Models;
using Blog.Models.ViewModels.Contacts;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Blog.Services
{
    public class ContactServices : IContactServices
    {
        private readonly IContactRepository _contactRepository;
        private readonly HttpClient _httpClient;

        public ContactServices(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
            _httpClient = new HttpClient();
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
            // call into API
            var apiRoot = "http://localhost:5010";
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{apiRoot}/api/Contact/list/{searchString}");
            request.Headers.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // deserialize content
            var content = await response.Content.ReadAsStringAsync();
            var contactListViewModel = JsonSerializer.Deserialize<ContactListViewModel>(content,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            //var contacts = await _contactRepository.GetContactByNameAsync(searchString);
            //var contactListViewModel = new ContactListViewModel
            //{
            //    Contacts = contacts
            //};
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
