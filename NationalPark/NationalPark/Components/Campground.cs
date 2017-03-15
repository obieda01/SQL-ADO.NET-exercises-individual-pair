using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalPark.Classes
{
    public class Campground
    {

        private int campgroundID;

        public int CampgroundID
        {
            get { return campgroundID; }
            set { campgroundID = value; }
        }
        private int parkID;

        public int ParkID
        {
            get { return parkID; }
            set { parkID = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int openFromMonth;

        public int OpenFromMonth
        {
            get { return openFromMonth; }
            set { openFromMonth = value; }
        }
        private int openToMonth;

        public int OpenToMonth
        {
            get { return openToMonth; }
            set { openToMonth = value; }
        }
        private double dailyFee;

        public double DailyFee
        {
            get { return dailyFee; }
            set { dailyFee = value; }
        }

    }
}
