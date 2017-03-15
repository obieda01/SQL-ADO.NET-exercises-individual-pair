using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using NationalPark.Classes;

namespace NationalPark.DAL
{
    public class ParkSqlDAL
    {

        //private const string Option_DisplayReservationMenu = "2";
        //private const string Option_ViewCampgrounds = "1";
        //private const string Option_SearchForReservation = "2";
        ////private const string Option_ReturnChange = "3";
        //private const string Option_ReturnToPreviousMenu = "P";
        //private const string Option_Quit = "Q";

        public const string SqlCommand_ViewParks = "SELECT* FROM park ORDER BY name ";




        private string connectionString;

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }

        }
        public ParkSqlDAL()
        {
        }
        public ParkSqlDAL(string connectionString)
        {
            this.ConnectionString = connectionString;
        }


        public Dictionary<int, Park> getParkData()
        {
            Dictionary<int, Park> parks = new Dictionary<int, Park>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(SqlCommand_ViewParks, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Park p = new Park();

                    p.Name = Convert.ToString(reader["name"]);
                    p.ParkID = Convert.ToInt32(reader["park_id"]);
                    p.Location = Convert.ToString(reader["location"]);
                    p.EstDate = Convert.ToDateTime(reader["establish_date"]);
                    p.Area = Convert.ToInt32(reader["area"]);
                    p.Vistors = Convert.ToInt32(reader["visitors"]);
                    p.Description = Convert.ToString(reader["description"]);

                    parks.Add(p.ParkID, p);
                }
            }
            return parks;
        }

        //public Dictionary<int, Park> GetPark(string connectionString)
        //{
        //    Dictionary<int, Park> parks = new Dictionary<int, Park>();
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        SqlCommand command = new SqlCommand(, connection);
        //        SqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            Park p = new Park();

        //            p.Name = Convert.ToString(reader["name"]);
        //            p.ParkID = Convert.ToInt32(reader["park_id"]);
        //            p.Location = Convert.ToString(reader["location"]);
        //            p.EstDate = Convert.ToDateTime(reader["establish_date"]);
        //            p.Area = Convert.ToInt32(reader["area"]);
        //            p.Vistors = Convert.ToInt32(reader["visitors"]);
        //            p.Description = Convert.ToString(reader["description"]);

        //            parks.Add(p.ParkID, p);           
        //        }
        //    }
        //        return parks;
        //}
    }
}
