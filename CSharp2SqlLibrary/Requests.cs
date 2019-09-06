using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CSharp2SqlLibrary {
    public class Requests {

        //public static Connection Connection { get; set; }

        //public static List<Requests> GetAll() {
        //    var sql = "SELECT * From Requests;";
        //    var sqlcmd = new SqlCommand(sql, Connection._Connection);
        //    var reader = sqlcmd.ExecuteReader();
        //    var requests = new List<Requests>();
        //    while (reader.Read()) {
        //        var request = new Requests();
        //        requests.Add(request);
        //        LoadRequestsFromSql(request, reader);
        //    }
        //    reader.Close();
        //    return requests;
        //}

        //private static void LoadRequestsFromSql(Requests request, SqlDataReader reader) {
        //    request.ID = (int)reader["ID"];
        //    request.Description = reader["Description"].ToString();
        //    request.Justification = reader["Justification"].ToString();
        //    request.RejectionReason = reader["RejectionReason"].ToString();
        //    request.DiliveryMode = reader["DilivaryMode"].ToString();
        //    request.Status = reader["Status"]?.ToString();
        //    request.Total = (decimal)reader["Total"];
        //    request.UserID = (int)reader["UserID"];
        //}

        //public int ID { get; set; }
        //public string Description { get; set; }
        //public string Justification { get; set; }
        //public string RejectionReason { get; set; }
        //public string DiliveryMode { get; set; }
        //public string Status { get; set; }
        //public decimal Total { get; set; }
        //public int UserID { get; set; }

        //public Requests() {
        //}

        }
}
