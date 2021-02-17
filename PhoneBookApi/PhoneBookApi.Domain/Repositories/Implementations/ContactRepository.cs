using Microsoft.EntityFrameworkCore;
using PhoneBookApi.Data.Entities;
using PhoneBookApi.Data.Entities.Models;
using PhoneBookApi.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBookApi.Domain.Repositories.Implementations
{
    public class ContactRepository : IContactRepository
    {
        private readonly PhoneBookApiDbContext _context;

        public ContactRepository(PhoneBookApiDbContext context)
        {
            _context = context;
        }

        public List<Contact> GetAll()
        {
            return _context.Contacts.ToList();
        }

        public Contact Create(Contact contactToAdd)
        {
            var createdContact = _context.Contacts.Add(contactToAdd);
            _context.SaveChanges();

            return createdContact.Entity;
        }

        public bool Delete(Contact contactToDelete)
        {
            var deletedEntity = _context.Contacts.Remove(contactToDelete);
            _context.SaveChanges();

            return deletedEntity.State == EntityState.Deleted;
        }

        public bool DeleteById(int id)
        {
            var deletedEntity = _context.Contacts.Remove(GetById(id));
            _context.SaveChanges();

            return deletedEntity.State == EntityState.Deleted;
        }

        public Contact Edit(Contact newContact)
        {
            var contactToEdit = GetById(newContact.Id);
            contactToEdit.Name = newContact.Name;
            _context.SaveChanges();

            return contactToEdit;
        }

        public Contact GetById(int id)
        {
            var contactToGet = _context.Contacts.Include(c => c.PhoneNumbers)
                                                .FirstOrDefault(c => c.Id == id);

            return contactToGet;
        }
    }
}
