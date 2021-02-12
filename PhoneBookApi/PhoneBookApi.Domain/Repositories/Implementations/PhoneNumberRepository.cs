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
    public class PhoneNumberRepository : IPhoneNumberRepository
    {
        private readonly PhoneBookApiDbContext _context;

        public PhoneNumberRepository(PhoneBookApiDbContext context)
        {
            _context = context;
        }

        public List<PhoneNumber> GetAll()
        {
            return _context.PhoneNumbers.ToList();
        }

        public PhoneNumber Create(PhoneNumber phoneNumberToAdd)
        {
            var createdPhoneNumber = _context.PhoneNumbers.Add(phoneNumberToAdd);
            _context.SaveChanges();

            return createdPhoneNumber.Entity;
        }

        public bool Delete(PhoneNumber phoneNumberToDelete)
        {
            var deletedEntity = _context.PhoneNumbers.Remove(phoneNumberToDelete);
            _context.SaveChanges();

            return deletedEntity.State == EntityState.Deleted;
        }

        public bool DeleteById(int id)
        {
            var deletedEntity = _context.PhoneNumbers.Remove(GetById(id));
            _context.SaveChanges();

            return deletedEntity.State == EntityState.Deleted;
        }

        public PhoneNumber Edit(PhoneNumber newPhoneNumber)
        {
            var phoneNumberToEdit = GetById(newPhoneNumber.Id);
            phoneNumberToEdit.Value = newPhoneNumber.Value;
            _context.SaveChanges();

            return phoneNumberToEdit;
        }

        public PhoneNumber GetById(int id)
        {
            return _context.PhoneNumbers.Find(id);
        }
    }
}
