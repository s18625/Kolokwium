using Kolos.Requests;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Kolos.Services
{
    public class SqlServerAddTask : IAddTask
    {
        private const string conStr = "Data Source=db-mssql;Initial Catalog=s18625;Integrated Security=True";
        public void AddTask(TaskTypeRequest taskR)
            
        {
       
            using(SqlConnection con = new SqlConnection(conStr))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                con.Open();

                var tran = con.BeginTransaction();
                com.Transaction = tran;

                com.ExecuteNonQuery();

                com.CommandText = "select IdTask from Task where IdTask=@IdTask";
                com.Parameters.AddWithValue("IdTask", taskR.IdTaskType);

                var dr = com.ExecuteReader();

                if (!dr.Read())
                {
                    dr.Close();
                    throw new Exception();
                }
                else
                {
                    com.CommandText = "INSERT INTO TASK(IdTaskType,Name) VALUES (@IdTask,@Name)";

                    com.Parameters.AddWithValue("IdTask", taskR.IdTaskType);
                    com.Parameters.AddWithValue("Name", taskR.Name);

                    
                    dr.Close();
                    com.ExecuteNonQuery();
                }

                

                tran.Commit();
                con.Close();


            }
        }
    }
}
