using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CSharp2SqlLibrary {
    public class Vendors {

        public static Connection Connection { get; set; }

        private const string SqlGetAll = "SELECT * From Vendors;";
        private const string SqlGetByPk = SqlGetAll + "WHERE ID = @Id";
        private const string SqlDelete = "DELETE FROM Vendors WHERE ID = @Id";
        private const string SqlUpdate = "UPDATE Vendors Set" +
            "Code = @Code, Name = @Name, Address = @Address, City = @City, State = @State, Zip = @Zip, Phone = @Phone, Email = @Email " +
            "WHERE ID = @Id";
        private const string SqlInsert = "INSERT into Vendors" +
            "(Code, Name, Address, City, State, Zip, Phone, Email)" +
            "VALUES (@Code, @Name, @Address, @City, @State, @Zip, @Phone, @Email)";

        public static List<Vendors> GetAll() {
            var sqlcmd = new SqlCommand(SqlGetAll, Connection.sqlConnection);
            var reader = sqlcmd.ExecuteReader();
            var vendors = new List<Vendors>();
            while (reader.Read()) {
                var vendor = new Vendors();
                vendors.Add(vendor);
                LoadVendorFromSql(vendor, reader);
            }
            reader.Close();
            return vendors;
        }

        private static void LoadVendorFromSql(Vendors vendor, SqlDataReader reader) {
            vendor.ID = (int)reader["Id"];
            vendor.Code = reader["Code"].ToString();
            vendor.Name = reader["Name"].ToString();
            vendor.Address = reader["Address"].ToString();
            vendor.City = reader["City"].ToString();
            vendor.State = reader["State"].ToString();
            vendor.Zip = reader["Zip"].ToString();
            vendor.Phone = reader["Phone"]?.ToString();
            vendor.Email = reader["Email"]?.ToString();
        }

            public int ID { get; private set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Zip { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }

        //private static void SetParameterValues(Vendors user, SqlCommand sqlcmd) {
        //    sqlcmd.Parameters.AddWithValue("@ID", user.ID);
        //    sqlcmd.Parameters.AddWithValue("@Code", user.Code);
        //    sqlcmd.Parameters.AddWithValue("@Name", user.Name);
        //    sqlcmd.Parameters.AddWithValue("@Address", user.Address);
        //    sqlcmd.Parameters.AddWithValue("@City", user.City); 
        //    sqlcmd.Parameters.AddWithValue("@State", user.State); 
        //    sqlcmd.Parameters.AddWithValue("@Zip", user.Zip);
        //    sqlcmd.Parameters.AddWithValue("@Phone", user.Phone, (object)user.Phone ?? DBNULL.Value);
        //    sqlcmd.Parameters.AddWithValue("@Email", user.Email, (object)user.Email ?? DBNULL.Value);
        //}   

    }
}
