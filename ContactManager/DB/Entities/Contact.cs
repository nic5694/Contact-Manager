using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DB.Entities
{
    /*things in entitie4s dfont need to match the database perfectly
     * 
     * 
     */
    internal class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Birthday { get; set; }
        public string LastUpdated { get; set; }
        public string Created { get; set; }
        public bool Active { get; set; }
        public int Image_Id { get; set; }

        public Contact(int id, string firstName, string lastName, string title, string birthday, string lastUpdated, string created, bool active, int image_Id)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Title = title;
            Birthday = birthday;
            LastUpdated = lastUpdated;
            Created = created;
            Active = active;
            Image_Id = image_Id;
        }
        public Contact() { }
        public Contact(int id, string firstName, string lastName, string lastUpdated, bool active, string created)
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
