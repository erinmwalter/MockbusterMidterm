using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MockbusterApp;

namespace Testing_MockbusterApp
{
    public class Test_Movie
    {
        //testing for the edit movie capabilities
        //for the most part the properties are being update directly
        [Theory]
        //should successfully remove these as they are on actor list
        [InlineData("Martin Sheen", "Successfully removed actor!")]
        [InlineData("Matt Damon", "Successfully removed actor!")]

        //should not be able to remove these as they are not on the actor list
        [InlineData("Brad Pitt", "Could not locate actor on list. Unable to remove.")]
        [InlineData("Denzel Washington", "Could not locate actor on list. Unable to remove.")]

        public void TestingRemoveActor(string actor, string expected)
        {
            Movie theDeparted = new Movie("The Departed", Genre.Drama, "Martin Scorsese", 
                               "Leonardo DiCaprio", "Matt Damon", "Jack Nicholson", "Mark Wahlberg", "Martin Sheen", "Alec Baldwin");

            string actual = theDeparted.RemoveActor(actor);

            Assert.Equal(expected, actual);
        }

        
        
    }
}
