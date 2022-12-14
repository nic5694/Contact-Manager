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
        private string ConString = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;
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
            contact.FirstName = reader["FirstName"].ToString();
            contact.LastName = reader["LastName"].ToString();
            contact.LastUpdated = reader["LastUpdated"].ToString();
            contact.Created = reader["Created"].ToString();
            con.Close();
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
                    //TODO check null coalescence
                    Contact contact = new Contact();
                    contact.Title = reader["Title"].ToString();
                    contact.Id = (int)reader["Id"];
                    contact.FirstName = reader["FirstName"].ToString();
                    contact.LastName = reader["LastName"].ToString();
                    contact.LastUpdated = reader["LastUpdated"].ToString();
                    contact.Active = (bool)reader["Active"];
                    contact.Created = reader["Created"].ToString();
                    contacts.Add(new Contact(contact.Id, contact.FirstName, contact.LastName, contact.LastUpdated, contact.Active, contact.Created));
                }
                con.Close();
                return contacts;
            }
        }
        //GetAddresses
        //GetAddress
    }
}
