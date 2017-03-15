using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalPark.DAL;

namespace NationalPark.Classes
{
    public class ParkSystemCLI
    {
        private const string Option_ViewParks = "1";
        private const string Option_DisplayReservationMenu = "2";
        private const string Option_ViewCampgrounds = "1";
        private const string Option_SearchForReservation = "2";
        private const string Option_SearchForReservationSpecificCampground = "1";
        private const string Option_ReturnToPreviousMenu = "P";
        private const string Option_Quit = "Q";
        public ParkSystem currentPs;

        public ParkSystemCLI(ParkSystem ps)
        {
            currentPs = ps;
        }
        public ParkSystemCLI()
        {

        }
        public void Run()
        {
            while (true)
            {
                printHeader();
                string userInput = (Console.ReadLine().ToUpper());
                if (userInput == Option_ViewParks)
                {
                    DisplayAllParks();     //
                    Console.ReadKey();
                }
                else if (userInput == Option_DisplayReservationMenu)
                {
                    Console.Clear();
                    DisplayReservationMenu();    //here
                }
                else excuteOtherOptions(userInput);
            }
        }
        private void DisplayAllParks()
        {
            printAllParksHeader();


            string userInput = (Console.ReadLine().ToUpper());
            try
            {
                if (currentPs.parkDAL.getParkData().ContainsKey(int.Parse(userInput)))//
                {
                    DisplayParkDetails(int.Parse(userInput));
                    Console.ReadKey();
                }
                else excuteOtherOptions(userInput);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        } //

        private void DisplayReservationMenu()//here
        {

        }
        private void DisplayInvalidOption()
        {
            Console.WriteLine("The option you selected is not a valid option.  Please try again.\n");
        } // 
       
        private void DisplayParkDetails(int currentId) //
        {
            printParkDetailHeader(currentId);

            string userInput = (Console.ReadLine().ToUpper());
            if (userInput == Option_ViewCampgrounds)
            {
                DisplayCampgrounds(currentId);//
                Console.ReadKey();
            }
            else if (userInput == Option_SearchForReservation)
            {
                SearchForReservation(int.Parse(userInput));//
                Console.ReadKey();

            }
            else excuteOtherOptions(userInput);

        }
       
        private void DisplayCampgrounds(int currentId)
        {
            printDisplayCampgroundHeader(currentId);
            string userInput = (Console.ReadLine().ToUpper());

            if (userInput == Option_SearchForReservationSpecificCampground)
            {
                try
                {
                    SearchForReservation(currentId);//
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else excuteOtherOptions(userInput);
        }

        private void SearchForReservation(int currentParkId)
        {
            Console.WriteLine("Which campground(enter 0 to cancel) ? __\n");
            string campgroundSelections = (Console.ReadLine().ToUpper());
            Console.WriteLine(" What is the arrival date ? __ / __ / ____\n");
            string campgroundArrivalDate = (Console.ReadLine().ToUpper());
            Console.WriteLine("What is the departure date ? __ / __ / ____\n");
            string campgroundDepartureDate = (Console.ReadLine().ToUpper());
            List<int> openDate = currentPs.campgroundDAL.getMinMaxDate();
            ///////
            
           
            DateTime arrive = Convert.ToDateTime(campgroundArrivalDate);
            DateTime departure = Convert.ToDateTime(campgroundDepartureDate);
            //if (arrive.Month <= openDate[0] && departure.Month < openDate[1])
            //{
            //    return;
            //}
            if (arrive > departure)
            {
                DisplayInvalidOption();
                Console.ReadKey();
            }
            else
            {
                Dictionary<int, Site> availableSiteQuery = currentPs.campsiteDAL.getSiteData(campgroundSelections, campgroundArrivalDate, campgroundDepartureDate);
                if (availableSiteQuery.Count != 0)
                {
                    //Console.WriteLine("Results Matching Your Search Criteria");
                    Console.WriteLine("Site No.".PadRight(15) + "Max Occup.".PadRight(15) + "Accessible?".PadRight(15) + "Max RV Length".PadRight(15) + "Utility Cost $".PadRight(15) + "\n");

                    foreach (KeyValuePair<int, Site> kvp in availableSiteQuery)
                    {
                        Console.WriteLine(kvp.Value.Site_id.ToString().PadRight(15) + kvp.Value.Max_occupancy.ToString().PadRight(15)
                            + kvp.Value.Accessible.ToString().PadRight(15) + kvp.Value.Max_rv_length.ToString().PadRight(15) + " $"
                            + (differenceInDays(arrive, departure) * currentPs.campgroundDAL.getCampgroundData(currentParkId.ToString())[int.Parse(campgroundSelections)].DailyFee).ToString().PadRight(15) + "\n");
                    }
                    makeReservation(campgroundArrivalDate, campgroundDepartureDate);

                }
                else
                {
                    Console.WriteLine("There are no available sites. Would like to enter in an alternate date range.(Y for Yes and N for No Q or Quit)");
                    string userInput = Console.ReadLine().ToUpper();
                    if (userInput == "N")
                    {
                        Console.Clear();
                        Run();
                        return;
                    }
                    else if (userInput == "Y")
                    {
                        SearchForReservation(currentParkId);
                    }
                    else if (userInput == Option_Quit)
                    {
                        return;
                    }
                    else
                    {
                        DisplayInvalidOption();
                        Console.ReadKey();
                    }
                }
            }
        }

        public int differenceInDays(DateTime start, DateTime last)
        {
            TimeSpan ts = last - start;
            return ts.Days;

        }
        public void makeReservation(string campgroundArrivalDate, string campgroundDepartureDate)
        {
            Console.WriteLine("\n\nDo you want to make reservation (Y)for Yes (N) for No ?\n");
            string userInput_ = Console.ReadLine().ToUpper();
            if (userInput_ == "N")
            {
                Console.Clear();
                Run();
                return;
            }
            else if (userInput_ == "Y")
            {
                Console.WriteLine("Please enter the campsite id that you want to Reserve: ");
                int userInput_1 = int.Parse(Console.ReadLine().ToUpper());
                Console.WriteLine("Please enter the reservation name: ");
                string userInput_ReservationName = Console.ReadLine();
                new ReservationSqlDAL(currentPs.ConnectionString).insertReservation(userInput_1, campgroundArrivalDate, campgroundDepartureDate, userInput_ReservationName);
                Console.WriteLine("\n\nThanks for choosing National Park");
                Console.ReadKey();
                Console.Clear();
                Run();
            }
        }

        public void excuteOtherOptions(string userInput)
        {
            if (userInput == Option_ReturnToPreviousMenu)
            {
                Console.Clear();
                Run();
            }
            else if (userInput == Option_Quit)
            {
                return;
            }
            else
            {
                DisplayInvalidOption();
                Console.ReadKey();
            }

            Console.Clear();

        }


        public void printHeader()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine(@" _   _       _   _                   _   _____           _    ");
            Console.WriteLine(@"| \ | |     | | (_)                 | | |  __ \         | |   ");
            Console.WriteLine(@"|  \| | __ _| |_ _  ___  _ __   __ _| | | |__) |_ _ _ __| | __");
            Console.WriteLine(@"| . ` |/ _` | __| |/ _ \| '_ \ / _` | | |  ___/ _` | '__| |/ / ");
            Console.WriteLine(@"| |\  | (_| | |_| | (_) | | | | (_| | | | |  | (_| | |  |   < ");
            Console.WriteLine(@"|_| \_|\__,_|\__|_|\___/|_| |_|\__,_|_| |_|   \__,_|_|  |_|\_\");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine("Welcome to the National Park Reservation System \nPlease select a menu item below\n\n1) View a List of Parks");
            Console.WriteLine("2) Make a Reservation in a across the entire park\nQ) Quit\n");
        }
        public void printAllParksHeader()
        {
            Console.WriteLine("Directory of National Parks".PadLeft(40) + "\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            foreach (KeyValuePair<int, Park> kvp in currentPs.parkDAL.getParkData())
            {
                Console.WriteLine(kvp.Key + ") " + kvp.Value.Name + "\n");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nTo view detailed park information, ENTER the park number.\n");
            Console.WriteLine("Otherwise, press 'P' to return to the Previous menu or 'Q' to Quit.");
        }
        public void printDisplayCampgroundHeader(int currentId)
        {
            Console.WriteLine("\n" + (currentPs.parkDAL.getParkData()[currentId].Name + " Park Campgrounds").PadLeft(50) + "\n");
            Console.WriteLine();
            Console.Write("campground".PadRight(5) + "Name".PadRight(30));
            Console.Write("Open".PadRight(30));
            Console.Write("Close".PadRight(30));
            Console.Write("Daily Fee".PadRight(30) + "\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            foreach (KeyValuePair<int, Campground> kvp in currentPs.campgroundDAL.getCampgroundData(currentId.ToString()))
            {
                Console.Write((kvp.Value.CampgroundID.ToString() + ")").PadRight(5));
                Console.Write(kvp.Value.Name.PadRight(30));
                Console.Write(kvp.Value.OpenFromMonth.ToString().PadRight(30));
                Console.Write(kvp.Value.OpenToMonth.ToString().PadRight(30));
                Console.Write("$" + kvp.Value.DailyFee.ToString().PadRight(30) + "\n");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("Select a Menu Item");
            Console.WriteLine("1) Search for Available Reservation within the selected campground");
            Console.WriteLine("P) Return to Previous Screen");
            Console.WriteLine("Q) Quit");

        }
        public void printParkDetailHeader(int currentId)
        {
            Console.WriteLine("\n" + (currentPs.parkDAL.getParkData()[currentId].Name + " Park Information ").ToUpper().PadLeft(40) + "\n");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Location: ".PadRight(30) + currentPs.parkDAL.getParkData()[currentId].Location.PadRight(30) + "\n" + "Established: ".PadRight(30) + currentPs.parkDAL.getParkData()[currentId].EstDate.ToString("MM/dd/yyyy").PadRight(30));
            Console.WriteLine("Annual Visitors: ".PadRight(30) + currentPs.parkDAL.getParkData()[currentId].Vistors.ToString().PadRight(30) + "\n\n" + currentPs.parkDAL.getParkData()[currentId].Description.PadRight(20));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\nSelect a Command\n1) View Campgrounds\n2) Search for Reservation\n");
            Console.WriteLine("P) Return to Previous Screen" + "\n");
            Console.WriteLine("Q) Quit\n");
        }
    }
}
