using MockbusterApp;
using System.Collections.Generic;
using Xunit;

namespace Testing_MockbusterApp
{
    public class Testing_User
    {
        [Theory]
        //testing filter by genre to see if returns correct sized list
        [InlineData(Genre.Animated, 4)]
        [InlineData(Genre.Action, 3)]
        [InlineData(Genre.SciFi, 7)]

        public void TestingFilterByGenreInt(Genre genre, int expected)
        {
            User erin = new User("Erin");
            List<Movie> movies = erin.FilterByGenre(genre);
            int actual = movies.Count;

            Assert.Equal(expected, actual);

        }

        [Fact]
        //established that the Genre.Action list yields 3 movies
        //now showing that this search yields a list that is exactly
        //the same a my custom built one of expected movies

        public void TestingFilterByGenreActionCase()
        {
            List<Movie> expected = new List<Movie>();
            Movie firstMovie = MovieRepo.GetMovie("Black Panther");
            Movie secondMovie = MovieRepo.GetMovie("Avengers: Endgame");
            Movie thirdMovie = MovieRepo.GetMovie("Transformers");
            expected.Add(firstMovie);
            expected.Add(secondMovie);
            expected.Add(thirdMovie);

            User user = new User("Erin");
            List<Movie> actual = user.FilterByGenre(Genre.Action);

            Assert.Equal(expected, actual);
        }

        [Fact]
        //testing with a couple of movies to see if a particular movie shows up in list
        //note: for some reason the list<string> when converted from string[] to list<string>
        //was failing the testing even though the movie objects looked identical.
        //unfortunately, i had to manually compare each element in an if statement to ascertain if they were the same object instead.

        public void TestingFilterByGenreListInception()
        {
            User erin = new User("Erin");
            List<Movie> movies = erin.FilterByGenre(Genre.SciFi);
            Movie inception = new Movie("Inception", Genre.SciFi, "Christopher Nolan", "Leonardo DiCaprio", "Elliot Page", "Joseph Gordon-Levitt");

            bool isItThere = false;
            foreach (Movie movie in movies)
            {
                if (movie.Title == inception.Title && movie.Genre == inception.Genre && movie.Director == inception.Director && movie.MainActors[0] == inception.MainActors[0]
                    && movie.MainActors[1] == inception.MainActors[1] && movie.MainActors[2] == inception.MainActors[2])
                {
                    isItThere = true;
                }
            }

            Assert.True(isItThere);
        }

        [Fact]

        public void TestingFilterByGenreListToyStory()
        {
            User erin = new User("Erin");
            List<Movie> movies = erin.FilterByGenre(Genre.Animated);
            Movie toyStory = new Movie("Toy Story", Genre.Animated, "John Lasseter", "Tom Hanks", "Tim Allen", "Wallace Shawn");

            bool isItThere = false;
            foreach (Movie movie in movies)
            {
                if (movie.Title == toyStory.Title && movie.Genre == toyStory.Genre && movie.Director == toyStory.Director && movie.MainActors[0] == toyStory.MainActors[0]
                    && movie.MainActors[1] == toyStory.MainActors[1] && movie.MainActors[2] == toyStory.MainActors[2])
                {
                    isItThere = true;
                }
            }

            Assert.True(isItThere);
        }

        [Theory]
        //testing filter by genre to make sure that ONLY movies of the specified genre show up on list
        [InlineData(Genre.Animated)]
        [InlineData(Genre.Action)]
        [InlineData(Genre.SciFi)]

        public void TestingFilterByGenreOnlyOneGenreLists(Genre genre)
        {
            User erin = new User("Erin");
            List<Movie> movies = erin.FilterByGenre(genre);
            bool isOnlyOneGenre = true;
            foreach (Movie movie in movies)
            {
                if (movie.Genre != genre)
                {
                    isOnlyOneGenre = false;
                    break;
                }
            }

            Assert.True(isOnlyOneGenre);

        }

        [Theory]

        [InlineData("Toy Story", "Toy Story", Genre.Animated, "John Lasseter", "Tom Hanks", "Tim Allen", "Wallace Shawn")]
        //my only thought with "Us" is if the list contains something like "The Usual Suspects" 
        //however, I am also ok with it adding something like "The Usual Suspects" to the list in a similar
        //manner to how if you were searching for a movie on netflix and typed in "Us" and a number of movies would pop up
        //that are all unrelated to one another besides containing "Us"
        [InlineData("Us", "Us", Genre.Horror, "Jordan Peele", "Lupita Nyong'o", "Winston Duke")]

        public void TestingFilterByName(string name, string e_name, Genre e_genre, string e_director, params string[] e_actors)
        {
            User erin = new User("Erin");
            Movie expected = new Movie(e_name, e_genre, e_director, e_actors);
            List<Movie> returnedMovies = erin.FilterMoviesByTitle(name);
            Movie actual = returnedMovies[0];

            Assert.Equal(expected.Title, actual.Title);
            Assert.Equal(expected.Genre, actual.Genre);
            Assert.Equal(expected.Director, actual.Director);
            Assert.Equal(expected.MainActors, actual.MainActors);
        }

        [Theory]
        //now testing list size for if multiple or zero movies returned
        [InlineData("Harry Potter", 0)]
        [InlineData("Divergent", 2)]
        //since the method is only searching for "contains" of the word
        //the should return a lot of movies
        [InlineData("The", 12)]

        public void TestingFilterByNameListSize(string name, int expected)
        {
            User erin = new User("Erin");
            List<Movie> returnedMovies = erin.FilterMoviesByTitle(name);
            int actual = returnedMovies.Count;

            Assert.Equal(expected, actual);
        }

        [Fact]  
        //have established the searching "Divergent" yields 2 movies
        //now want to show that the returned movies list from the method
        //match my expected custom built list

        public void TestingFilterByNameDivergentCase()
        {
            Movie firstMovie = MovieRepo.GetMovie("Divergent");
            Movie secondMovie = MovieRepo.GetMovie("Divergent: Allegiant");
            List<Movie> expected = new List<Movie>();
            expected.Add(firstMovie);
            expected.Add(secondMovie);

            User user = new User("Erin");
            List<Movie> actual = user.FilterMoviesByTitle("Divergent");

            Assert.Equal(expected, actual);
        }

        public void TestingFilterByNameByComparison(string title)
        {
            User erin = new User("Erin");
            List<Movie> returnedMovies = erin.FilterMoviesByTitle(title);
            Movie movie = MovieRepo.GetMovie(title);

        }

        [Theory]
        //now testing filter by actor, with entering actor name and a string array of expected titles
        //to populate on movie list, to compare the two
        [InlineData("Ben Affleck", "He's Just Not That Into You", "Good Will Hunting")]
        [InlineData("Jennifer Lawrence", "Silver Linings Playbook", "The Hunger Games")]


        public void TestingFilterByActor(string actor, params string[] expectedMovies)
        {
            User erin = new User("Erin");
            List<Movie> returnedMovies = erin.FilterByMainActor(actor);
            bool doTheyMatch = true;

            for (int i = 0; i < expectedMovies.Length; i++)
            {
                if (expectedMovies[i] != returnedMovies[i].Title)
                {
                    doTheyMatch = false;
                }
            }


            Assert.True(doTheyMatch);
        }

        [Theory]
        //wanted to get a better test to see if seraching for a name that does not exist
        //will return an empty (count = 0) list
        //retesting above tests to make sure 2 and only 2 movies returned as expected
        [InlineData("Ben Affleck", 2)]
        [InlineData("Jennifer Lawrence", 2)]

        //now testing with an actor who does not exist in list
        [InlineData("Erin Walter", 0)]
        //testing with a director name who should still yield 0 results
        [InlineData("Michael Bay", 0)]
        public void TestingFilterByActorByCount(string actor, int expected)
        {
            User erin = new User("Erin");
            List<Movie> returnedMovies = erin.FilterByMainActor(actor);
            int actual = returnedMovies.Count;

            Assert.Equal(expected, actual);
         
        }

        [Fact]
        //now that established the "Ben Affleck" returns 2 movies to list
        //want to set up the list outside of the method and make sure it matches
        //the one that the method sets up

        public void TestingFilterByActorBenAffleckCase()
        {
            Movie firstMovie = MovieRepo.GetMovie("He's Just Not That Into You");
            Movie secondMovie = MovieRepo.GetMovie("Good Will Hunting");
            List<Movie> expected = new List<Movie>();
            expected.Add(firstMovie);
            expected.Add(secondMovie);

            User erin = new User("Erin");
            List<Movie> actual = erin.FilterByMainActor("Ben Affleck");

            Assert.Equal(expected, actual);
        }


        [Theory]
        //now testing filter by director, enter director name, string[] of expected movie titles to populate list
        [InlineData("John Lasseter", "Toy Story", "Cars")]
        [InlineData("Steven Spielberg", "Catch Me if You Can", "West Side Story", "E.T.")]


        public void TestingFilterByDirectorName(string director, params string[] expectedMovies)
        {
            User erin = new User("Erin");
            List<Movie> returnedMovies = erin.FilterByDirector(director);
            bool doTheyMatch = true;

            for (int i = 0; i < expectedMovies.Length; i++)
            {
                if (expectedMovies[i] != returnedMovies[i].Title)
                {
                    doTheyMatch = false;
                }
            }


            Assert.True(doTheyMatch);
        }

        [Theory]
        //testing to make sure list lengths match up
        [InlineData("John Lasseter", 2)]
        [InlineData("Steven Spielberg", 3)]

        //now testing with an director who does not exist in list
        [InlineData("Erin Walter", 0)]
        //testing with a director name who should still yield 0 results
        [InlineData("Ben Affleck", 0)]
        //also wanted to test john krasinski, he is an actor and director so making sure doesn't
        //do anything weird and return him 2x
        [InlineData("John Krasinski", 1)]
        public void TestingFilterByDirectorByCount(string director, int expected)
        {
            User erin = new User("Erin");
            List<Movie> returnedMovies = erin.FilterByDirector(director);
            int actual = returnedMovies.Count;

            Assert.Equal(expected, actual);

        }

        [Fact]
        //now that i've established that the john lasseter titles match up
        //and that count of list matches up with expected
        //doing one last test case using the GetMovie method to make sure
        //that the lists are exactly the same

        public void TestingFilterByDirectorJohnLasseterCase()
        {
            User erin = new User("Erin");
            List<Movie> actual = erin.FilterByDirector("John Lasseter");

            Movie firstMovie = MovieRepo.GetMovie("Toy Story");
            Movie secondMovie = MovieRepo.GetMovie("Cars");
            List<Movie> expected = new List<Movie>();
            expected.Add(firstMovie);
            expected.Add(secondMovie);

            Assert.Equal(expected, actual);
        }
    }
}
