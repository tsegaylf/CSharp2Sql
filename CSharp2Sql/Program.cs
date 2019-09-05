using System;
using CSharp2SqlLibrary;

namespace CSharp2Sql {
    class Program {

        void Run() {
            var conn = new Connection(@"localhost\sqlexpress", "PrsDB");
            conn.Open();
            Users.Connection = conn;
            var userLogin = Users.Login("John1234", "John1234");
            var userFailedLogin = Users.Login("xx", "Xx");
            var users = Users.GetAll();
            var user = Users.GetByPk(3);
            var usernf = Users.GetByPk(12);
            conn.Close();
        }

        static void Main(string[] args) {
            var pgm = new Program();
            pgm.Run();
        }
    }
}
