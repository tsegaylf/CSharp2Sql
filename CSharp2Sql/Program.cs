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
            var success = Users.Delete(6);
            var user3 = Users.GetByPk(6);
            Debug.WriteLine(user3);
            //conn.Close(); // can only have one conn.Close(); in program 

            //INSERT USER
            var newuser = new Users();
            newuser.Username = "Angela349";
            newuser.Password = "Angela3499";
            newuser.FirstName = "Angela";
            newuser.LastName = "Jacobs";
            newuser.Phone = "493-305-9803";
            newuser.Email = "Angela@gmail.com";
            newuser.IsReviewer = false;
            newuser.IsAdmin = true;
            success = Users.Insert(newuser);
            //conn.Close();

            //UPDATE USER
            var userAngela = Users.GetByPk(9);
            userAngela.Password = "Angela444";
            userAngela.Phone = "394-309-8888";
            success = Users.Update(userAngela);
            //conn.Close();
        }

        static void Main(string[] args) {
            var pgm = new Program();
            pgm.Run();
        }

    }
}
