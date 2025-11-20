using System.Net.Security;

namespace authenticationSystem
{
    class Program
    {
        static void Main()
        {
            

            Console.WriteLine("Hello!");
            Console.WriteLine("1. Already have an account? Login");
            Console.WriteLine("2. New user? Register");

            string choice = Console.ReadLine()!;
            if (choice == "1")
            {
                Login.PerformLogin();
            }
            else if (choice == "2")
            {
               Register.PerformRegistration();
            }
            else
            {
                Console.WriteLine("Invalid choice.");

            }

        }
    }   
}