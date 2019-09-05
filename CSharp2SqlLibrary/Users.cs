using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CSharp2SqlLibrary {
    public class Users {

            public static Connection Connection { get; set; }

        public static List<Users> GetAll() {
            var sql = "SELECT * From Users;";
            var sqlcmd = new SqlCommand(sql, Connection._Connection);
            var reader = sqlcmd.ExecuteReader();
            var users = new List<Users>();
            while(reader.Read()) {
                var user = new Users();
                users.Add(user);
               
                user.ID = (int)reader["ID"];
                user.Username = reader["Username"].ToString();
                user.Password = reader["Password"].ToString();
                user.FirstName = reader["FirstName"].ToString();
                user.LastName = reader["LastName"].ToString();
                user.Phone = reader["Phone"]?.ToString(); 
                user.Email = reader["Email"]?.ToString();
                user.IsReviewer = (bool)reader["IsReviewer"];
                user.IsAdmin = (bool)reader["IsAdmin"];
            }
            return users;
        }

            public int ID { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public bool? IsReviewer { get; set; }
            public bool? IsAdmin { get; set; }

        public Users() {

        }
    }
}
