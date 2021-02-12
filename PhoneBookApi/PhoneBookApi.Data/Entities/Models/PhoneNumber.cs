using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApi.Data.Entities.Models
{
    public class PhoneNumber
    {
        public PhoneNumber(string value)
        {
            Value = value;
        }

        public int Id { get; set; }
        public string Value { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
