using PhoneBookApi.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApi.Domain.Repositories.Interfaces
{
    public interface IContactRepository
    {
        List<Contact> GetAll();

        Contact Create(Contact contactToAdd);

        bool Delete(Contact contactToDelete);

        bool DeleteById(int id);

        Contact Edit(Contact newContact);

        Contact GetById(int id);
    }
}
