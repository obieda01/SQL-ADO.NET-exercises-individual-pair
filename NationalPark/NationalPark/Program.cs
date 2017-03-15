using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalPark.Classes;

    namespace NationalPark
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=DESKTOP-U3MOBAH\SQLEXPRESS;Initial Catalog=ParkSystem;Persist Security Info=True;User ID=student;Password=student";
            ParkSystem ps = new ParkSystem(connectionString);
            ParkSystemCLI cli = new ParkSystemCLI(ps);
            cli.Run();


        }
    }
}
