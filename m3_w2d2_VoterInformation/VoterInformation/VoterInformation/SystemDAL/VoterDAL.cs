using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using VoterInformation.Models;


namespace VoterInformation.SystemDAL
{
    public class VoterDAL
    {
        public const string connectionString =
            @"Data Source=DESKTOP-U3MOBAH\SQLEXPRESS;Initial Catalog=Voter;Integrated Security=True";

        public const string sqlCommandVoter= "SELECT * FROM voter";


        public List<VoterModel> getVoterByStreet(string streetName)
        {
            List <VoterModel> voterList =new List<VoterModel>();
            try
            {
                using (SqlConnection connection =new SqlConnection(connectionString))
                {
                    
                    connection.Open();
                    SqlCommand command= new SqlCommand(sqlCommandVoter,connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        VoterModel localVoter=new VoterModel();
                        localVoter.FirstName = Convert.ToString(reader["VOTER ID"]);
                        localVoter.FirstName = Convert.ToString(reader["FIRSTNAME"]);
                        localVoter.Lastname = Convert.ToString(reader["LASTNAME"]);
                        localVoter.StreetNumber = Convert.ToString(reader["RES_HOUSE"]);
                        localVoter.StreetName = Convert.ToString(reader["RES_STREET"]);
                        voterList.Add(localVoter);
                    }

                }
                return voterList;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

        }

    }
}