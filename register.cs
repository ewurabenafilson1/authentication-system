using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using BCrypt.Net; // BCrypt.Net-Next

namespace authenticationSystem
{
    public class Register
    {
        private const int WorkFactor = 10;

        public static void PerformRegistration()
        {
            List<User> users = LoadUsers();

            Console.WriteLine("Register a new account");
            Console.Write("Enter username: ");
            string username = Console.ReadLine()!.Trim();

            Console.Write("Enter email: ");
            string email = Console.ReadLine()!.Trim();

            // Use masked input for password
            Console.Write("Enter password: ");
            string password = HidePassword();

            
            string hashedpassword = BCrypt.Net.BCrypt.HashPassword(password, workFactor: WorkFactor);

            // Store the hash (never store plaintext)
            User newUser = new User(username, hashedpassword, email);
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

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<User>();
            }

            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }

        public static void SaveUsers(List<User> usersInfo)
        {
            string json = JsonSerializer.Serialize(usersInfo, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("Users.json", json);
            Console.WriteLine("\n💾 Users saved successfully!\n");
        }

     private static string HidePassword()
        {
            var password = new System.Text.StringBuilder();
            ConsoleKeyInfo keyInfo;
            while (true)
            {
                keyInfo = Console.ReadKey(intercept: true);
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (password.Length > 0)
                    {
                        password.Length--;
                        Console.Write("\b \b");
                    }
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    password.Append(keyInfo.KeyChar);
                    Console.Write("*");
                }
            }
            return password.ToString();
        }
    }
}
