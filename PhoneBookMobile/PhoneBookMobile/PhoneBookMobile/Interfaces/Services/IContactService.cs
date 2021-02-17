using PhoneBookMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookMobile.Interfaces.Services
{
    public interface IContactService
    {
        Task<List<Contact>> GetAllContacts(); 
        Task<Contact> GetContactById(int id); 
        Task<Contact> CreateContact(Contact contactToCreate); 
        Task<bool> DeleteContact(int id); 
        Task<Contact> UpdateContact(Contact contactToUpdate);
    }
}
