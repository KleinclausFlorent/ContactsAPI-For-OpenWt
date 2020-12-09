using MyContacts.Core;
using MyContacts.Core.Models;
using MyContacts.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Service.Services
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Contact> CreateContact(Contact newContact)
        {
            await _unitOfWork.Contacts.AddAsync(newContact);
            await _unitOfWork.CommitAsync();
            return newContact;
        }

        public async Task DeleteContact(Contact contact)
        {
            _unitOfWork.Contacts.Remove(contact);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            return await _unitOfWork.Contacts.GetAllAsync();
        }

        public async Task<Contact> GetContactById(int id)
        {
            return await _unitOfWork.Contacts.GetByIdAsync(id);
        }


        public async Task UpdateContact(Contact contactToBeUpdated, Contact contact)
        {
            contactToBeUpdated.Firstname = contact.Firstname;
            contactToBeUpdated.Lastname = contact.Lastname;
            contactToBeUpdated.Adress = contact.Adress;
            contactToBeUpdated.Email = contact.Email;
            contactToBeUpdated.Fullname = contact.Fullname;
            contactToBeUpdated.Mobile = contact.Mobile;

            await _unitOfWork.CommitAsync();
        }
    }
}
