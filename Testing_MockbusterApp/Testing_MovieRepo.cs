using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MockbusterApp;
using System.Linq;

namespace Testing_MockbusterApp
{
    public class Testing_MovieRepo
    {
        [Theory]

        //testing with movies that are in the list
        [InlineData("Juno", true)]
        [InlineData("The Big Short", true)]
        [InlineData("You've Got Mail", true)]

        //testing with movies that are not in the list
        [InlineData("Ocean's Twelve", false)]
        [InlineData("Harry Potter and the Sorcerer's Stone", false)]
        [InlineData("Sleepless in Seattle", false)]

        public void TestingGetAllMoviesByTitles(string title, bool expected)
        {
            
            List<Movie> myMovieDB = MovieRepo.GetMovies();

            bool actual = false;
            foreach(Movie movie in myMovieDB)
            {
                if(movie.Title == title)
                {
                    actual = true;
                    break;
                }
            }
            Assert.Equal(expected, actual);
            
        }

        [Theory]
        //testing for directors populating
        //first for directors in the list
        [InlineData("Jordan Peele", 2)]
        [InlineData("Steven Spielberg", 3)]
        [InlineData("Adam McKay", 1)]

        //testing for directors not in the list
        [InlineData("Stanley Kubrick", 0)]
        [InlineData("Orson Welles", 0)]
        [InlineData("Quentin Taratino", 0)]

        public void TestingGetAllMoviesByDirectors(string directorName, int expected)
        {
            List<Movie> myMovieDB = MovieRepo.GetMovies();
            int actual = 0;
            foreach(Movie movie in myMovieDB)
            {
                if(movie.Director == directorName)
                {
                    actual++;
                }
            }

            Assert.Equal(expected, actual);
        }

        [Theory]
        //testing for actors populating in the actor lists for each movie
        [InlineData("Matt Damon", 3)]
        [InlineData("Tom Hanks", 3)]
        [InlineData("Jennifer Lawrence", 2)]

        //testing for actors who are not in the list:
        [InlineData("Nicole Kidman", 0)]
        [InlineData("Katharine Hepburn", 0)]
        [InlineData("Denzel Washington", 0)]

        public void TestingGetAllMoviesActorsTimesAppeared(string actor, int expected)
        {
            List<Movie> myMovieDB = MovieRepo.GetMovies();
            int actual = 0;
            foreach (Movie movie in myMovieDB)
            {
                foreach(string person in movie.MainActors)
                if (person == actor)
                {
                    actual++;
                }
            }

            Assert.Equal(expected, actual);
        }

        [Theory]
        //testing for ones in list that should return movie object
        [InlineData("Toy Story", true)]
        [InlineData("Ocean's Eleven", true)]

        //should return a null movie object
        [InlineData("The Lion King", false)]
        [InlineData("The Bourne Identity", false)]

        public void TestingGetMovie(string title, bool expected)
        {
            Movie movie = MovieRepo.GetMovie(title);
            bool actual = false; ;
            if(movie != null)
            {
                actual = true;   
            }

            Assert.Equal(expected, actual);
        }

        [Theory]
        //one more test for get movie to look to make sure properties match up
        [InlineData(true, "Toy Story", "Toy Story", Genre.Animated, "John Lasseter", "Tom Hanks", "Tim Allen", "Wallace Shawn")]
        [InlineData(true, "Ocean's Eleven", "Ocean's Eleven", Genre.Drama, "Steven Soderbergh", "George Clooney", "Brad Pitt", "Casey Affleck", "Matt Damon", "Julia Roberts")]

        public void TestingGetMovieByProperties(bool expected, string title, string e_title, Genre e_genre, string e_director, params string[] e_actors)
        {
            Movie movie = MovieRepo.GetMovie(title);
            bool actual = false;
            if (movie.Title == e_title && movie.Genre == e_genre && movie.Director == e_director && movie.MainActors[0] == e_actors[0])
            {
                actual = true;
            }

            Assert.Equal(expected, actual);
        }
    }
}
