using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalPark.Exceptions
{
    public class ParkSystemException:Exception
    {
        public ParkSystemException()
        {

        }

        public ParkSystemException(string msg):base(msg)
        {

        }

        public ParkSystemException(string msg,Exception inner):base(msg,inner)
        {

        }
    }
}
