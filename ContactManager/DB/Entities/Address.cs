using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DB.Entities
{
    internal class Address
    {
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public int ApartmentNumber { get; set; }
        public int Contact_Id { get; set; }
        public char Type_Code { get; set; }
        public DateTime LastUpdated { get; set; }

        public Address(int id, string streetAddress, string city, string province, string postalCode, string country, int apartmentNumber, int contact_Id, char type_Code, DateTime lastUpdated)
        {
            Id = id;
            StreetAddress = streetAddress;
            City = city;
            Province = province;
            PostalCode = postalCode;
            Country = country;
            ApartmentNumber = apartmentNumber;
            Contact_Id = contact_Id;
            Type_Code = type_Code;
            LastUpdated = lastUpdated;
        }

        public Address() { }

        public override string ToString()
        {
            return ApartmentNumber + " " + StreetAddress + " ," + City + " " + Province;
        }
    }
}
