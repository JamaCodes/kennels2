﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogGo.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DogGo.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly IConfiguration _config;

        // The constructor accepts an IConfiguration object as a parameter. This class comes from the ASP.NET framework and is useful for retrieving things out of the appsettings.json file like connection strings.
        public OwnerRepository(IConfiguration config)
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

        public List<Owner> GetAllOwners()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        Select n.Name as NeighborhoodName, O.Id as OwnerId, n.Id as NeighborhoodId, O.Name as OwnerName, Phone, Address From Owner O left join Neighborhood n ON O.Id = n.id
                    ";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Owner> owners = new List<Owner>();
                        while (reader.Read())
                        {
                            Owner owner = new Owner
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("OwnerId")),
                                Name = reader.GetString(reader.GetOrdinal("OwnerName")),
                                Phone = reader.GetString(reader.GetOrdinal("Phone")),
                                Address = reader.GetString(reader.GetOrdinal("Address")),

                                Neighborhood = new Neighborhood
                                {
                                   Name = reader.GetString(reader.GetOrdinal("NeighborhoodName")),

                                }
                            };

                            owners.Add(owner);
                        }

                        return owners;
                    }
                }
            }
        }
      
        public Owner GetOwnerById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, [Name], NeighborhoodId, Phone, Address
                        FROM Owner
                        WHERE Id = @id
                    ";

                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Owner owner = new Owner
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("OwnerId")),
                                Name = reader.GetString(reader.GetOrdinal("OwnerName")),
                                Phone = reader.GetString(reader.GetOrdinal("Phone")),
                                Address = reader.GetString(reader.GetOrdinal("Address")),

                                Neighborhood = new Neighborhood
                                {
                                    Name = reader.GetString(reader.GetOrdinal("NeighborhoodName")),

                                }
                            };

                            return owner;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
    }
}