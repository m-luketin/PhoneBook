using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PhoneBookApi.Data.Entities.Models
{
    public class Contact
    {
        public Contact(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
    }
}
