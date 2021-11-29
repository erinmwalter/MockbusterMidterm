using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using MockbusterApp;

namespace Testing_MockbusterApp
{
    public class Testing_Admin
    {
        //first testing the methods associated with Adding a movie to list

        [Theory]
        //testing for movies I know are on list
        [InlineData(true, "Transformers", Genre.Action, "Michael Bay", "Shia LeBeouf", "Megan Fox")]
        [InlineData(true, "The Notebook", Genre.Romance, "Nick Cassavetes", "Ryan Gosling", "Rachel McAdams", "James Marsden")]
        //now testing for movies that are not on list to make sure not found
        [InlineData(false, "Erin's Big Adventure", Genre.SciFi, "Erin Walter", "Erin Walter")]
        [InlineData(false, "Harry Potter", Genre.SciFi, "Citation Needed: J.K. Rowling", "Daniel Radcliffe", "The Actor Who Plays Ron")]
        

        public void TestingIsFound(bool expected, string title, Genre genre, string director, params string[] actors)
        {
            Admin admin = new Admin();
            Movie toSearch = new Movie(title, genre, director, actors);
            bool actual = admin.isFound(toSearch);

            Assert.Equal(expected, actual);
        }

        [Theory]
        //using same tests, however now will return string for the AddMovie method
        //expecting these two to return the unable to add message since exist on list.
        [InlineData("Movie already exists in dataase. Could not add.", "Transformers", Genre.Action, "Michael Bay", "Shia LeBeouf", "Megan Fox")]
        [InlineData("Movie already exists in dataase. Could not add.", "The Notebook", Genre.Romance, "Nick Cassavetes", "Ryan Gosling", "Rachel McAdams", "James Marsden")]
        //now testing for movies that are not on list to make sure not found
        [InlineData("Successfully added movie!", "Erin's Big Adventure", Genre.Drama, "Hopefully Spielberg but probably Erin's Evil Twin", "Hank the White Cat")]
        [InlineData("Successfully added movie!", "Hermione Is The Real Hero", Genre.Romance, "Citation Needed: J.K. Rowling", "Daniel Radcliffe", "The Actor Who Plays Ron")]


        public void TestingAddMovie(string expected, string title, Genre genre, string director, params string[] actors)
        {
            Admin admin = new Admin();
            Movie toAdd = new Movie(title, genre, director, actors);
            string actual = admin.AddMovie(toAdd);

            Assert.Equal(expected, actual);
        }

        [Fact]

        public void TestingAddMovieWithMovie()
        {
            Movie newMovie = new Movie("Erin's Day Off: A Ferris Bueller Sequel", Genre.Drama, "Erin Sylvia Walter", "Erin Sylvia Walter", "Rainn Wilson", "Hank the Cat", "Leo the Cat");
            Admin admin = new Admin();
            admin.AddMovie(newMovie);

            bool isItThere = false;
            foreach(Movie movie in MovieRepo.MovieDB)
            {
                if(movie == newMovie)
                {
                    isItThere = true;
                    break;
                }
            }
            Assert.True(isItThere);
        }
        //now, testing the methods associated with removing movie from list
        [Theory]

        //Testing movies on the list
        [InlineData("The Devil Wears Prada", "Successfully removed movie!")]
        [InlineData("Marley and Me", "Successfully removed movie!")]

        //testing for movies that are not on the list
        [InlineData("Saving Private Ryan", "Movie not located in database. Could not remove.")]
        [InlineData("Space Jam", "Movie not located in database. Could not remove.")]
        public void TestingRemoveMovie(string title, string expected)
        {
            
            Admin admin = new Admin();
            Movie toRemove = MovieRepo.GetMovie(title);
            string actual = admin.RemoveMovie(toRemove);

            Assert.Equal(expected, actual);
        }

        [Theory]

        [InlineData("Just Mercy")]
        [InlineData("Wedding Crashers")]

        public void TestingRemoveMovieInRepo(string title)
        {
            Admin admin = new Admin();
            Movie toRemove = MovieRepo.GetMovie(title);
            admin.RemoveMovie(toRemove);
            bool notFound = true;
            foreach(Movie movie in MovieRepo.MovieDB)
            {
                if(movie.Title == title)
                {
                    notFound = false;
                }
            }
            Assert.True(notFound);
        }
       

    }
}
