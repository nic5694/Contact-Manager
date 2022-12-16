using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DB.Entities
{
    /*things in entitie4s dfont need to match the database perfectly
     * 
     * 
     */
    //address entity everty table is going to be a diffrent eentity 
    //for the type you would include the type in that entity you would do a join with the type 
    //type would be a field in address
    //but both one description one char
    //
    internal class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Birthday { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Email> Emails { get; set; }
        public List<Phone> Phones { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime Created { get; set; }
        public bool Active { get; set; }
        public int Image_Id { get; set; }

        public Contact(int id, string firstName, string lastName, string title, string birthday, List<Address> addresses, List<Email> emails, List<Phone> phones, DateTime lastUpdated, DateTime created, bool active, int image_Id)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Title = title;
            Birthday = birthday;
            Addresses = addresses;
            Emails = emails;
            Phones = phones;
            LastUpdated = lastUpdated;
            Created = created;
            Active = active;
            Image_Id = image_Id;
        }
        public Contact() { }
        public Contact(int id, string firstName, string lastName, DateTime lastUpdated, DateTime created, bool active)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            LastUpdated = lastUpdated;
            Active = active;
            Created = created;
        }
    }
}
