﻿using System.Threading.Tasks;
using WebAPI.ViewModels;

namespace WebAPI.Services
{
    public interface IContactServicesWebAPI
    {
        Task<string> DeleteContactAsync(int contactId);
        Task<ContactListViewModel> GetContactListAsync(string searchString);
        Task<string> SaveContactAsync(ContactViewModel contactViewModel);
    }
}
