using System;
using System.Collections.Generic;
using System.Text;

namespace MockbusterApp
{
    public class Helper
    {
        //helper class for all static helper methods of getting and validating input.
        public static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine().Trim();
        }

        //essentially pauses screen until user presses any key
        public static void Pause(string prompt)
        {
            Console.WriteLine(prompt);
            Console.ReadKey();
        }
        public static Genre GetValidGenre()
        {
            Console.WriteLine("***********************");
            Console.WriteLine("*   Genre Selections  *");
            Console.WriteLine("***********************");
            Console.WriteLine("[1]Action\n[2]Horror\n[3]SciFi\n[4]Romance\n[5]Drama\n[6]Comedy\n[7]Animated\n ***********************\n");
            string choice = GetInput("Enter Choice: ");
            switch (choice)
            {
                case "1":
                    return Genre.Action;
                case "2":
                    return Genre.Horror;
                case "3":
                    return Genre.SciFi;
                case "4":
                    return Genre.Romance;
                case "5":
                    return Genre.Drama;
                case "6":
                    return Genre.Comedy;
                case "7":
                    return Genre.Animated;
                default:
                    Helper.Pause("Invalid selection, press any key to try again...");
                    return GetValidGenre();
            }
        }

        public static bool Continue(string prompt)
        {
            Console.Write(prompt);
            string answer = Console.ReadLine().Trim().ToLower();
            if(answer == "y")
            {
                return true;
            }
            else if(answer == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Invalid input, try again...");
                return Continue(prompt);
            }
        }
        
    }
}
