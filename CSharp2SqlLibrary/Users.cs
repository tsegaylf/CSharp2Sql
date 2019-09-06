using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CSharp2SqlLibrary {
    public class Users {

        public static Connection Connection { get; set; }
        //private const string SqlGetAll = "SELECT * From Users;";
        //private const string SqlGetByPk = SqlGetAll + "WHERE ID = @Id";
        //private const string SqlDelete = "DELETE FROM Users WHERE ID = @Id";
        //private const string SqlUpdate = "UPDATE Users Set" +
        //    "Code = @Code, Name = @Name, Address = @Address, City = @City, State = @State, Zip = @Zip, Phone = @Phone, Email = @Email " +
        //    "WHERE ID = @Id";
        //private const string SqlInsert = "INSERT into Vendors" +
        //    "(Code, Name, Address, City, State, Zip, Phone, Email)" +
        //    "VALUES (@Code, @Name, @Address, @City, @State, @Zip, @Phone, @Email)";

        public static bool Update(Users user) {
            var sql = "Update Users Set " +
                " Username = @Username, " +
                " Password = @Password, " +
                " FirstName = @FirstName," +
                " LastName = @LastName, " +
                " Phone = @Phone, " +
                " Email = @Email, " +
                " IsAdmin = @IsAdmin, " +
                " IsReviewer = @IsReviewer " + //this is the only one that doesn't have a comma
                " WHERE ID = @Id";
            var sqlcmd = new SqlCommand(sql, Connection.sqlConnection);
            SetParameterValues(user, sqlcmd);
            sqlcmd.Parameters.AddWithValue("@Id", user.ID);
            var rowsAffected = sqlcmd.ExecuteNonQuery();
            return rowsAffected == 1;

        }

        private static void SetParameterValues(Users user, SqlCommand sqlcmd) {
            sqlcmd.Parameters.AddWithValue("@Username", user.Username);
            sqlcmd.Parameters.AddWithValue("@Password", user.Password);
            sqlcmd.Parameters.AddWithValue("@FirstName", user.FirstName);
            sqlcmd.Parameters.AddWithValue("@LastName", user.LastName);
            sqlcmd.Parameters.AddWithValue("@Phone", user.Phone); //  if phone is null use ==>("@Phone", (object)user.Phone ?? DBNULL.Value);)
            sqlcmd.Parameters.AddWithValue("@Email", user.Email); //  if email is null use ==>("@Email", (object)user.Email ?? DBNULL.Value);)
            sqlcmd.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);
            sqlcmd.Parameters.AddWithValue("@IsReviewer", user.IsReviewer);
        }

        public static bool Insert(Users user) {
            var sql = "INSERT into Users" +
                "(Username, Password, FirstName, LastName, Phone, Email, IsAdmin, IsReviewer)" +
                "VALUES" +
                "(@Username, @Password, @FirstName, @LastName, @Phone, @Email, @IsReviewer, @IsAdmin)"; //same as below
                //$"({user.Username}, {user.Password}, {user.FirstName}, {user.LastName}, {user.Phone}, " +
                //$"{user.Email}, {user.IsAdmin}, {user.IsReviewer})" 
            var sqlcmd = new SqlCommand(sql, Connection.sqlConnection);
            SetParameterValues(user, sqlcmd);
            var rowsAffected = sqlcmd.ExecuteNonQuery();
            return rowsAffected == 1;

        }
        const string SqlDelete = "Delete from Users Where ID =@Id;";
        public static bool Delete(int id) {
            var sql = SqlDelete;
            var sqlcmd = new SqlCommand(sql, Connection.sqlConnection);
            sqlcmd.Parameters.AddWithValue("@Id", id);
            var rowsAffected = sqlcmd.ExecuteNonQuery();
            return rowsAffected == 1;
        }
       

    public static Users Login(string username, string password) {
            var sql = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
            var sqlcmd = new SqlCommand(sql, Connection.sqlConnection);
            sqlcmd.Parameters.AddWithValue("@Username", username);
            sqlcmd.Parameters.AddWithValue("@Password", password);
            var reader = sqlcmd.ExecuteReader();
            if (!reader.HasRows) {
                reader.Close();
                return null;
            }
            reader.Read();
            var user = new Users();
            LoadUserFromSql(user, reader);
            reader.Close();
            return user;
        }

        public static Users GetByPk(int id){
            //command object
            var sql = "SELECT * FROM Users WHERE ID = @Id"; // @id is a parameter this allows you to avoid SQL Injection
            var sqlcmd = new SqlCommand(sql, Connection.sqlConnection);
            //set up parameters
            sqlcmd.Parameters.AddWithValue("@Id", id);
            //execute reader
            var reader = sqlcmd.ExecuteReader();
            if (!reader.HasRows) {
                reader.Close();
                return null;
            }
            reader.Read();
            var user = new Users();
            LoadUserFromSql(user, reader);

            //close data reader... will not work without this
            reader.Close();
            return user;
        }

        public static List<Users> GetAll() {
            var sql = "SELECT * From Users;";
            var sqlcmd = new SqlCommand(sql, Connection.sqlConnection);
            var reader = sqlcmd.ExecuteReader();
            var users = new List<Users>();
            while(reader.Read()) {
                var user = new Users();
                users.Add(user);
                LoadUserFromSql(user, reader);
            }
            reader.Close();
            return users;

        }
        //creating method to avoid duplicating code
        private static void LoadUserFromSql(Users user, SqlDataReader reader) {
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

            public int ID { get; private set; }
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

        public override string ToString() {
            return $"ID={ID}, Username={Username}, Password={Password}, " +
                $"Name={FirstName} {LastName}, Admin?={IsAdmin}, Reviewer={IsReviewer}";
        }
    }
}
