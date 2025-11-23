using System;
using System.Collections.Generic;
using BCrypt.Net; // BCrypt.Net-Next

namespace authenticationSystem
{
    public class Login
    {
        private const int CurrentWorkFactor = 10;

        public static void PerformLogin(List<User> users)
        {
            Console.WriteLine("Login to your account");

            Console.Write("Enter username: ");
            string username = Console.ReadLine()!.Trim();

            Console.Write("Enter password: ");
            string password = HidePassword();

            foreach (User user in users)
            {
        
                if (user.Username.Equals(username, StringComparison.OrdinalIgnoreCase))
                {
                    bool passwordCorrect = BCrypt.Net.BCrypt.Verify(password, user.Password);
                    if (passwordCorrect)
                    {
                        Console.WriteLine($"Login successful! Welcome, {user.Username}.");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect password. Please try again.");
                    }   
                }
                else
                {
                    Console.WriteLine("Username not found. Please try again.");
                }
            }
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
