using System;
using CSharp2SqlLibrary;

namespace CSharp2Sql {
    class Program {

        void Run() {
            var conn = new Connection(@"localhost\sqlexpress", "PrsDB");
            conn.Open();
            Users.Connection = conn;
            var users = Users.GetAll();
            conn.Close();
        }

        static void Main(string[] args) {
            var pgm = new Program();
            pgm.Run();
        }
    }
}
