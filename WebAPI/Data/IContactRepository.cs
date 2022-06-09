﻿using Blog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Data
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> AllContactAsync();
        Task<IEnumerable<Contact>> GetContactByNameAsync(string name);

        Task<Contact> GetContactByIdAsync(int contactId);

        Contact Update(Contact contact);

        Contact Add(Contact contact);

        Task<Contact> DeleteAsync(int contactId);

        Task<int> CommitAsync();
    }
}
