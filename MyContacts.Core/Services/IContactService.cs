using MyContacts.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Core.Services
{
    public interface IContactService
    {

        Task<IEnumerable<Contact>> GetAllContacts();

        Task<Contact> GetContactById(int id);

        Task<Contact> CreateContact(Contact newContact);

        Task UpdateContact(Contact contactToBeUpdated, Contact contact);

        Task DeleteContact(Contact contact);
    }
}
