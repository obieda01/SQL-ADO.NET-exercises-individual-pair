using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalPark.Classes;
using System.Data.SqlClient;

namespace NationalPark.DAL
{
    public class SiteSqlDAL
    {
        private string connectionString;
        public const string SqlCommand_reservationSpecificCampground = "SELECT * from site JOIN campground ON site.campground_id = campground.campground_id WHERE site.campground_id = @CampgroundId AND site_id NOT IN (SELECT site_id FROM reservation WHERE (@startDate < from_date OR @endDate > to_date)) ";

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }

        }

        public SiteSqlDAL()
        {
        }

        public SiteSqlDAL(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        public Dictionary<int, Site> getSiteData(string campgroundId,string arrivalDate,string departureDate)
        {
            Dictionary<int, Site> Sites = new Dictionary<int, Site>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                //"SELECT * from site JOIN campground ON site.campground_id = campground.campground_id WHERE site.campground_id = @CampgroundId AND site_id NOT IN (SELECT site_id FROM reservation WHERE (@startDate < from_date OR @endDate > to_date)) ";
                connection.Open();
                SqlCommand cmd = new SqlCommand(SqlCommand_reservationSpecificCampground, connection);
                cmd.Parameters.AddWithValue("@CampgroundId", campgroundId);
                cmd.Parameters.AddWithValue("@startDate", arrivalDate);
                cmd.Parameters.AddWithValue("@endDate", departureDate);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Site currentSite = new Site();
                    currentSite.Site_id = Convert.ToInt32(reader["site_id"]);
                    currentSite.Campground_id = Convert.ToInt32(reader["campground_id"]);
                    currentSite.Site_number = Convert.ToInt32(reader["site_number"]);
                    currentSite.Max_occupancy = Convert.ToInt32(reader["max_occupancy"]);
                    currentSite.Accessible = Convert.ToBoolean(reader["accessible"]);
                    currentSite.Max_rv_length = Convert.ToInt32(reader["max_rv_length"]);
                    currentSite.Utilities = Convert.ToBoolean(reader["utilities"]);
                    Sites.Add(currentSite.Site_id, currentSite);
                }
            }
            return Sites;
        }
        //public Dictionary<int, CampSite> GetCampsite(string connectionString)
        //{
        //    Dictionary<int, CampSite> Campsites = new Dictionary<int, CampSite>();
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        SqlCommand command = new SqlCommand("SELECT * FROM site", connection);
        //        SqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            CampSite currentCampSite = new CampSite();
        //            currentCampSite.Site_id = Convert.ToInt32(reader["site_id"]);
        //            currentCampSite.Campground_id  = Convert.ToInt32(reader["campground_id"]);
        //            currentCampSite.Site_number = Convert.ToInt32(reader["site_number"]);
        //            currentCampSite.Max_occupancy = Convert.ToInt32(reader["max_occupancy"]);
        //            currentCampSite.Accessible = Convert.ToBoolean(reader["accessible"]);
        //            currentCampSite.Max_rv_length = Convert.ToInt32(reader["max_rv_length"]);
        //            currentCampSite.Utilities = Convert.ToBoolean(reader["utilities"]);
        //            Campsites.Add(currentCampSite.Site_id, currentCampSite);
        //        }

        //    }

        //    return new Dictionary<int, CampSite>();
        //}



    }
}
