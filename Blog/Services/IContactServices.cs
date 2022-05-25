using Blog.Models.ViewModels.Contacts;
using System.Threading.Tasks;

namespace Blog.Services
{
    public interface IContactServices
    {
        Task<string> SaveContactAsync(ContactViewModel contactViewModel);
    }
}