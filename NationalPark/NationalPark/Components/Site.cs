using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalPark.Classes
{
    public class Site
    {

        private int site_id;
        private int campground_id;
        private int site_number;
        private int max_occupancy;
        private bool accessible;
        private bool utilities;
        private int max_rv_length;

        public int Site_id
        {
            get { return site_id; }
            set { site_id = value; }
        }
        public int Campground_id
        {
            get { return campground_id; }
            set { campground_id = value; }
        }
        public int Site_number
        {
            get { return site_number; }
            set { site_number = value; }
        }
        public int Max_occupancy
        {
            get { return max_occupancy; }
            set { max_occupancy = value; }
        }
        public bool Accessible
        {
            get { return accessible; }
            set { accessible = value; }
        }
        public bool Utilities
        {
            get { return utilities; }
            set { utilities = value; }
        }
        public int Max_rv_length
        {
            get { return max_rv_length; }
            set { max_rv_length = value; }
        }


        //   INSERT INTO[dbo].[site]
        //      ([campground_id]
        //      ,[site_number]
        //      ,[max_occupancy]
        //      ,[accessible]
        //      ,[max_rv_length]
        //      ,[utilities])
        //VALUES
        //      (<campground_id, int,>
        //      ,<site_number, int,>
        //      ,<max_occupancy, int,>
        //      ,<accessible, bit,>
        //      ,<max_rv_length, int,>
        //      ,<utilities, bit,>)

    }
}
