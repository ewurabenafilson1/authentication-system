namespace authenticationSystem
{
    public class Register
    {
        public static void PerformRegistration()
        {
            string filePath = "Users.json"; 

            Console.WriteLine("Register a new account");
            Console.Write("Enter username: ");
            string username = Console.ReadLine()!;

            Console.Write("Enter password: ");
            string password = Console.ReadLine()!;

            Console.Write("Enter email: ");
            string email = Console.ReadLine()!;

            // Here you would typically save the user details to a database
            Console.WriteLine("Registration successful!");
        }   
    }
}