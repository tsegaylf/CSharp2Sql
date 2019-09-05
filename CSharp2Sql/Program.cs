using System;
using CSharp2SqlLibrary;
using System.Diagnostics;

namespace CSharp2Sql {
    class Program {

        void Run() {
            var conn = new Connection(@"localhost\sqlexpress", "PrsDB");
            conn.Open();
            Users.Connection = conn;
            var userLogin = Users.Login("John1234", "John1234");
            Console.WriteLine(userLogin);
            var userFailedLogin = Users.Login("xx", "Xx");
            Console.WriteLine(userFailedLogin?.ToString() ?? "Not Found"); //assigning a string for a null value
            var users = Users.GetAll();
            foreach(var usser in users) {
                Console.WriteLine(usser);
            }
            var user = Users.GetByPk(3);//how to display things without a consol
            Debug.WriteLine(user); //have to set a using statement for System.Diagnostics
            var usernf = Users.GetByPk(12);
            conn.Close();
        }

        static void Main(string[] args) {
            var pgm = new Program();
            pgm.Run();
        }
    }
}
