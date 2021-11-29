using System;
using System.Collections.Generic;

namespace MockbusterApp
{
    public class User
    {
        //just one property for now, user name. 
        //they are using the static movie DB so no need for a movie list here
        public string Name { get; set; }
        public List<Movie> FilteredList { get; set; } = new List<Movie>();

        //added feature that's going to let the user store movies in a "favorites" list
        public List<Movie> FavoritesList { get; set; } = new List<Movie>();

        //constructor
        public User(string Name)
        {
            this.Name = Name;
        }

        //Method to search for movies by genre
        //returns a list of movies of that genre
        public List<Movie> FilterByGenre(Genre genre)
        {
            List<Movie> genreList = new List<Movie>();
            foreach (Movie movie in MovieRepo.MovieDB)
            {
                if (movie.Genre == genre)
                {
                    genreList.Add(movie);
                }
            }
            return genreList;
        }

        //method to serach for a movie by title
        //returns all movies that contain the string the user enters.
        public List<Movie> FilterMoviesByTitle(string title)
        {
            List<Movie> foundMovies = new List<Movie>();
            foreach (Movie movie in MovieRepo.MovieDB)
            {
                if (movie.Title.Contains(title))
                {
                    foundMovies.Add(movie);
                }
            }
            return foundMovies;
        }

        //method to search for movie by featured actor
        //will look through each movie's Actor list
        //and if an actor is on that list will add the movie to the list
        //then return movie list
        public List<Movie> FilterByMainActor(string actorName)
        {
            List<Movie> foundMovies = new List<Movie>();
            foreach (Movie movie in MovieRepo.MovieDB)
            {
                foreach (string actor in movie.MainActors)
                {
                    if (actor == actorName)
                    {
                        foundMovies.Add(movie);
                    }
                }
            }

            return foundMovies;
        }

        //method to search for movie by director
        //will search through list to see if given director matches any movies
        //return list of those movies to user.
        public List<Movie> FilterByDirector(string directorName)
        {
            List<Movie> foundMovies = new List<Movie>();
            foreach (Movie movie in MovieRepo.MovieDB)
            {
                if (directorName == movie.Director)
                {
                    foundMovies.Add(movie);
                }
            }

            return foundMovies;
        }

        //main user menu to choose what they would like to do.
        public virtual void Menu()
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
                        Console.Clear();
                        Genre genre = Helper.GetValidGenre();
                        FilteredList = FilterByGenre(genre);
                        filter = $"{genre}";
                        break;
                    case "2":
                        //filter by title
                        filter = Helper.GetInput("Enter Movie Name: ");
                        FilteredList = FilterMoviesByTitle(filter);
                        break;
                    case "3":
                        filter = Helper.GetInput("Enter Actor's Name: ");
                        FilteredList = FilterByMainActor(filter);
                        break;
                    case "4":
                        filter = Helper.GetInput("Enter Director's Name: ");
                        FilteredList = FilterByDirector(filter);
                        break;
                    case "5":
                        filter = "";
                        FavoritesMenu();
                        break;
                    case "6":
                        DisplaySuggestions();
                        Helper.Pause("Press any key to return to main menu...");
                        break;
                    case "0":
                        goOn = false;
                        Console.WriteLine("Logging out. Goodbye!");
                        break;
                    default:
                        //error handling
                        Helper.Pause("Invalid entry, press any key to try again...");
                        continue;
                }
                if (goOn && filter != "")
                {
                    DisplayFilteredList(filter);
                }
            }

        }

        //display of favorites
        public void ViewFavorites()
        {
            Console.Clear();
            Console.WriteLine("*************************************************");
            Console.WriteLine("*             Your Favorites List               *");
            Console.WriteLine("*************************************************");
            if (FavoritesList.Count == 0)
            {
                Console.WriteLine("           Sorry. No movies found.");
            }
            else
            {
                foreach (Movie movie in FavoritesList)
                {
                    Console.WriteLine(movie);
                }
            }

        }
        public void FavoritesMenu()
        {
            bool goOn = true;
            while (goOn)
            {
                ViewFavorites();
                Console.WriteLine("*************************************************");
                Console.WriteLine("* What would you like to do?                    *");
                Console.WriteLine("* 1. Add Movies To List                         *");
                Console.WriteLine("* 2. Remove Movies From List                    *");
                Console.WriteLine("* 3. Return to Main Menu                        *");
                Console.WriteLine("*************************************************");
                string choice = Helper.GetInput("Enter your selection: ");

                if (choice == "1")
                {
                    AddFavorites();
                }
                else if (choice == "2")
                {
                    RemoveFavorite();
                }
                else if (choice == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid selection. Try again.");
                }
            }
        }

        //adds movie to favorites list
        public void AddFavorites()
        {
            Console.WriteLine("***********************");
            Console.WriteLine("*    Add Favorites    *");
            Console.WriteLine("***********************");
            bool goOn = true;
            while (goOn)
            {
                bool duplicate = false;
                string title = Helper.GetInput("Enter Title: ");
                Movie movieToAdd = MovieRepo.GetMovie(title);
                if (movieToAdd == null)
                {
                    Console.WriteLine("Unable to locate movie in database, could not add.");
                    continue;
                }
                foreach (Movie movie in FavoritesList)
                {
                    if (movie == movieToAdd)
                    {
                        Console.WriteLine("Movie already on favorites list, unable to add.");
                        duplicate = true;
                    }
                }
                if (!duplicate)
                {
                    FavoritesList.Add(movieToAdd);
                    Console.WriteLine("Successfully added!");
                }
                goOn = Helper.Continue("Add another movie? (y/n): ");
            }
        }

        public void RemoveFavorite()
        {
            Console.WriteLine("*************************");
            Console.WriteLine("* Remove from Favorites *");
            Console.WriteLine("*************************");
            string title = Helper.GetInput("Enter Title: ");
            foreach(Movie movie in FavoritesList)
            {
                if(title.ToLower() == movie.Title.ToLower())
                {
                    FavoritesList.Remove(movie);
                    return;
                }
            }
            Helper.Pause("Unable to locate movie on list. Unable to Remove.\nPress any key to return to favorites menu...");
        }

        //display of filtered movies
        public void DisplayFilteredList(string filter)
        {
            Console.Clear();
            Console.WriteLine("***************************************************");
            Console.WriteLine($"*     Your movies filtered by: {filter, -19}*");
            Console.WriteLine("***************************************************");

            if (FilteredList.Count == 0)
            {
                Console.WriteLine("             Sorry. No movies found.");
            }
            else
            {
                foreach (Movie movie in FilteredList)
                {
                    Console.WriteLine(movie);
                }
            }
            Console.WriteLine("***************************************************");
            Helper.Pause("Press any key to return to menu...");
        }

        //just the main menu display for the user giving them filter options
        public virtual void DisplayForMenu()
        {
            Console.Clear();
            Console.WriteLine("***************************");
            Console.WriteLine($"*   Welcome, {Name,-13}*");
            Console.WriteLine("***************************");
            Console.WriteLine("* 1. Filter by Genre      *");
            Console.WriteLine("* 2. Filter by Movie Name *");
            Console.WriteLine("* 3. Filter by Main Actor *");
            Console.WriteLine("* 4. Filter by Director   *");
            Console.WriteLine("* 5. View Your Favorites  *");
            Console.WriteLine("* 6. See Suggestions      *");
            Console.WriteLine("* 0. Logout               *");
            Console.WriteLine("***************************");
        }

        public void DisplaySuggestions() 
        {
            Console.Clear();
            Console.WriteLine("***************************************************");
            Console.WriteLine($"*            Suggested Movies List               *");
            Console.WriteLine("***************************************************");
            if (MovieRepo.Suggestions.Count == 0)
            {
                Console.WriteLine("             Sorry. No movies found.");
            }
            foreach(Movie movie in MovieRepo.Suggestions)
            {
                Console.WriteLine(movie);
            }
            Console.WriteLine("***************************************************");
        }

    }
}
