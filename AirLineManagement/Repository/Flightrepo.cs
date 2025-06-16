using AirLineManagement.Model;
using AirLineManagement.Utils;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace AirLineManagement.Repository
{
    public class Flightrepo : IFlightrepo
    {

        private readonly string connstring = "connstring";
        public void AddDefaultAdminUser()
        {
            using var conn = new SqlConnection(connstring);
            conn.Open();
           

            string query = @"INSERT INTO [FlyWithMe].[dbo].[Users] 
                             ([UserId], [Username], [PasswordHash], [UserRole]) 
                             VALUES (@id, @username, @password, @role)";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", 1);
            cmd.Parameters.AddWithValue("@username", "admin");
            cmd.Parameters.AddWithValue("@password", "123");
            cmd.Parameters.AddWithValue("@role", 1);

            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine(rows > 0 ? "User inserted successfully." : "Insert failed.");
        }
        

        public List<Flight> GetAllFlights()
        {
            var flights = new List<Flight>();

            using var conn = new SqlConnection(connstring);
            conn.Open();
            string query = "SELECT * FROM Flights";
            using var cmd = new SqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                flights.Add(new Flight
                {
                    FlightId = (int)reader["FlightId"],
                    DepAirportId = (int)reader["DepAirportId"],
                    DepDate = (DateTime)reader["DepDate"],
                    DepTime = (TimeSpan)reader["DepTime"],
                    ArrAirportId = (int)reader["ArrAirportId"],
                    ArrDate = (DateTime)reader["ArrDate"],
                    ArrTime = (TimeSpan)reader["ArrTime"]
                });
            }
            return flights;
        }

        public Flight? GetFlightById(int id)
        {
            using var conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            string query = "SELECT * FROM Flights WHERE FlightId = @id";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Flight
                {
                    FlightId = (int)reader["FlightId"],
                    DepAirportId = (int)reader["DepAirportId"],
                    DepDate = (DateTime)reader["DepDate"],
                    DepTime = (TimeSpan)reader["DepTime"],
                    ArrAirportId = (int)reader["ArrAirportId"],
                    ArrDate = (DateTime)reader["ArrDate"],
                    ArrTime = (TimeSpan)reader["ArrTime"]
                };
            }
            return null;
        }

        public void AddFlight(Flight f)
        {
            using var conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            string query = @"INSERT INTO Flights 
                (DepAirportId, DepDate, DepTime, ArrAirportId, ArrDate, ArrTime)
                VALUES (@dep, @depDate, @depTime, @arr, @arrDate, @arrTime)";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@dep", f.DepAirportId);
            cmd.Parameters.AddWithValue("@depDate", f.DepDate);
            cmd.Parameters.AddWithValue("@depTime", f.DepTime);
            cmd.Parameters.AddWithValue("@arr", f.ArrAirportId);
            cmd.Parameters.AddWithValue("@arrDate", f.ArrDate);
            cmd.Parameters.AddWithValue("@arrTime", f.ArrTime);
            cmd.ExecuteNonQuery();
        }

        public void UpdateFlight(Flight f)
        {
            using var conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            string query = @"UPDATE Flights SET 
                DepAirportId = @dep, DepDate = @depDate, DepTime = @depTime,
                ArrAirportId = @arr, ArrDate = @arrDate, ArrTime = @arrTime 
                WHERE FlightId = @id";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", f.FlightId);
            cmd.Parameters.AddWithValue("@dep", f.DepAirportId);
            cmd.Parameters.AddWithValue("@depDate", f.DepDate);
            cmd.Parameters.AddWithValue("@depTime", f.DepTime);
            cmd.Parameters.AddWithValue("@arr", f.ArrAirportId);
            cmd.Parameters.AddWithValue("@arrDate", f.ArrDate);
            cmd.Parameters.AddWithValue("@arrTime", f.ArrTime);
            cmd.ExecuteNonQuery();
        }
    }
}