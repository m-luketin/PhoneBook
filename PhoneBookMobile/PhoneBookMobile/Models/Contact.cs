using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookMobile.Models
{
    public class Contact
    {
        public Contact(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }
    }
}
