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
        private const string apiRoot = "http://localhost:5010";

        public ContactServices(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
            _httpClient = new HttpClient();
        }

        public async Task<string> SaveContactAsync(ContactViewModel contactViewModel)
        {
            // call into API
            var response = await _httpClient.PostAsJsonAsync($"{apiRoot}/api/Contact/", contactViewModel);
            response.EnsureSuccessStatusCode();

            // deserialize content
            var msg = await response.Content.ReadAsStringAsync();
            return msg;
        }

        public async Task<ContactListViewModel> GetContactListAsync(string searchString)
        {
            // call into API
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
            return contactListViewModel;
        }

        public async Task<string> DeleteContactAsync(int contactId)
        {
            // call into API
            var response = await _httpClient.DeleteAsync($"{apiRoot}/api/Contact/delete/{contactId}");
            response.EnsureSuccessStatusCode();

            // deserialize content
            var msg = await response.Content.ReadAsStringAsync();
            return msg;
        }
    }
}
