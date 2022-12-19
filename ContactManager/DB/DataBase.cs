using ContactManager.DB.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace ContactManager.DB
{

    internal class DataBase
    {
        private string ConString = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;
        private string updateContactString = "Update Contact set LastUpdated = GETDATE() where Id = @NeededId";
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
                        if (readInfo["Birthday"] != DBNull.Value)
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
                            address.LastUpdated = readAddress["LastUpdated"].ToString();
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
                            email.LastUpdated = readEmail["LastUpdated"].ToString();
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
                            phone.LastUpdated = readPhone["LastUpdated"].ToString();
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

            String query = "Update Contact set Active = 0, LastUpdated = GETDATE() where id = @id ";

            SqlCommand cmd = new SqlCommand(query, c);

            cmd.Parameters.AddWithValue("@id", contactId);

            cmd.ExecuteNonQuery();

            c.Close();

        }

        public void AddNewContact(Contact contact)
        {
            using (SqlConnection c = new SqlConnection(ConString))
            {

                

                String query = "Insert into Contact (FirstName,LastName,Title,Active,LastUpdated) values (@FirstName,@LastName,@Title,1,GETDATE())";

                SqlCommand cmd = new SqlCommand(query, c);
                cmd.Parameters.AddWithValue("@FirstName", contact.FirstName);
                cmd.Parameters.AddWithValue("@LastName", contact.LastName);
                cmd.Parameters.AddWithValue("@Title", contact.Title);
                
                c.Open();

                cmd.ExecuteNonQuery();

                string queryNewId = "Select @@Identity as newId from Contact";
                cmd.CommandText = queryNewId;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = c;
                var newId = Convert.ToInt32(cmd.ExecuteScalar());

                if (contact.Birthday != new DateTime(0001,01,01))
                {
                    String query2 = "Update Contact set Birthday=@Birthday where Id=@Id";
                    SqlCommand cmd2 = new SqlCommand(query2, c);
                    cmd2.Parameters.AddWithValue("@Id", newId);
                    cmd2.Parameters.AddWithValue("@Birthday", contact.Birthday.ToString());
                    cmd2.ExecuteNonQuery();
                }


                List<Address> addresses = contact.Addresses;

                if (addresses != null)
                {
                    foreach (Address a in addresses)
                    {
                        String query2 = "Insert into Address (StreetAddress,City,Province,PostalCode,Country,ApartmentNumber,Contact_Id,Type_Code,LastUpdated) values (@StreetAddress,@City,@Province,@PostalCode,@Country,@ApartmentNumber,@Contact_Id,@Type_Code,GETDATE())";

                        SqlCommand cmd2 = new SqlCommand(query2, c);
                        cmd2.Parameters.AddWithValue("@StreetAddress", a.StreetAddress);
                        cmd2.Parameters.AddWithValue("@City", a.City);
                        cmd2.Parameters.AddWithValue("@Province", a.Province);
                        cmd2.Parameters.AddWithValue("@PostalCode", a.PostalCode);
                        cmd2.Parameters.AddWithValue("@Country", a.Country);
                        cmd2.Parameters.AddWithValue("@ApartmentNumber", a.ApartmentNumber);
                        cmd2.Parameters.AddWithValue("@Contact_Id", newId);
                        cmd2.Parameters.AddWithValue("@Type_Code", a.Type_Code);

                        cmd2.ExecuteNonQuery();
                    }
                }

                List<Email> emails = contact.Emails;
                if (emails != null)
                {
                    foreach (Email e in emails)
                    {
                        String query3 = "Insert into Email (Email,Contact_Id,Type_Code,LastUpdated) values (@EmailAddress,@Contact_Id,@Type_Code,GETDATE())";

                        SqlCommand cmd3 = new SqlCommand(query3, c);

                        cmd3.Parameters.AddWithValue("@EmailAddress", e.EmailAddress);
                        cmd3.Parameters.AddWithValue("@Contact_Id", newId);
                        cmd3.Parameters.AddWithValue("@Type_Code", e.Type_Code);

                        cmd3.ExecuteNonQuery();
                    }

                }

                List<Phone> phones = contact.Phones;
                if (phones != null)
                {
                    foreach (Phone p in phones)
                    {
                        String query4 = "Insert into Phone (Number,ContryCode,Contact_Id,Type_Contact,LastUpdated) values (@PhoneNumber,@CountryCode,@Contact_Id,@Type_Code,GETDATE())";

                        SqlCommand cmd4 = new SqlCommand(query4, c);

                        cmd4.Parameters.AddWithValue("@PhoneNumber", p.PhoneNumber);
                        cmd4.Parameters.AddWithValue("@CountryCode", p.CountryCode);
                        cmd4.Parameters.AddWithValue("@Contact_Id", newId);
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
                String query = "Update Contact set FirstName=@FirstName,LastName=@LastName,Title=@Title, LastUpdated = GETDATE() where Id=@Id";
                SqlCommand cmd = new SqlCommand(query, c);
                cmd.Parameters.AddWithValue("@Id", contact.Id);
                cmd.Parameters.AddWithValue("@FirstName", contact.FirstName);
                cmd.Parameters.AddWithValue("@LastName", contact.LastName);
                cmd.Parameters.AddWithValue("@Title", contact.Title);
                cmd.ExecuteNonQuery();

                if(contact.Birthday != new DateTime(0001,01,01))
                {
                    String query2 = "Update Contact set Birthday=@Birthday where Id=@Id";
                    SqlCommand cmd2 = new SqlCommand(query2, c);
                    cmd2.Parameters.AddWithValue("@Id", contact.Id);
                    cmd2.Parameters.AddWithValue("@Birthday", contact.Birthday.ToString());
                    cmd2.ExecuteNonQuery();
                }
            }

        }

        public Address GetAddress(int addressId) {
            
            SqlConnection c = new SqlConnection(ConString);
            Address address = new Address();

            c.Open();

            string query = "Select * from Address where id = @id";

            SqlCommand cmd = new SqlCommand(query, c);

            cmd.Parameters.AddWithValue("@id", addressId);

            SqlDataReader readInfo = cmd.ExecuteReader();

            while (readInfo.Read()) {

                address.StreetAddress = readInfo["StreetAddress"].ToString();
                address.City = readInfo["City"].ToString();
                address.Province = readInfo["Province"].ToString();
                address.PostalCode = readInfo["PostalCode"].ToString();
                address.Country = readInfo["Country"].ToString();
                address.ApartmentNumber = (int)readInfo["ApartmentNumber"];
                address.Contact_Id = (int)readInfo["Contact_Id"];
                address.Type_Code = readInfo["Type_Code"].ToString().ToCharArray()[0];
                address.Id = (int)readInfo["Id"];
                address.LastUpdated = readInfo["LastUpdated"].ToString();
            }

            return address;
        }

        public Phone GetPhone(int phoneId)
        {
            SqlConnection c = new SqlConnection(ConString);
            Phone phone = new Phone();

            c.Open();

            string query = "Select * from Phone where id = @id";

            SqlCommand cmd = new SqlCommand(query, c);

            cmd.Parameters.AddWithValue("@id", phoneId);

            SqlDataReader readInfo = cmd.ExecuteReader();

            while (readInfo.Read())
            {
                phone.Type_Code = readInfo["Type_Contact"].ToString().ToCharArray()[0];
                phone.CountryCode = readInfo["ContryCode"].ToString();
                phone.PhoneNumber = readInfo["Number"].ToString();
                phone.Contact_Id = (int) readInfo["ContacT_Id"];
                phone.Id = (int)readInfo["Id"];
                phone.LastUpdated = readInfo["LastUpdated"].ToString();
            }

            return phone;
        }

        public Email GetEmail(int emailId)
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
                email.Contact_Id = (int)readInfo["Contact_Id"];
                email.LastUpdated = readInfo["LastUpdated"].ToString();
                email.Id = (int)readInfo["Id"];
            }


            return email;
        }

        public void AddPhoneToExistingContact(Phone p)
        {
            using (SqlConnection c = new SqlConnection(ConString))
            {
                c.Open();
                String query = "Update Phone set Number = @PhoneNumber, ContryCode = @CountryCode, Contact_Id = @Contact_Id, Type_Contact = @Type_Contact ,LastUpdated = GETDATE() where Id = @Id";
                SqlCommand cmd = new SqlCommand(query, c);
                cmd.Parameters.AddWithValue("@PhoneNumber", p.PhoneNumber);
                cmd.Parameters.AddWithValue("@CountryCode", p.CountryCode);
                cmd.Parameters.AddWithValue("@Contact_Id", p.Contact_Id);
                cmd.Parameters.AddWithValue("@Type_Contact", p.Type_Code);
                cmd.Parameters.AddWithValue("@Id", p.Id);
                cmd.ExecuteNonQuery();
                SqlCommand updateContact = new SqlCommand(updateContactString, c);
                updateContact.Parameters.AddWithValue("@NeededId", p.Contact_Id);
                updateContact.ExecuteNonQuery();
            }
        }

        public void UpdateEmailExistingContact(Email e)
        {
            using (SqlConnection c = new SqlConnection(ConString))
            {
                c.Open();
                string emailUpdate = "Update Email set Email = @Email, Contact_Id=@Contact_Id, Type_Code = @Type_Code, LastUpdated = GETDATE() where Id = @Id";
                SqlCommand cmd4 = new SqlCommand(emailUpdate, c);
                cmd4.Parameters.AddWithValue("@Email", e.EmailAddress);
                cmd4.Parameters.AddWithValue("@Contact_Id", e.Contact_Id);
                cmd4.Parameters.AddWithValue("@Type_Code", e.Type_Code);
                cmd4.Parameters.AddWithValue("@Id", e.Id);
                cmd4.ExecuteNonQuery();
                SqlCommand updateContact = new SqlCommand(updateContactString, c);
                updateContact.Parameters.AddWithValue("@NeededId", e.Contact_Id);
                updateContact.ExecuteNonQuery();
            }
        }

        public void UpdateAddressExistingContact(Address a)
        {
            using(SqlConnection c = new SqlConnection(ConString))
            {
                c.Open();
                string query = "Update Address set StreetAddress = @StreetAddress, City = @City, Province = @Province, PostalCode = @PostalCode, Country = @Country,Contact_ID = @Contact_Id, ApartmentNumber = @ApartmentNumber, Type_Code = @Type_Code, LastUpdated = GETDATE() where Id = @Id";
                SqlCommand cmd2 = new SqlCommand(query, c);
                cmd2.Parameters.AddWithValue("@StreetAddress", a.StreetAddress);
                cmd2.Parameters.AddWithValue("@City", a.City);
                cmd2.Parameters.AddWithValue("@Province", a.Province);
                cmd2.Parameters.AddWithValue("@PostalCode", a.PostalCode);
                cmd2.Parameters.AddWithValue("@Country", a.Country);
                cmd2.Parameters.AddWithValue("@ApartmentNumber", a.ApartmentNumber);
                cmd2.Parameters.AddWithValue("@Id", a.Id);
                cmd2.Parameters.AddWithValue("@Type_Code", a.Type_Code);
                cmd2.Parameters.AddWithValue("Contact_Id", a.Contact_Id);
                cmd2.ExecuteNonQuery();
                cmd2.CommandText = "Update Contact set LastUpdated = GETDATE() where Id = @NeededId";
                cmd2.Parameters.AddWithValue("@NeededId", a.Contact_Id);
                cmd2.ExecuteNonQuery();
            }
        }       

        public List<Address> getAllAddresses(int contactId)
        {
            SqlConnection c = new SqlConnection(ConString);

            c.Open();
            SqlCommand cmd = new SqlCommand("Select * from Address where Contact_Id = @Id", c);

            cmd.Parameters.AddWithValue("@Id", contactId);

            SqlDataReader readAddress = cmd.ExecuteReader();

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
                address.LastUpdated = readAddress["LastUpdated"].ToString();
                addresses.Add(address);

            }

            return addresses;
        }

        public List<Email> getAllEmails(int contactId)
        {
            SqlConnection c = new SqlConnection(ConString);
            
            c.Open();
            SqlCommand cmd = new SqlCommand("Select * from Email where Contact_Id = @Id", c);
            
            cmd.Parameters.AddWithValue("@Id", contactId);

            SqlDataReader readEmail = cmd.ExecuteReader();
                
            List<Email> emails = new List<Email>();

            while (readEmail.Read())
            {
                Email email = new Email();
                email.Id = (int)readEmail["Id"];
                email.EmailAddress = readEmail["Email"].ToString();
                email.Contact_Id = (int)readEmail["Contact_Id"];
                email.Type_Code = readEmail["Type_Code"].ToString().ToCharArray()[0];
                email.LastUpdated = readEmail["LastUpdated"].ToString();
                emails.Add(email);

            }

            return emails;
        }

        public List<Phone> getAllPhones(int contactId)
        {
            SqlConnection c = new SqlConnection(ConString);

            c.Open();
            SqlCommand cmd = new SqlCommand("Select * from Phone where Contact_Id = @Id", c);

            cmd.Parameters.AddWithValue("@Id", contactId);

            SqlDataReader readPhone = cmd.ExecuteReader();

            List<Phone> phones = new List<Phone>();

            while (readPhone.Read())
            {
                Phone phone = new Phone();
                phone.Id = (int)readPhone["Id"];
                phone.PhoneNumber = readPhone["Number"].ToString();
                phone.CountryCode = readPhone["ContryCode"].ToString();
                phone.Contact_Id = (int)readPhone["Contact_Id"];
                phone.Type_Code = readPhone["Type_Contact"].ToString().ToCharArray()[0];
                phone.LastUpdated = readPhone["LastUpdated"].ToString();
                phones.Add(phone);
            }

            return phones;
        }
    }
}

