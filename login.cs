using System.Reflection.Metadata;

namespace authenticationSystem
{
    public class Login
    {
        public static void PerformLogin(List<User> users )
        {
            Console.WriteLine("Login to your account");
            Console.Write("Enter username: ");
            string username = Console.ReadLine()!;

            Console.Write("Enter password: ");
            string password = Console.ReadLine()!;

            foreach(User user in users)
            {
             if (user.Username.ToLower() == username.ToLower() && user.Password.ToLower() == password.ToLower())
                {
                    Console.WriteLine($"\n✅ Login successful! Welcome, {user.Username}.\n");
                }   
            }

            Console.WriteLine("\n❌ Login failed! Invalid username or password.\n");
        }
    }   
}