using System.Collections.Generic;
using System.Linq;
using System;

namespace MockbusterApp
{
    public class Movie
    {
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public List<string> MainActors { get; set; } = new List<string>();
        public string Director { get; set; }


        public Movie(string Title, Genre Genre, string Director)
        {
            this.Title = Title;
            this.Genre = Genre;
            this.Director = Director;
        }
        public Movie(string Title, Genre Genre, string Director, params string[] MainActors)
        {
            this.Title = Title;
            this.Genre = Genre;
            this.Director = Director;
            this.MainActors = MainActors.ToList();
        }

        public override string ToString()
        {
            string output = "";
            output += "--------------------------------------------------";
            output += $"\n{Title,-36}Genre:{Genre,-9}";
            output += "\n--------------------------------------------------";
            output +=$"\nDirected by: {Director}\nStarring:    ";
            output += $"{MainActors[0]}\n";
            for (int i = 1; i< MainActors.Count; i++)
            {
                output += $"             {MainActors[i]}\n";
            }
            return output;
        }

        public void AddActors(List<string> actors)
        {
            foreach(string actor in actors)
            {
                MainActors.Add(actor);
            }
        }

        public void EditMovie()
        {
            bool goOn = true;
            while (goOn)
            {
                EditMovieDisplay();
                string choice = Helper.GetInput("Enter your selection: ");
                switch (choice)
                {
                    case "1":
                        //edit title
                        Title = Helper.GetInput("Enter New Title: ");
                        break;
                    case "2":
                        //edit genre
                        Genre = Helper.GetValidGenre();
                        break;
                    case "3":
                        //edit director
                        Director = Helper.GetInput("Enter New Director: ");
                        break;
                    case "4":
                        //add actor
                        string newActor = Helper.GetInput("Enter Actor to Add: ");
                        MainActors.Add(newActor);
                        break;
                    case "5":
                        //remove actor
                        string removedActor = Helper.GetInput("Enter Actor to Remove: ");
                        Console.WriteLine(RemoveActor(removedActor));    
                        break;
                    case "0":
                        //exit to main
                        goOn = false;
                        Console.WriteLine("Exiting to main menu...");
                        break;
                    default:
                        //error handling
                        Console.WriteLine("Invalid choice, try again...");
                        break;
                }
            }
        }

        public string RemoveActor(string removedActor)
        {
            foreach (string actor in MainActors)
            {
                if (actor == removedActor)
                {
                    MainActors.Remove(actor);
                    return "Successfully removed actor!";
                }
            }
            return "Could not locate actor on list. Unable to remove.";
        }


        public void EditMovieDisplay()
        {
            Console.Clear();
            Console.WriteLine(ToString());
            Console.WriteLine("**************************");
            Console.WriteLine("*       Movie Menu       *");
            Console.WriteLine("**************************");
            Console.WriteLine("* 1. Edit Title          *");
            Console.WriteLine("* 2. Edit Genre          *");
            Console.WriteLine("* 3. Edit Director       *");
            Console.WriteLine("* 4. Add Actor           *");
            Console.WriteLine("* 5. Remove Actor        *");
            Console.WriteLine("* 0. Return to Main Menu *");
            Console.WriteLine("**************************");
        }

    }


}
