using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MqttPublisherApp.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlDb");
        }

        public List<string> GetData()
        {
            var data = new List<string>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT DataColumn FROM YourTable", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Add(reader.GetString(0));
                    }
                }
            }
            return data;
        }
    }
}
