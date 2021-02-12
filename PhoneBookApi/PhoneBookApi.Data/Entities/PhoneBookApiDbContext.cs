using Microsoft.EntityFrameworkCore;
using PhoneBookApi.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApi.Data.Entities
{
    public class PhoneBookApiDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

        public PhoneBookApiDbContext(DbContextOptions options) : base(options)
        { }
    }
}
