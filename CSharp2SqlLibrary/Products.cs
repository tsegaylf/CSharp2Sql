using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CSharp2SqlLibrary {
    public class Products {

        public static Connection Connection { get; set; }

        //public static List<Products> GetAll() {
        //    var sql = "SELECT * From Products;";
        //    var sqlcmd = new SqlCommand(sql, Connection._Connection);
        //    var reader = sqlcmd.ExecuteReader();
        //    var products = new List<Products>();
        //    while (reader.Read()) {
        //        var product = new Products();
        //        products.Add(product);
        //        LoadProductsFromSql(product, reader);
        //    }
        //    reader.Close();
        //    return products;
        //}

        //private static void LoadProductsFromSql(Products product, SqlDataReader reader) {
        //    product.ID = (int)reader["ID"];
        //    product.PartNbr = reader["PartNbr"].ToString();
        //    product.Name = reader["Name"].ToString();
        //    product.Price = (decimal)reader["Price"];
        //    product.Unit = reader["Unit"].ToString();
        //    product.PhotoPath = reader["PhotoPath"]?.ToString();
        //    product.VendorID = (int)reader["VendorID"];

        //}

        //    public int ID { get; set; }
        //    public string PartNbr { get; set; }
        //    public string Name { get; set; }
        //    public decimal Price { get; set; }
        //    public string Unit { get; set; }
        //    public string PhotoPath { get; set; }
        //    public int VendorID { get; set; }


        //    public Products() {

        //}


        }
}
