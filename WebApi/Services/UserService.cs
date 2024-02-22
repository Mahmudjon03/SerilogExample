using Data;
using Domain.Enums;
using Domain.Exceptions;
using Microsoft.OpenApi.Models;
using System.Data;
using System.Data.SqlClient;
using WebApi.Model;
using static Data.DataContext;

namespace WebApi.Services
{
    public class UserService : DataContext, IUserService
    {


        public List<User> _ListUser = new List<User>();



        public bool AddUser(User user)
        {
            string sql = "insert into Employee  values(@fname,@lname);";

            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@fname", user.FName),
                new SqlParameter("@lname", user.LName),
            };

            var sqlObjects = Exec(sql, sqlParameter, TypeReturn.SqlDataReader, TypeCommand.SqlQuery);
            sqlObjects.Dispose();

            return true;
        }

        public bool Delete(int id)
        {
            string sql = "delete from Employee  where id  = @Id";

            SqlParameter[] sqlParameter = new SqlParameter[]
          {     new SqlParameter("@Id",id),

          };

            var sqlObjects = Exec(sql, sqlParameter, TypeReturn.SqlDataReader, TypeCommand.SqlQuery);
            sqlObjects.Dispose();

            return true;
        }

        public User GetById(int id)
        {
            string sql = "select * from Employee where Id = @id";

            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@id", id)
            };


            using (SqlObjects sqlObjects = Exec(sql, sqlParameter, TypeReturn.SqlDataReader, TypeCommand.SqlQuery))
            {
                SqlDataReader dataReader = sqlObjects.Reader;
                if (dataReader.HasRows)
                {
                    var result = new User();

                    dataReader.Read();
                    result.Id = dataReader.GetInt32(0);
                    result.FName = dataReader.GetString(1);
                    result.LName = dataReader.GetString(2);

                    return result;
                }

                throw new ShukrMoliyaException("Employee not found");
            }
        }

        public List<User> GetUsers()
        {
            string sql = "select * from Employee";
            var result = new List<User>();
            using (SqlObjects sqlObject = Exec(sql, new SqlParameter[] { }, TypeReturn.DataTable, TypeCommand.SqlQuery))
            {
                DataTable dataTable = sqlObject.DataTable;
                if (dataTable.Columns.Count > 0)
                {
                    result = (from DataRow dataRow in dataTable.Rows
                              select new User()
                              {
                                  Id = (int)dataRow["Id"],
                                  FName = dataRow["fname"].ToString(),
                                  LName = dataRow["lname"].ToString()
                              }).ToList();
                 }

            }

            return result;
        }

        public bool Update(User user)
        {
            string sql = "update  Employee set fname = @fname, lname =lname  where Id =@Id";
           
            SqlParameter[] sqlParameter = new SqlParameter[]
            {  
                new SqlParameter("@Id", user.Id),
                new SqlParameter("@fname", user.FName),
                new SqlParameter("@lname", user.LName),
            };

            var sqlObjects = Exec(sql, sqlParameter, TypeReturn.SqlDataReader, TypeCommand.SqlQuery);
            sqlObjects.Dispose();

            return true;
        }
    }
}
