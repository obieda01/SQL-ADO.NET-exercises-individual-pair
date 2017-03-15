using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalPark.Classes
{
    public class Park
    {

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


        private string location;

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        private DateTime estDate;

        public DateTime EstDate
        {
            get { return estDate; }
            set { estDate = value; }
        }

        private int area;

        public int Area
        {
            get { return area; }
            set { area = value; }
        }

        private int vistors;

        public int Vistors
        {
            get { return vistors; }
            set { vistors = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

    }
}
