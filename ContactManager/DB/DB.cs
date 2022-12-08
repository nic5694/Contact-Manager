using ContactManager.DB.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DB
{

    internal class DataBase
    {
        private string ConString = ConfigurationManager.ConnectionStrings["conf"].ConnectionString;
        SqlConnection con;
        public DataBase()
        {
            con = new SqlConnection(ConString);
        }
        //GetContacts
        public List<Contact> GetContacts()
        {
            return null;
        }
        //GetContact
        public Contact GetContact(int id)
        {
            SqlCommand sq = new SqlCommand("Select * from Contact where Id = @Id", con);
            sq.Parameters.AddWithValue("@Id", id);
            con.Open();
            SqlDataReader reader = sq.ExecuteReader();
            Contact contact = new Contact();
            contact.FirstName = reader["firstName"].ToString();
            contact.LastName = reader["lastName"].ToString();
            contact.LastUpdated = reader["LastUpdated"].ToString();
            contact.Created = reader["Created"].ToString();
            return contact;
        }
        public List<Contact> getAllContacts()
        {
            {
                List<Contact> contacts = new List<Contact>();
                SqlCommand sq = new SqlCommand("Select * from Contact", con);
                con.Open();
                SqlDataReader reader = sq.ExecuteReader();
                while (reader.Read())
                {
                    Contact contact = new Contact();
                    contact.Id = (int)reader["Id"];
                    contact.FirstName = reader["firstName"].ToString();
                    contact.LastName = reader["lastName"].ToString();
                    contact.LastUpdated = reader["LastUpdated"].ToString();
                    contact.Created = reader["Created"].ToString();
                    contacts.Add(contact);
                }
                return contacts;
            }
        }
        //GetAddresses
        //GetAddress
    }
}
