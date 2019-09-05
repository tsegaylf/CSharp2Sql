﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CSharp2SqlLibrary {
    public class Users {

            public static Connection Connection { get; set; }

        public static Users Login(string username, string password) {
            var sql = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
            var sqlcmd = new SqlCommand(sql, Connection._Connection);
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
            var sqlcmd = new SqlCommand(sql, Connection._Connection);
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
            var sqlcmd = new SqlCommand(sql, Connection._Connection);
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
