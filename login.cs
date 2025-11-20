 namespace authenticationSystem
{
    public class Login
    {
        public static void PerformLogin()
        {
            Console.WriteLine("Login to your account");
            Console.Write("Enter username: ");
            string username = Console.ReadLine()!;

            Console.Write("Enter password: ");
            string password = Console.ReadLine()!;

            // Here you would typically verify the user details from a database
            Console.WriteLine("Login successful!");
        }
    }

    
}