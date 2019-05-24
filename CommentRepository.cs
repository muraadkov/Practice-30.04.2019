using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice30._04._2019
{
    public class CommentRepository
    {
        public string Add(string connectionString, string query, Comments news)
        {
            using (var sql = new SqlConnection(connectionString))
            {
                var result = sql.Execute(query, news);
                if (result < 1)
                {
                    throw new Exception("failed!");
                }
                return "gj!";
            }
        }
        public List<Comments> GetAllStudents(string connectionString, string query)
        {
            using (var sql = new SqlConnection(connectionString))
            {
                var result = sql.Query<Comments>(query).ToList();
                return result;
            }
        }
        public void UpdateStudents(string connectionString, string query)
        {
            using (var sql = new SqlConnection(connectionString))
            {
                sql.Execute(query);
            }
        }
        public List<Comments> DeleteAllStudents(string connectionString, string query)
        {
            using (var sql = new SqlConnection(connectionString))
            {
                var result = sql.Query<Comments>(query).ToList();
                return result;
            }
        }
    }
}
