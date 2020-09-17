
using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests

    {
        [Fact] 
        public void BookCalculatesAnAverageGrade()
        {
           

            //Arrange: this is where we put together all test data and also arrange all objects and values we are going to use

            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            //Act : this is where we implement or call a method to do something, capable of producing the actual result
            var result = book.GetStatistics();

            //Assert: where we assert something concerning the values in act
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('A', result.Letter);

        }
    }
}
