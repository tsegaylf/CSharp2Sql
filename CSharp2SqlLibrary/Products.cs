using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CSharp2SqlLibrary {
    public class Products {

        public static Connection Connection { get; set; }

        #region SQL Statements
        private const string SqlGetAll = "SELECT * From Products ";
        private const string SqlGetByPk = SqlGetAll + "WHERE ID = @Id ";
        private const string SqlDelete = "DELETE FROM Products WHERE ID = @Id ";
        private const string SqlUpdate = "UPDATE Products Set " +
            " PartNbr = @PartNbr, Name = @Name, Price = @Price, Unit = @Unit, PhotoPath = @PhotoPath, VendorID = @VendorID " +
            " WHERE ID = @Id ";
        private const string SqlInsert = "INSERT into Products " +
            " (PartNbr, Name, Price, Unit, PhotoPath, VendorID) " +
            " VALUES (@PartNbr, @Name, @Price, @Unit, @PhotoPath, @VendorID) ";
        #endregion

        public static List<Products> GetAll() {
            var sqlcmd = new SqlCommand(SqlGetAll, Connection.sqlConnection);
            var reader = sqlcmd.ExecuteReader();
            var products = new List<Products>();
            while (reader.Read()) {
                var product = new Products();
                products.Add(product);
                LoadProductFromSql(product, reader);
            }
            reader.Close();

            Vendors.Connection = Connection;
            foreach (var prod in products) {
                var vendor = Vendors.GetByPk(prod.VendorID); // adding a FK
                prod.Vendor = vendor;
            }
                return products;
            
        }

        public static Products GetByPK(int id) {
                var sqlcmd = new SqlCommand(SqlGetByPk, Connection.sqlConnection);
                sqlcmd.Parameters.AddWithValue("@Id", id);
                var reader = sqlcmd.ExecuteReader();
                if (!reader.HasRows) {
                    reader.Close();
                    return null;
                }
                reader.Read();
                var product = new Products();
                LoadProductFromSql(product, reader);
                reader.Close();
                return product;
            }

        private static void LoadProductFromSql(Products product, SqlDataReader reader) {
            product.ID = (int)reader["Id"];
            product.PartNbr = reader["PartNbr"].ToString();
            product.Name = reader["Name"].ToString();
            product.Price = (decimal)reader["Price"];
            product.Unit = reader["Unit"].ToString();
            product.PhotoPath = reader["PhotoPath"]?.ToString();
            product.VendorID = (int)reader["VendorID"];
        }

        #region
        public int ID { get; private set; }
        public string PartNbr { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }
        public string PhotoPath { get; set; }
        public int VendorID { get; set; }
        public Vendors Vendor { get; private set; }
        #endregion

        public override string ToString() {
            return $"Id={ID}, PartNbr={PartNbr}, Name={Name}, Price={Price}, Unit={Unit}, VendorID={VendorID}";

        }


    }
}
