using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace authenticationSystem
{
    public class Register
    {
        public static void PerformRegistration(List<User> users)
        {
            users = LoadUsers();

            Console.WriteLine("Register a new account");
            Console.Write("Enter username: ");
            string username = Console.ReadLine()!;

            Console.Write("Enter password: ");
            string password = Console.ReadLine()!;

            Console.Write("Enter email: ");
            string email = Console.ReadLine()!;

            User newUser = new User(username, password, email);
            users.Add(newUser);

            SaveUsers(users);

            Console.WriteLine("Registration successful!");
        }

        public static List<User> LoadUsers()
        {
            string filePath = "Users.json";

            if (!File.Exists(filePath))
            {
                return new List<User>();
            }

            string json = File.ReadAllText(filePath);

            //  Corrected empty-file check (this was the bug)
            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<User>();
            }

            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }

        public static void SaveUsers(List<User> users)
        {
            string json = JsonSerializer.Serialize(users,
                new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText("Users.json", json);

            Console.WriteLine("\n💾 Users saved successfully!\n");
        }
    }
}
