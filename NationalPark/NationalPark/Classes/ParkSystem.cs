using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalPark.Classes;
using NationalPark.DAL;

namespace NationalPark.Classes
{
    public class ParkSystem
    {
        private string connectionString;
        public ReservationSqlDAL reservationDAL;
        public CampgroundSqlDAL campgroundDAL;
        public SiteSqlDAL campsiteDAL;
        public ParkSqlDAL parkDAL;

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }
        //writing to sql objects
        public ParkSystem()
        {
        }
        public ParkSystem(string connectionString)
        {
            this.ConnectionString = connectionString;
            campgroundDAL = new CampgroundSqlDAL(ConnectionString);
            campsiteDAL = new SiteSqlDAL(ConnectionString);
            parkDAL = new ParkSqlDAL(ConnectionString);
            reservationDAL = new ReservationSqlDAL(ConnectionString);
        }
    }
}
