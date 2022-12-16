using ContactManager.DB.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DB
{

    internal class DataBase
    {
        private string ConString = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;
        public DataBase()
        {}

        //GetContact
        public Contact GetContact(int id)
        {
            SqlConnection c = new SqlConnection(ConString);

            using (c)
            {
                Contact contact = new Contact();
                c.Open();
                using (SqlCommand getContactInfo = new SqlCommand("Select * from Contact where Id = @Id", c))
                {
                    getContactInfo.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader readInfo = getContactInfo.ExecuteReader())
                    {
                        readInfo.Read();
                        contact.Title = readInfo["Title"].ToString();
                        contact.Id = (int)readInfo["Id"];
                        contact.FirstName = readInfo["FirstName"].ToString();
                        contact.LastName = readInfo["LastName"].ToString();
                        contact.Birthday = readInfo["Birthday"].ToString();
                        contact.LastUpdated = (DateTime)readInfo["LastUpdated"];
                        contact.Created = (DateTime)readInfo["Created"];
                    }
                }
                using (SqlCommand getAdresses = new SqlCommand("Select * from Address where Contact_Id = @Id", c))
                {
                    getAdresses.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader readAddress = getAdresses.ExecuteReader())
                    {
                        while (readAddress.Read())
                        {
                            Address address = new Address();
                            address.StreetAddress = readAddress["StreetAddress"].ToString();
                            address.City = readAddress["City"].ToString();
                            address.Province = readAddress["Province"].ToString();
                            address.PostalCode = readAddress["PostalCode"].ToString();
                            address.Country = readAddress["Country"].ToString();
                            address.ApartmentNumber = (int)readAddress["ApartmentNumber"];
                            address.Contact_Id = (int)readAddress["Contact_Id"];
                            address.Type_Code = (char)readAddress["Type_Code"];
                            address.LastUpdated = (DateTime)readAddress["LastUpdated"];
                            contact.Addresses.Add(address);
                        }
                    }
                }
                using (SqlCommand getEmail = new SqlCommand("Select * from Email where Contact_Id = @Id", c))
                {
                    getEmail.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader readEmail = getEmail.ExecuteReader())
                    {
                        while (readEmail.Read())
                        {
                            Email email = new Email();
                            email.EmailAddress = readEmail["EmailAddress"].ToString();
                            email.Contact_Id = (int)readEmail["Contact_Id"];
                            email.Type_Code = (char)readEmail["Type_Code"];
                            email.LastUpdated = (DateTime)readEmail["LastUpdated"];
                            contact.Emails.Add(email);
                        }
                    }
                }
                using (SqlCommand getPhone = new SqlCommand("Select * from Phone where Contact_Id = @Id", c))
                {
                    getPhone.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader readPhone = getPhone.ExecuteReader())
                    {
                        while (readPhone.Read())
                        {
                            Phone phone = new Phone();
                            phone.PhoneNumber = readPhone["PhoneNumber"].ToString();
                            phone.Contact_Id = (int)readPhone["Contact_Id"];
                            phone.Type_Code = (char)readPhone["Type_Code"];
                            phone.LastUpdated = (DateTime)readPhone["LastUpdated"];
                            contact.Phones.Add(phone);
                        }
                    }
                }
                return contact;
            }
        }
        public List<Contact> GetAllContacts()
        {
            
                List<Contact> contacts = new List<Contact>();
                using (SqlConnection c = new SqlConnection(ConString)) {
                c.Open();
                using (SqlCommand sq = new SqlCommand("Select * from Contact", c))
                {
                    SqlDataReader reader = sq.ExecuteReader();
                    while (reader.Read())
                    {
                        //TODO check null coalescence
                        Contact contact = new Contact();
                        contact.Id = (int)reader["Id"];
                        contact.FirstName = reader["FirstName"].ToString();
                        contact.LastName = reader["LastName"].ToString();
                        contact.LastUpdated = (DateTime)reader["LastUpdated"];
                        contact.Active = (bool)reader["Active"];
                        contact.Created = (DateTime)reader["Created"];
                        contacts.Add(new Contact(contact.Id, contact.FirstName, contact.LastName, contact.LastUpdated, contact.Created, contact.Active));
                    }
                }
                return contacts;
            }
        }

        public void DesactivateContact(int contactId)
        {
            SqlConnection c = new SqlConnection(ConString);

            c.Open();

            String query = "Update Contact set Active = 0 where id = @id ";

            SqlCommand cmd = new SqlCommand(query, c);

            cmd.Parameters.AddWithValue("@id", contactId);

            cmd.ExecuteNonQuery();

            c.Close();

        }

        public void AddNewContact(Contact contact)
        {
            SqlConnection c = new SqlConnection(ConString);

            c.Open();
            
            String query = "Insert into Contact (FirstName,LastName,Title,Birthday,Active) values (@FirstName,@LastName,@Title,@Birthday,1)";

            SqlCommand cmd = new SqlCommand(query, c);

            cmd.Parameters.AddWithValue("@FirstName", contact.FirstName);
            cmd.Parameters.AddWithValue("@LastName", contact.LastName);
            cmd.Parameters.AddWithValue("@Title", contact.Title);
            cmd.Parameters.AddWithValue("@Birthday", contact.Birthday);

            cmd.ExecuteNonQuery();

            c.Close();
        }
        
        public void EditExistingContact(Contact contact)
        {
            
        }
        
    }
}

