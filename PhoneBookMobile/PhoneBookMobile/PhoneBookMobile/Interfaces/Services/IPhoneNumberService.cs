using PhoneBookMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookMobile.Interfaces.Services
{
    public interface IPhoneNumberService
    {
        Task<List<PhoneNumber>> GetAllPhoneNumbers(); 
        Task<PhoneNumber> GetPhoneNumberById(int id); 
        Task<PhoneNumber> CreatePhoneNumber(PhoneNumber phoneNumberToCreate); 
        Task<bool> DeletePhoneNumber(int id); 
        Task<PhoneNumber> UpdatePhoneNumber(PhoneNumber phoneNumberToUpdate);
    }
}
