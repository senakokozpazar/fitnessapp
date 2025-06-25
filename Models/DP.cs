using System;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace FitnessApp.Models
{
	public class DP
	{
        public static string connectionString = "Server=localhost;Database=fitnessapp;User Id=SA;Password=reallyStrongPwd123;TrustServerCertificate=True;";

        public static List<T> Listeleme<T>(string procedure, DynamicParameters param = null)
        {
            using var conn = new SqlConnection(connectionString);
            return conn.Query<T>(procedure, param, commandType: CommandType.StoredProcedure).ToList();
        }

        public static int ExecuteReturn(string procedure, DynamicParameters param)
        {
            using var conn = new SqlConnection(connectionString);
            return conn.Execute(procedure, param, commandType: CommandType.StoredProcedure);
        }
    }
}

