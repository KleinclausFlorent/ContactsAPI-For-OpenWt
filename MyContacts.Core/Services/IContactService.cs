using MyContacts.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Core.Services
{
    /// <summary>
    /// interface for the Contact service
    /// defines the specific methods for this model  which will be called in the Service tier
    /// </summary>
    public interface IContactService
    {
        // --- Methods ---
            Task<IEnumerable<Contact>> GetAllContacts();

            Task<Contact> GetContactById(int id);

            Task<Contact> CreateContact(Contact newContact);

            Task UpdateContact(Contact contactToBeUpdated, Contact contact);

            Task DeleteContact(Contact contact);
    }
}
