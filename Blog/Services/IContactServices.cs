using Blog.Models.ViewModels.Contacts;
using System.Threading.Tasks;

namespace Blog.Services
{
    public interface IContactServices
    {
        Task<string> DeleteContactAsync(int contactId);
        Task<ContactListViewModel> GetContactListAsync(string searchString);
        Task<string> SaveContactAsync(ContactViewModel contactViewModel);
    }
}