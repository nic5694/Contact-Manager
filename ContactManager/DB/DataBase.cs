﻿using ContactManager.DB.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DB
{

    internal class DataBase
    {
        private string ConString = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;
        public DataBase()
        { }

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
                        contact.Birthday = (DateTime)readInfo["Birthday"];
                        contact.LastUpdated = readInfo["LastUpdated"].ToString();
                        contact.Created = readInfo["Created"].ToString();
                    }
                }
                using (SqlCommand getAdresses = new SqlCommand("Select * from Address where Contact_Id = @Id", c))
                {
                    getAdresses.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader readAddress = getAdresses.ExecuteReader())
                    {
                        List<Address> addresses = new List<Address>();

                        while (readAddress.Read())
                        {
                            Address address = new Address();
                            address.Id = (int)readAddress["Id"];
                            address.StreetAddress = readAddress["StreetAddress"].ToString();
                            address.City = readAddress["City"].ToString();
                            address.Province = readAddress["Province"].ToString();
                            address.PostalCode = readAddress["PostalCode"].ToString();
                            address.Country = readAddress["Country"].ToString();
                            address.ApartmentNumber = (int)readAddress["ApartmentNumber"];
                            address.Contact_Id = (int)readAddress["Contact_Id"];
                            address.Type_Code = readAddress["Type_Code"].ToString().ToCharArray()[0];
                            address.LastUpdated = (DateTime)readAddress["LastUpdated"];
                            addresses.Add(address);

                        }

                        contact.Addresses = addresses;
                    }
                }

                using (SqlCommand getEmail = new SqlCommand("Select * from Email where Contact_Id = @Id", c))
                {
                    getEmail.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader readEmail = getEmail.ExecuteReader())
                    {
                        List<Email> emails = new List<Email>();

                        while (readEmail.Read())
                        {
                            Email email = new Email();
                            email.Id = (int)readEmail["Id"];
                            email.EmailAddress = readEmail["Email"].ToString();
                            email.Contact_Id = (int)readEmail["Contact_Id"];
                            email.Type_Code = readEmail["Type_Code"].ToString().ToCharArray()[0];
                            email.LastUpdated = (DateTime)readEmail["LastUpdated"];
                            emails.Add(email);

                        }

                        contact.Emails = emails;
                    }
                }
                using (SqlCommand getPhone = new SqlCommand("Select * from Phone where Contact_Id = @Id", c))
                {
                    getPhone.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader readPhone = getPhone.ExecuteReader())
                    {
                        List<Phone> phones = new List<Phone>();

                        while (readPhone.Read())
                        {
                            Phone phone = new Phone();
                            phone.Id = (int)readPhone["Id"];
                            phone.PhoneNumber = readPhone["Number"].ToString();
                            phone.CountryCode = readPhone["ContryCode"].ToString();
                            phone.Contact_Id = (int)readPhone["Contact_Id"];
                            phone.Type_Code = readPhone["Type_Contact"].ToString().ToCharArray()[0];
                            phone.LastUpdated = (DateTime)readPhone["LastUpdated"];
                            phones.Add(phone);
                        }

                        contact.Phones = phones;
                    }
                }
                return new Contact(contact.Id, contact.FirstName, contact.LastName, contact.Title, contact.Birthday, contact.Addresses, contact.Emails, contact.Phones, contact.LastUpdated, contact.Created, contact.Active, contact.Image_Id);
            }
        }
        public List<Contact> GetAllContacts()
        {

            List<Contact> contacts = new List<Contact>();
            // List<int> ids = new List<int>();
            using (SqlConnection c = new SqlConnection(ConString))
            {
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
                        contact.LastUpdated = reader["LastUpdated"].ToString();
                        contact.Active = (bool)reader["Active"];
                        contact.Created = reader["Created"].ToString();
                        contacts.Add(new Contact(contact.Id, contact.FirstName, contact.LastName, contact.LastUpdated, contact.Created, contact.Active));
                        //  ids.Add(contact.Id);
                    }
                }
            }/*
            foreach (int id in ids)
            {
                contacts.Add(GetContact(id));
            }*/
            return contacts;

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
            using (SqlConnection c = new SqlConnection(ConString))
            {

                c.Open();

                String query = "Insert into Contact (FirstName,LastName,Title,Birthday,Active,LastUpdated) values (@FirstName,@LastName,@Title,@Birthday,1,GETDATE())";

                SqlCommand cmd = new SqlCommand(query, c);
                cmd.Parameters.AddWithValue("@FirstName", contact.FirstName);
                cmd.Parameters.AddWithValue("@LastName", contact.LastName);
                cmd.Parameters.AddWithValue("@Title", contact.Title);
                cmd.Parameters.AddWithValue("@Birthday", contact.Birthday.ToString());

                cmd.ExecuteNonQuery();

                List<Address> addresses = contact.Addresses;

                if (addresses != null)
                {
                    foreach (Address a in addresses)
                    {
                        String query2 = "Insert into Address (StreetAddress,City,Province,PostalCode,Country,ApartmentNumber,Contact_Id,Type_Code) values (@StreetAddress,@City,@Province,@PostalCode,@Country,@ApartmentNumber,@Contact_Id,@Type_Code)";

                        SqlCommand cmd2 = new SqlCommand(query2, c);
                        cmd2.Parameters.AddWithValue("@StreetAddress", a.StreetAddress);
                        cmd2.Parameters.AddWithValue("@City", a.City);
                        cmd2.Parameters.AddWithValue("@Province", a.Province);
                        cmd2.Parameters.AddWithValue("@PostalCode", a.PostalCode);
                        cmd2.Parameters.AddWithValue("@Country", a.Country);
                        cmd2.Parameters.AddWithValue("@ApartmentNumber", a.ApartmentNumber);
                        cmd2.Parameters.AddWithValue("@Contact_Id", contact.Id);
                        cmd2.Parameters.AddWithValue("@Type_Code", a.Type_Code);

                        cmd2.ExecuteNonQuery();
                    }
                }

                List<Email> emails = contact.Emails;
                if (emails != null)
                {
                    foreach (Email e in emails)
                    {
                        String query3 = "Insert into Email (EmailAddress,Contact_Id,Type_Code) values (@EmailAddress,@Contact_Id,@Type_Code)";

                        SqlCommand cmd3 = new SqlCommand(query3, c);

                        cmd3.Parameters.AddWithValue("@EmailAddress", e.EmailAddress);
                        cmd3.Parameters.AddWithValue("@Contact_Id", contact.Id);
                        cmd3.Parameters.AddWithValue("@Type_Code", e.Type_Code);

                        cmd3.ExecuteNonQuery();
                    }

                }

                List<Phone> phones = contact.Phones;
                if (phones != null)
                {
                    foreach (Phone p in phones)
                    {
                        String query4 = "Insert into Phone (PhoneNumber,Contact_Id,Type_Code) values (@PhoneNumber,@Contact_Id,@Type_Code)";

                        SqlCommand cmd4 = new SqlCommand(query4, c);

                        cmd4.Parameters.AddWithValue("@PhoneNumber", p.PhoneNumber);
                        cmd4.Parameters.AddWithValue("@Contact_Id", contact.Id);
                        cmd4.Parameters.AddWithValue("@Type_Code", p.Type_Code);

                        cmd4.ExecuteNonQuery();
                    }
                }

            }
        }

        public void EditExistingContact(Contact contact)
        {
            using (SqlConnection c = new SqlConnection(ConString))
            {
                c.Open();
                String query = "Update Contact set FirstName = @FirstName, LastName = @LastName, Title = @Title, Birthday = @Birthday where Id = @Id";
                SqlCommand cmd = new SqlCommand(query, c);
                cmd.Parameters.AddWithValue("@Id", contact.Id);
                cmd.Parameters.AddWithValue("@FirstName", contact.FirstName);
                cmd.Parameters.AddWithValue("@LastName", contact.LastName);
                cmd.Parameters.AddWithValue("@Title", contact.Title);
                cmd.Parameters.AddWithValue("@Birthday", contact.Birthday);
                cmd.ExecuteNonQuery();

                List<Address> addresses = contact.Addresses;

                if (addresses != null)
                {
                    foreach (Address a in addresses)
                    {
                        string addressUpdate = "Update Address set StreetAddress = @StreetAddress, City = @City, Province = @Province, PostalCode = @PostalCode, Country = @Country, ApartmentNumber = @ApartmentNumber, Type_Code = @Type_Code where Id = @Id";
                        SqlCommand cmd2 = new SqlCommand(addressUpdate, c);

                        cmd2.Parameters.AddWithValue("@StreetAddress", a.StreetAddress);
                        cmd2.Parameters.AddWithValue("@City", a.City);
                        cmd2.Parameters.AddWithValue("@Province", a.Province);
                        cmd2.Parameters.AddWithValue("@PostalCode", a.PostalCode);
                        cmd2.Parameters.AddWithValue("@Contry", a.Country);
                        cmd2.Parameters.AddWithValue("@ApartmentNumber", a.ApartmentNumber);
                        cmd2.Parameters.AddWithValue("Type_Code", a.Type_Code);
                        cmd2.Parameters.AddWithValue("@Id", a.Id);

                        cmd2.ExecuteNonQuery();
                    }
                }

                List<Phone> phones = contact.Phones;
                if (phones != null)
                {
                    foreach (Phone p in phones)
                    {
                        string phoneUpdate = "Update Phone set Number = @Number, CountryCode = @CountryCode, Contact_Id = @ContactId, Type_Code = @Type_Code where Id = @Id";
                        SqlCommand cmd3 = new SqlCommand(phoneUpdate, c);
                        cmd3.Parameters.AddWithValue("@Number", p.PhoneNumber);
                        cmd3.Parameters.AddWithValue("@CountryCode", p.CountryCode);
                        cmd3.Parameters.AddWithValue("@ContactId", p.Contact_Id);
                        cmd3.Parameters.AddWithValue("@Type_Code", p.Type_Code);
                        cmd3.Parameters.AddWithValue("@Id", p.Id);
                        cmd3.ExecuteNonQuery();
                    }
                }

                List<Email> emails = contact.Emails;
                if (emails != null)
                {
                    foreach (Email e in emails)
                    {
                        string emailUpdate = "Update Email set Email = @Email, Contact_Id=@Contact_Id, Type_Code = @Type_Code where Id = @Id";
                        SqlCommand cmd4 = new SqlCommand(emailUpdate, c);
                        cmd4.Parameters.AddWithValue("@Email", e.EmailAddress);
                        cmd4.Parameters.AddWithValue("@Contact_Id", e.Contact_Id);
                        cmd4.Parameters.AddWithValue("@Type_Code", e.Type_Code);
                        cmd4.Parameters.AddWithValue("@Id", e.Id);
                        cmd4.ExecuteNonQuery();
                    }
                }


            }

        }

        public Address getAddress(int addressId) { 
            return null;
        }

        public Address getPhone(int addressId)
        {
            return null;
        }

        public Email getEmail(int emailId)
        {
            SqlConnection c = new SqlConnection(ConString);
            Email email = new Email();
            
            c.Open();

            string query = "Select * from Email where id = @id";

            SqlCommand cmd = new SqlCommand(query, c);

            cmd.Parameters.AddWithValue("@id", emailId);

            SqlDataReader readInfo = cmd.ExecuteReader();

            while (readInfo.Read())
            {
                email.Type_Code = readInfo["Type_Code"].ToString().ToCharArray()[0];
                email.EmailAddress = readInfo["Email"].ToString();
            }


            return email;
        }

    }
}

