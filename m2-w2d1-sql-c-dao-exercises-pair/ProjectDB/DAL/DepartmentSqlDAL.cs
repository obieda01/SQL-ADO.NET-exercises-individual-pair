using ProjectDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjectDB.DAL
{
    public class DepartmentSqlDAL
    {
        private string connectionString;

        // Single Parameter Constructor
        public DepartmentSqlDAL(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Department> GetDepartments()
        {
            List<Department> allDeparment = new List<Department>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "SELECT * FROM department";
                    command.Connection = conn;
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Department d = new Department();
                        d.Name = Convert.ToString(reader["name"]);
                        d.Id = Convert.ToInt32(reader["department_id"]);

                        allDeparment.Add(d);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("failure to connect");
            }


            return allDeparment;
        }

        public bool CreateDepartment(Department newDepartment)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO department ( [name]) VALUES (@xx)", conn);
                    command.Parameters.AddWithValue("@xx", newDepartment.Name);
                    command.Connection = conn;
                    SqlDataReader reader = command.ExecuteReader();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }


        public bool UpdateDepartment(Department updatedDepartment)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("UPDATE department SET [name] = @yy  WHERE [department_id]= @xx ", conn);
                    command.Parameters.AddWithValue("@xx", updatedDepartment.Id);
                    command.Parameters.AddWithValue("@yy", updatedDepartment.Name);
                    command.Connection = conn;
                    SqlDataReader reader = command.ExecuteReader();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

    }
}
