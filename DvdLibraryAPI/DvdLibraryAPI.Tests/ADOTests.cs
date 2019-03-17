using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibraryAPI.Tests
{
    [TestFixture]
    public class ADOTests
    {
        [OneTimeSetUp]
        [OneTimeTearDown]
        public void ResetDatabase()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Data Source=localhost;initial catalog=DvdLibrary;persist security info=True;user id=DvdLibraryApp;password=testing123;MultipleActiveResultSets=True;";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "HardReset";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
