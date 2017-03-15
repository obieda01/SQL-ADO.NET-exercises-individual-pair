using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalPark.Classes;
using System.Data.SqlClient;

namespace NationalPark.DAL
{
    public class ReservationSqlDAL
    {
        private const string SQL_RecordTransaction = "INSERT INTO reservation VALUES (@siteId, @name, @from_date, @to_date,@create_date);";

        private string connectionString;

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }

        }
        public ReservationSqlDAL()
        {
        }
        public ReservationSqlDAL(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public Dictionary<int, Reservation> getReservationData(string sqlCommand, string connectionString)
        {
            Dictionary<int, Reservation> reservations = new Dictionary<int, Reservation>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(SQL_RecordTransaction, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Reservation r = new Reservation();
                    r.ReservationID = Convert.ToInt32(reader["reservation_id"]);
                    r.SiteID = Convert.ToInt32(reader["site_id"]);
                    r.Name = Convert.ToString(reader["name"]);
                    r.FromDate = Convert.ToDateTime(reader["from_date"]);
                    r.ToDate = Convert.ToDateTime(reader["to_date"]);
                    r.CreateDate = Convert.ToDateTime(reader["create_date"]);

                    reservations.Add(r.ReservationID, r);
                }
            }
            return reservations;
        }

        public void insertReservation(int siteId, string campgroundArrivalDate, string campgroundDepartureDate,string reservationName)
        {
            Dictionary<int, Reservation> reservations = new Dictionary<int, Reservation>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_RecordTransaction, conn);
                    cmd.Parameters.AddWithValue("@siteId", siteId);
                    cmd.Parameters.AddWithValue("@name", reservationName);
                    cmd.Parameters.AddWithValue("@from_date", campgroundArrivalDate);
                    cmd.Parameters.AddWithValue("@to_date", campgroundDepartureDate);
                    cmd.Parameters.AddWithValue("@create_date", DateTime.UtcNow);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error has occurred recording the transaction: " + ex.Message);
            }
        }
    }
}
