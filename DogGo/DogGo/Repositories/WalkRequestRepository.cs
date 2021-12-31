using DogGo.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DogGo.Repositories
{
    public class WalkRequestRepository : IWalkRequestRepository
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
        public List<WalkRequest> GetRequests()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                    SELECT * FROM WalkRequest r
                                    LEFT JOIN Walker w on w.Id = r.WalkerId
                                    WHERE r.walkerId = @



                                        ";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        List<WalkRequest> walkRequests = new List<WalkRequest>();

                        while (reader.Read())
                        {
                            WalkRequest walkRequest = new WalkRequest()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Message = reader.GetString(reader.GetOrdinal("Message")),
                                OwnerId = reader.GetInt32(reader.GetOrdinal("OwnerId")),
                                DogId = reader.GetInt32(reader.GetOrdinal("DogId")),
                                RequestDateTime = reader.GetDateTime(reader.GetOrdinal("RequestDateTime")),
                                Created = reader.GetDateTimeOffset(reader.GetOrdinal("Created")),

                            };
                            walkRequests.Add(walkRequest);
                        }

                        return walkRequests;
                    }
                }
            }
        }
    }
}
