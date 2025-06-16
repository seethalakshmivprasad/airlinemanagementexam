using AirLineManagement.Model;
using AirLineManagement.Service;
using System;
using System.Configuration;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("hello world");
        string connectionString = ConfigurationManager.ConnectionStrings["CsWin"].ConnectionString;

        IFlightservice flightService = new FlightService(connectionString); // Pass connection string if needed

        while (true)
        {
            Console.WriteLine("\n=== Airline Management ===");
            Console.Write("Username: ");
            string username = Console.ReadLine()!;
            Console.Write("Password: ");
            string password = ReadPassword();
        }
    
            //    User? user = flightService.Login(username, password);

            //    if (user != null)
            //    {
            //        Console.WriteLine($"\nWelcome {user.Username} (Role {user.RoleId})!");

            //        // Role-based menu — extend as needed
            //        switch (user.RoleId)
            //        {
            //            case 1:
            //                ShowAdminMenu(flightService);
            //                break;
            //            default:
            //                Console.WriteLine("Access Denied or Unknown Role.");
            //                break;
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("Login failed. Check credentials.");
            //    }
            //}
        }

    static void ShowAdminMenu(IFlightservice flightService)
    {
        while (true)
        {
            Console.WriteLine("\n--- Admin Menu ---");
            Console.WriteLine("1. Show All Flights");
            Console.WriteLine("2. Search Flight by ID");
            Console.WriteLine("3. Add Flight");
            Console.WriteLine("4. Update Flight");
            Console.WriteLine("5. Exit");
            Console.Write("Choice: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    flightService.ShowAllFlights();
                    break;
                case "2":
                    Console.Write("Enter Flight ID: ");
                    int id = int.Parse(Console.ReadLine()!);
                    flightService.SearchFlight(id);
                    break;
                case "3":
                    Flight f = ReadFlightDetails();
                    flightService.CreateFlight(f);
                    break;
                case "4":
                    Flight f2 = ReadFlightDetails();
                    Console.Write("Enter Flight ID to update: ");
                    f2.FlightId = int.Parse(Console.ReadLine()!);
                    flightService.EditFlight(f2);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static Flight ReadFlightDetails()
    {
        var flight = new Flight();
        Console.Write("DepAirportId: ");
        flight.DepAirportId = int.Parse(Console.ReadLine()!);
        Console.Write("DepDate (yyyy-MM-dd): ");
        flight.DepDate = DateTime.Parse(Console.ReadLine()!);
        Console.Write("DepTime (HH:mm): ");
        flight.DepTime = TimeSpan.Parse(Console.ReadLine()!);
        Console.Write("ArrAirportId: ");
        flight.ArrAirportId = int.Parse(Console.ReadLine()!);
        Console.Write("ArrDate (yyyy-MM-dd): ");
        flight.ArrDate = DateTime.Parse(Console.ReadLine()!);
        Console.Write("ArrTime (HH:mm): ");
        flight.ArrTime = TimeSpan.Parse(Console.ReadLine()!);
        return flight;
    }

    static string ReadPassword()
    {
        string password = string.Empty;
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(intercept: true);
            if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password[0..^1];
                Console.Write("\b \b");
            }
            else if (!char.IsControl(key.KeyChar))
            {
                password += key.KeyChar;
                Console.Write("*");
            }
        } while (key.Key != ConsoleKey.Enter);

        Console.WriteLine();
        return password;
    }
}
