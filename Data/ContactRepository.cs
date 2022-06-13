using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _appDbContext;

        public ContactRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Contact Add(Contact contact)
        {
            _appDbContext.Contacts.Add(contact);
            return contact;
        }

        public async Task<IEnumerable<Contact>> AllContactAsync()
        {
            return await _appDbContext.Contacts
                .OrderByDescending(c => c.CreateDate)
                .ToListAsync();
        }

        public async Task<int> CommitAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }

        public async Task<Contact> DeleteAsync(int contactId)
        {
            var contact = await GetContactByIdAsync(contactId);
            if (contact != null)
            {
                _appDbContext.Contacts.Remove(contact);
            }
            return contact;
        }

        public async Task<Contact> GetContactByIdAsync(int contactId)
        {
            return await _appDbContext.Contacts.FirstOrDefaultAsync(c => c.ContactId == contactId);
        }

        public async Task<IEnumerable<Contact>> GetContactByNameAsync(string name)
        {
            var query = from c in _appDbContext.Contacts
                        where c.Name.Contains(name) || string.IsNullOrEmpty(name)
                        orderby c.ContactId descending
                        select c;
            return await query.ToListAsync();
        }

        public Contact Update(Contact contact)
        {
            var entity = _appDbContext.Contacts.Attach(contact);
            entity.State = EntityState.Modified;
            return contact;
        }
    }
}
