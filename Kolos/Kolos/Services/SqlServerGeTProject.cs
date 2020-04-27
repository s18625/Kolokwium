using Kolos.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Task = Kolos.Models.Task;

namespace Kolos.Services
{
    public class SqlServerGeTProject : IProjectDal
    {
        private const string conStr = "Data Source=db-mssql;Initial Catalog=s18625;Integrated Security=True";
        public IEnumerable<Project> GetProject(int id)
        {
            var lp = new List<Project>();
            using (SqlConnection con = new SqlConnection(conStr))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                
                com.CommandText = "SELECT * FROM Project p INNER JOIN Task t ON p.idProject = t.idProject INNER JOIN TASKTYPE ts ON ts.IdTaskType = t.IdTaskType ORDER BY p.Deadline DESC";
                com.Parameters.AddWithValue("id", id);

                con.Open();

                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    var ta = new Task();
                    var pr = new Project();
                    pr.IdProject = reader.GetInt32(0);
                    pr.Name = reader.GetString(1);
                    pr.Deadline = reader.GetDateTime(2);
                   
                    pr.ta.IdTask = reader.GetInt32(3);
                    pr.ta.Name = reader.GetString(4);
                    pr.ta.Description = reader.GetString(5);
                    pr.ta.Deadline = reader.GetDateTime(6);
                    pr.ta.IdProject = reader.GetInt32(7);
                    pr.ta.IdTaskType = reader.GetInt32(8);
                    pr.ta.IdAssignedTo = reader.GetInt32(9);
                    pr.ta.IdCreator = reader.GetInt32(10);
                    pr.ts.TypeName = reader.GetString(11);
                    lp.Add(pr);

                    ;
                }


                return (lp);
            }
        }
    }
}
