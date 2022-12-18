using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DB.Entities
{
    internal class Email
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public int Contact_Id { get; set; }
        public char Type_Code { get; set; }
        public string LastUpdated { get; set; }

        public Email(int id, string emailAddress, int contact_Id, char type_Code, string lastUpdated)
        {
            Id = id;
            EmailAddress = emailAddress;
            Contact_Id = contact_Id;
            Type_Code = type_Code;
            LastUpdated = lastUpdated;
        }
        public Email() { }  
    }
}
