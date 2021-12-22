using DogGo.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DogGo.Repositories
{
    public class WalkRequestRepository
    {
        private readonly IConfiguration _config;

        // The constructor accepts an IConfiguration object as a parameter. This class comes from the ASP.NET framework and is useful for retrieving things out of the appsettings.json file like connection strings.
        public WalkRequestRepository(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }
        public void MakeRequest(WalkRequest walkRequest)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    INSERT INTO WalkRequest ( OwnerId, DogId, WalkerId, RequestDateTime, Created)
                    OUTPUT INSERTED.ID
                    VALUES (@ownerId, @dogId, @walkerId, @requestDateTime, @Created);
                ";

                    cmd.Parameters.AddWithValue("@ownerId", walkRequest.OwnerId);
                    cmd.Parameters.AddWithValue("@dogId", walkRequest.DogId);
                    cmd.Parameters.AddWithValue("@walkerId", walkRequest.WalkerId);
                    cmd.Parameters.AddWithValue("@requestDateTime", walkRequest.RequestDateTime);
                    cmd.Parameters.AddWithValue("@created", walkRequest.Created);

                    int id = (int)cmd.ExecuteScalar();

                    walkRequest.Id = id;
                }
            }
        }
    }
}
