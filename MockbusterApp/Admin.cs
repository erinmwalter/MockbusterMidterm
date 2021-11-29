using System;
using System.Collections.Generic;
using System.Text;

namespace MockbusterApp
{
    public class Admin : User
    {

        public string Password { get; set; } = "Il0veM0vie$";

        public Admin() : base("Admin")
        {

        }

        //adds movie to DB if movie does not already exist
        public string AddMovie(Movie movie)
        {
            if (!isFound(movie))
            {
                MovieRepo.MovieDB.Add(movie);
                return "Successfully added movie!";
            }
            return "Movie already exists in dataase. Could not add.";
        }

        //method to remove move from list, returns string whether successful or not
        public string RemoveMovie(Movie movie)
        {
            if (movie == null)
            {
                return "Movie not located in database. Could not remove.";
            }
            else if (isFound(movie)) 
            {
                MovieRepo.MovieDB.Remove(movie);
                return "Successfully removed movie!";
            }
            else
            {
                return "Movie not located in database. Could not remove.";
            }
        }

        //does a check to see if movie is found in DB before adding
        public bool isFound(Movie movie)
        {
            foreach (Movie m in MovieRepo.MovieDB)
            {
                if(m.Title.ToLower() == movie.Title.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        //since we are adding a new movie, need to first create movie object
        //to pass to movie DB to add
        public Movie CreateNewMovie()
        {
            
            List<string> actors = new List<String>();
            Console.Clear();
            Console.WriteLine("***********************");
            Console.WriteLine("*    Add New Movie    *");
            Console.WriteLine("***********************");
            string title = Helper.GetInput("Enter Title: ");
            Genre genre = Helper.GetValidGenre();
            string director = Helper.GetInput("Enter Director: ");
            while (true)
            {
                string actor = Helper.GetInput("Enter Actor or 'q' to stop:  ");
                if (actor.Trim().ToLower() == "q")
                {
                    break;
                }
                else
                {
                    actors.Add(actor);
                }
                
            }

            Movie newMovie = new Movie(title, genre, director);
            newMovie.AddActors(actors);

            return newMovie;
        }

        //this is the main driver method behind the admin's functionality
        //gets a choice from the admin and then directs them to other methods
        public override void Menu()
        {
            bool goOn = true;
            string filter = "";
            while (goOn)
            {
                DisplayForMenu();
                string choice = Helper.GetInput("Make Your Selection: ");
                switch (choice)
                {
                    case "1":
                        //filter by genre
                        Genre genre = Helper.GetValidGenre();
                        FilteredList = FilterByGenre(genre);
                        filter = $"{genre}";
                        DisplayFilteredList(filter);
                        break;
                    case "2":
                        //filter by title
                        filter = Helper.GetInput("Enter Movie Name: ");
                        FilteredList = FilterMoviesByTitle(filter);
                        DisplayFilteredList(filter);
                        break;
                    case "3":
                        //filter by actor
                        filter = Helper.GetInput("Enter Actor's Name: ");
                        FilteredList = FilterByMainActor(filter);
                        DisplayFilteredList(filter);
                        break;
                    case "4":
                        //filter by director
                        filter = Helper.GetInput("Enter Director's Name: ");
                        FilteredList = FilterByDirector(filter);
                        DisplayFilteredList(filter);
                        break;
                    case "0":
                        //logout
                        goOn = false;
                        Console.WriteLine("Logging out. Goodbye!");
                        break;
                    case "5":
                        //add movie
                        Movie movie = CreateNewMovie();
                        Console.WriteLine(AddMovie(movie));
                        Helper.Pause($"Successfully Added {movie.Title}!\nPress any key to return to menu...");
                        break;
                    case "6":
                        //remove movie
                        Console.Clear();
                        Console.WriteLine("***********************");
                        Console.WriteLine("*    Remove Movie     *");
                        Console.WriteLine("***********************");
                        string title = Helper.GetInput("Enter Title of Movie to Remove: ");
                        Movie toRemove = MovieRepo.GetMovie(title);
                        Console.WriteLine(RemoveMovie(toRemove));
                        Helper.Pause("Press any key to return to menu...");
                        break;
                    case "7":
                        //edit movie
                        Console.Clear();
                        Console.WriteLine("***********************");
                        Console.WriteLine("*     Edit Movie      *");
                        Console.WriteLine("***********************");
                        title = Helper.GetInput("Enter Title of Movie to Edit: ");
                        Movie toEdit = MovieRepo.GetMovie(title);
                        if(toEdit != null)
                        {
                            toEdit.EditMovie();
                        }
                        break;
                    case "8":
                        PromoteMovies();
                        break;  
                    case "9":
                        Console.Clear();
                        SetNewPassword();
                        break;
                    default:
                        //error handling
                        Helper.Pause("Invalid entry, press any key to try again...");
                        continue;
                }
            }

        }

        public void PromoteMovies()
        {
            //add suggestions to promote certain movies
            while (true)
            {
                DisplaySuggestions();
                Console.WriteLine("***************************");
                Console.WriteLine("* Add to Suggestions List *");
                Console.WriteLine("***************************");
                string title = Helper.GetInput("Enter Movie Title or 'q' to quit: ");
                if (title.Trim().ToLower() == "q")
                {
                    break;
                }
                Movie toPromote = MovieRepo.GetMovie(title);
                if (toPromote != null)
                {
                    MovieRepo.Suggestions.Add(toPromote);
                    Console.WriteLine("Movie added to suggestions!");
                }
                else
                {
                    Helper.Pause("Could not locate movie in database, press any key to continue...");
                }
            }
        }

        
        private void SetNewPassword()
        {
            Console.WriteLine("***********************");
            Console.WriteLine("*   Update Password   *");
            Console.WriteLine("***********************");
            string newPassword = Helper.GetInput("Enter New Password: ");
            bool changeConfirm = Helper.Continue("Are you sure you want to change password? (y/n): ");
            if (changeConfirm)
            {
                Password = newPassword;
                Console.WriteLine("Password successfully updated!");
            }
            else
            {
                Console.WriteLine("Did not change password.");
            }
            Helper.Pause("Press any key to return to main menu...");
        }
        public override void DisplayForMenu()
        {
            Console.Clear();
            Console.WriteLine("*********************************");
            Console.WriteLine("*        Welcome, Admin         *");
            Console.WriteLine("*********************************");
            Console.WriteLine("* 1. Filter by Genre            *");
            Console.WriteLine("* 2. Filter by Movie Name       *");
            Console.WriteLine("* 3. Filter by Main Actor       *");
            Console.WriteLine("* 4. Filter by Director         *");
            Console.WriteLine("* 5. Add Movie to Database      *");
            Console.WriteLine("* 6. Remove Movie from Database *");
            Console.WriteLine("* 7. Edit Movie                 *");
            Console.WriteLine("* 8. Add to Suggestions List    *");
            Console.WriteLine("* 9. Change Password            *");
            Console.WriteLine("* 0. Logout                     *");
            Console.WriteLine("*********************************");
        }
    }
}
