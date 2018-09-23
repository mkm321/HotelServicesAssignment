using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApiService.DataAccessLayer
{
    public class Database
    {
        public void PostBookingRequest(string name,string price,string type)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "Data Source=TAVDESK083;Initial Catalog= BookHotel;User ID=sa;Password=test123!@#";
            sqlConnection.Open();
            string query = "insert into Book(HotelName,Price,RoomType) values('" +name + "'," + price + ",'" + type + "')";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
