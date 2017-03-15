using ProjectDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjectDB.DAL
{
    public class ProjectSqlDAL
    {
        private string connectionString;

        // Single Parameter Constructor
        public ProjectSqlDAL(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Project> GetAllProjects()
        {
            {
                List<Project> allProject = new List<Project>();
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand command = new SqlCommand();
                        command.CommandText = "SELECT * FROM project";
                        command.Connection = conn;
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            Project p = new Project();
                            p.ProjectId = Convert.ToInt32(reader["project_id"]);
                            p.Name = Convert.ToString(reader["name"]);
                            p.StartDate = Convert.ToDateTime(reader["from_date"]);
                            p.EndDate = Convert.ToDateTime(reader["to_date"]);

                            allProject.Add(p);
                        }
                        return allProject;
                    }
                }
                catch
                {
                    throw;
                }
            }
        }
        public bool AssignEmployeeToProject(int projectId, int employeeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO project_employee ([employee_id], [project_id]) VALUES (@xx, @yy)", conn);
                    command.Parameters.AddWithValue("@xx", employeeId);
                    command.Parameters.AddWithValue("@yy", projectId);
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

        public bool RemoveEmployeeFromProject(int projectId, int employeeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("DELETE FROM project_employee WHERE [employee_id]=@xx AND [project_id]= @yy", conn);
                    command.Parameters.AddWithValue("@xx", employeeId);
                    command.Parameters.AddWithValue("@yy", projectId);
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
        public bool CreateProject(Project newProject)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO project ( [name],[from_date],[to_date]) VALUES (@xx, @yy,@ZZ)", conn);
                    command.Parameters.AddWithValue("@xx", newProject.Name);
                    command.Parameters.AddWithValue("@yy", newProject.StartDate);
                    command.Parameters.AddWithValue("@ZZ", newProject.EndDate);
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
