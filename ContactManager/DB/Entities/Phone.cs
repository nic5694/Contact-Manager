using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DB.Entities
{
    internal class Phone
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
        public int Contact_Id { get; set; }
        public char Type_Code { get; set; }
        public string LastUpdated { get; set; }

        public Phone(int id, string phoneNumber, string countryCode, int contact_Id, char type_Code, string lastUpdated)
        {
            Id = id;
            PhoneNumber = phoneNumber;
            CountryCode = countryCode;
            Contact_Id = contact_Id;
            Type_Code = type_Code;
            LastUpdated = lastUpdated;
        }

        public Phone() { }
    }
}
