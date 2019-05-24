using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
namespace Practice30._04._2019
{
    public class NewsRepository
    {
        public string Add(string connectionString, string query, News news)
        {
            using(var sql = new SqlConnection(connectionString))
            {
                var result = sql.Execute(query, news);
                if (result < 1)
                {
                    throw new Exception("failed!");
                }
                return "gj!";
            }
        }
        public List<News> GetAllStudents(string connectionString, string query)
        {
            using (var sql = new SqlConnection(connectionString))
            {
                var result = sql.Query<News>(query).ToList();
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
        public List<News> DeleteAllStudents(string connectionString, string query)
        {
            using (var sql = new SqlConnection(connectionString))
            {
                var result = sql.Query<News>(query).ToList();
                return result;
            }
        }
    }
}
