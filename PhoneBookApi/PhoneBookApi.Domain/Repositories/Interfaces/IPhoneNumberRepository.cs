using PhoneBookApi.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApi.Domain.Repositories.Interfaces
{
    public interface IPhoneNumberRepository
    {
        List<PhoneNumber> GetAll();

        PhoneNumber Create(PhoneNumber contactToAdd);

        bool Delete(PhoneNumber contactToDelete);

        bool DeleteById(int id);

        PhoneNumber Edit(PhoneNumber newPhoneNumber);

        PhoneNumber GetById(int id);
    }
}
