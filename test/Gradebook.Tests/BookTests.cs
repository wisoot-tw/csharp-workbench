using System;
using Xunit;
using System.Collections.Generic;

namespace Gradebook.Tests
{
    public class BookTests
    {
        [Fact]
        public void TestGetStatistics()
        {
            var book = new Book("");
            book.SetGrades(new List<double>() { 3.12, 2.23, 1, 4 });
            var statistics = book.GetStatistics();

            Assert.Equal(2.59, statistics.Average, 2);
            Assert.Equal(4, statistics.High);
            Assert.Equal(1, statistics.Low);
        }

        [Fact]
        public void TestGetAverageGrade()
        {
            var book = new Book("");
            book.SetGrades(new List<double>() { 3, 2, 1, 4 });

            Assert.Equal(2.5, book.GetAverageGrade());
        }

        [Fact]
        public void TestGetHighestGrade()
        {
            var book = new Book("");
            book.SetGrades(new List<double>() { 3, 2, 1, 4 });

            Assert.Equal(4, book.GetHighestGrade());
        }

        [Fact]
        public void TestGetLowestGrade()
        {
            var book = new Book("");
            book.SetGrades(new List<double>() { 3, 2, 1, 4 });

            Assert.Equal(1, book.GetLowestGrade());
        }
    }
}
