using System;
using System.Collections.Generic;
using System.Text;

namespace MockbusterApp
{
    public class MovieRepo
    {
        //a public static list of movies that is initialized with a set of movies from the Get Movies class
        //can be added to and removed from only byt the Admin. The User can View all movies in DB.
        public static List<Movie> MovieDB = GetMovies();

        //admin suggestions list so they can "promote" or "suggest" movies to users
        public static List<Movie> Suggestions = new List<Movie>();

        public static List<Movie> GetMovies()
        {
            List<Movie> database = new List<Movie>();

            database.Add(new Movie("Black Panther", Genre.Action, "Ryan Coogler", "Chadwick Boseman", "Michael B. Jordan", "Lupita Nyong'o", "Danai Gurira", "Daniel Kaluuya"));
            database.Add(new Movie("Avengers: Endgame", Genre.Action, "Joe and Anthony Russo", "Chris Evans", "Scarlett Johansson", "Robert Downey Jr.", "Mark Ruffalo", "Paul Rudd", "Chadwick Boseman"));
            database.Add(new Movie("Toy Story", Genre.Animated, "John Lasseter", "Tom Hanks", "Tim Allen", "Wallace Shawn"));
            database.Add(new Movie("The Little Mermaid", Genre.Animated, "Ron Clements", "Jodi Benson", "Samuel E. Wright", "Rene Auberjonois"));
            database.Add(new Movie("You've Got Mail", Genre.Romance, "Nora Ephron", "Tom Hanks", "Meg Ryan"));
            database.Add(new Movie("Catch Me if You Can", Genre.Drama, "Steven Spielberg", "Leonardo DiCaprio", "Tom Hanks", "Christopher Walken"));
            database.Add(new Movie("West Side Story", Genre.Drama, "Steven Spielberg", "Rachel Zegler", "Ansel Elgort", "Ariana DeBose"));
            database.Add(new Movie("The Princess Bride", Genre.Romance, "Rob Reiner", "Fred Savage", "Peter Falk", "Cary Elwes", "Mandy Patinkin", "Wallace Shawn", "Robin Wright"));
            database.Add(new Movie("E.T.", Genre.SciFi, "Steven Spielberg", "Henry Thomas", "Drew Barrymore", "Robert McNaughton", "Peter Coyote", "Dee Wallace"));
            database.Add(new Movie("Starwars IX: The Rise of Skywalker", Genre.SciFi, "J.J. Abrams", "Daisy Ridley", "Adam Driver", "Carrie Fisher", "Mark Hamill"));
            database.Add(new Movie("50 First Dates", Genre.Comedy, "Peter Segal", "Drew Barrymore", "Adam Sandler", "Rob Schneider"));
            database.Add(new Movie("Wedding Crashers", Genre.Comedy, "David Dobkin", "Owen Wilson", "Vince Vaughn", "Rachel McAdams", "Bradley Cooper"));
            database.Add(new Movie("Cars", Genre.Animated, "John Lasseter", "Owen Wilson", "Paul Newman", "Bonnie Hunt", "Larry the Cable Guy"));
            database.Add(new Movie("Inception", Genre.SciFi, "Christopher Nolan", "Leonardo DiCaprio", "Elliot Page", "Joseph Gordon-Levitt"));
            database.Add(new Movie("Juno", Genre.Comedy, "Jason Reitman", "Elliot Page", "Michael Cera", "Jason Bateman", "Jennifer Garner"));
            database.Add(new Movie("13 going on 30", Genre.Romance, "Gary Winick", "Jennifer Garner", "Mark Ruffalo"));
            database.Add(new Movie("He's Just Not That Into You", Genre.Romance, "Ken Kwapis", "Ben Affleck", "Jennifer Aniston", "Drew Barrymore", "Bradley Cooper", "Scarlett Johansson"));
            database.Add(new Movie("Silver Linings Playbook", Genre.Drama, "Dave O. Russell", "Bradley Cooper", "Jennifer Lawrence", "Robert DeNiro"));
            database.Add(new Movie("The Island", Genre.SciFi, "Michael Bay", "Ewan McGregor", "Scarlett Johansson", "Djimon Hounsou", "Sean Bean"));
            database.Add(new Movie("Transformers", Genre.Action, "Michael Bay", "Shia LeBeouf", "Megan Fox"));
            database.Add(new Movie("Get Out", Genre.Horror, "Jordan Peele", "Daniel Kaluuya", "Allison Williams"));
            database.Add(new Movie("Just Mercy", Genre.Drama, "Destin Daniel Cretton", "Michael B. Jordan", "Jamie Foxx", "Rob Morgan"));
            database.Add(new Movie("Us", Genre.Horror, "Jordan Peele", "Lupita Nyong'o", "Winston Duke"));
            database.Add(new Movie("The Ring", Genre.Horror, "Gore Verbinski", "Naomi Watts", "Martin Henderson", "David Dorfman"));
            database.Add(new Movie("Divergent", Genre.SciFi, "Neil Burger", "Shailene Woodley", "Theo James"));
            database.Add(new Movie("Divergent: Allegiant", Genre.SciFi, "Neil Burger", "Shailene Woodley", "Theo James", "Naomi Watts"));
            database.Add(new Movie("The Descendants", Genre.Comedy, "Alexander Payne", "George Clooney", "Shailene Woodley", "Amara Miller", "Beau Bridges", "Judy Greer"));
            database.Add(new Movie("Ocean's Eleven", Genre.Drama, "Steven Soderbergh", "George Clooney", "Brad Pitt", "Casey Affleck", "Matt Damon", "Julia Roberts"));
            database.Add(new Movie("The Hunger Games", Genre.SciFi, "Gary Ross", "Jennifer Lawrence", "Liam Hensworth", "Josh Hutcherson", "Woody Harrelson"));
            database.Add(new Movie("The Big Short", Genre.Drama, "Adam McKay", "Christian Bale", "Brad Pitt", "Steve Carell", "Ryan Gosling"));
            database.Add(new Movie("The Notebook", Genre.Romance, "Nick Cassavetes", "Ryan Gosling", "Rachel McAdams", "James Marsden"));
            database.Add(new Movie("The Departed", Genre.Drama, "Martin Scorsese", "Leonardo DiCaprio", "Matt Damon", "Jack Nicholson", "Mark Wahlberg", "Martin Sheen", "Alec Baldwin"));
            database.Add(new Movie("The Wolf of Wall Street", Genre.Drama, "Martin Scorsese", "Leonardo DiCaprio", "Jonah Hill"));
            database.Add(new Movie("Good Will Hunting", Genre.Drama, "Gus Van Sant", "Robin Williams", "Matt Damon", "Ben Affleck", "Minnie Driver", "Stellan Skarsgard"));
            database.Add(new Movie("A Quiet Place", Genre.Horror, "John Krasinski", "Emily Blunt", "John Krasinski", "Millicent Simmonds", "Noah Jupe"));
            database.Add(new Movie("The Devil Wears Prada", Genre.Drama, "David Frankel", "Anne Hathaway", "Emily Blunt", "Meryl Streep"));
            database.Add(new Movie("Eight Crazy Nights", Genre.Animated, "Seth Kearsley", "Adam Sandler", "Jackie Titone", "Rob Schneider"));
            database.Add(new Movie("Anger Management", Genre.Comedy, "Peter Segal", "Adam Sandler", "Jack Nicholson"));
            database.Add(new Movie("Marley and Me", Genre.Drama, "David Frankel", "Owen Wilson", "Jennifer Aniston"));



            return database;

        }

        //an extension for this movie repo class to return the movie from the DB when a user enters title to search by
        public static Movie GetMovie(string title)
        {
            foreach(Movie movie in MovieDB)
            {
                if(movie.Title.ToLower() == title.ToLower())
                {
                    return movie;
                }
            }
            return null;
        }
    }
}
