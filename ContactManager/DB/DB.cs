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
        public void GetContact(int id)
        {
            SqlCommand sq = new SqlCommand("Select * from Contact where Id = @Id", con);
            sq.Parameters.AddWithValue("@Id", id);
            con.Open();
            SqlDataReader reader = sq.ExecuteReader();
            string firstName = reader["firstName"].ToString();
        }
        //GetAddresses
        //GetAddress
    }
}
