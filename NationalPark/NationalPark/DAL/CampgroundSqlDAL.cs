using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalPark.Classes;
using System.Data.SqlClient;
using NationalPark.Exceptions;

namespace NationalPark.DAL
{
    public class CampgroundSqlDAL
    {
        private string connectionString;
        private string sqlCommand = string.Empty;

        private const string SqlCommand_MinMaxCampground = "SELECT  min(open_from_mm)as min,max(open_to_mm)as max from campground";
        private const string SqlCommand_ViewCampGround_SpPark = "SELECT* FROM campground WHERE park_id=";


        public string SqlCommand
        {
            get { return sqlCommand = string.Empty; }
            set { sqlCommand = value; }
        }

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }

        }
        public CampgroundSqlDAL()
        {
        }
        public CampgroundSqlDAL(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public Dictionary<int, Campground> getCampgroundData(string parkId)
        {
            Dictionary<int, Campground> campground = new Dictionary<int, Campground>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(SqlCommand_ViewCampGround_SpPark + parkId, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Campground c = new Campground();
                        c.CampgroundID = Convert.ToInt32(reader["campground_id"]);
                        c.ParkID = Convert.ToInt32(reader["park_id"]);
                        c.Name = Convert.ToString(reader["name"]);
                        c.OpenFromMonth = Convert.ToInt32(reader["open_from_mm"]);
                        c.OpenToMonth = Convert.ToInt32(reader["open_to_mm"]);
                        c.DailyFee = Convert.ToDouble(reader["daily_fee"]);

                        campground.Add(c.CampgroundID, c);
                    }
                }
            }
            catch (Exception e)
            {
                throw new InvalidCampgroundSqlException(e.Message);
            }
            return campground;
        }



        public List<int> getMinMaxDate()
        {
            List<int> temp = new List<int>();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(SqlCommand_MinMaxCampground, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        temp.Add(Convert.ToInt32(reader["min"]));
                        temp.Add(Convert.ToInt32(reader["max"]));
                    }
                }
            }
            catch (Exception e)
            {
                throw new InvalidCampgroundSqlException(e.Message);
            }
            return temp;
        }
    }
}
