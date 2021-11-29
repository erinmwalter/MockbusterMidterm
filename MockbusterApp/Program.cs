using System;

namespace MockbusterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Admin admin = new Admin();
            bool goOn = true;

            while (goOn)
            {
                MainMenuDisplay();
                string choice = Helper.GetInput("Make your Selection: ");
                switch (choice)
                {
                    case "1":
                        string name = Helper.GetInput("Enter your name: ");
                        User user = new User(name);
                        user.Menu();
                        break;
                    case "2":
                        string password = Helper.GetInput("Enter Password: ");
                        if (password == admin.Password)
                        {
                            admin.Menu();
                        }
                        else
                        {
                            Helper.Pause("Incorrect Password. Access Denied.\nPress any key to return to menu.");
                            continue;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid selection, try again...");
                        continue;
                }
                goOn = Helper.Continue("Login as another user? (y/n): ");
            }
            Console.WriteLine("Exiting Program. Good bye!");

        }

        public static void MainMenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("*************************");
            Console.WriteLine("* Welcome to Mockbuster!*");
            Console.WriteLine("*************************");
            Console.WriteLine("* How can we help you?  *");
            Console.WriteLine("* 1. User Login         *");
            Console.WriteLine("* 2. Admin Login        *");
            Console.WriteLine("*************************");
        }

    }
}
