using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalPark.Exceptions
{
    public class InvalidCampgroundSqlException : ParkSystemException
    {
        public InvalidCampgroundSqlException()
        {

        }

        public InvalidCampgroundSqlException(string msg):base(msg)
        {

        }

        public InvalidCampgroundSqlException(string msg, Exception inner):base(msg,inner)
        {

        }
    }
}
