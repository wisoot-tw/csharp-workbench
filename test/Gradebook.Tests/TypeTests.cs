using System;
using Xunit;

namespace Gradebook.Tests
{
    public struct Shape
    {
        public string Name;

        public int Area;
    }

    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        private int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;

            var result = log("Hello!");
            Assert.Equal("Hello!", result);
        }

        [Fact]
        public void WriteLogMultiCastDelegate()
        {
            WriteLogDelegate log = ReturnMessage;
            log += this.ReturnMessage;
            log += this.IncrementCount;

            var result = log("Hello!");
            Assert.Equal("hello!", result);
            Assert.Equal(3, this.count);
        }

        private string IncrementCount(string message)
        {
            ++count;
            return message.ToLower();
        }

        private string ReturnMessage(string message)
        {
            ++count;
            return message;
        }

        [Fact]
        public void TestGetBookReturnDiferentObjects()
        {
            var book1 = this.GetBook("Book1");
            var book2 = this.GetBook("Book2");

            Assert.Equal("Book1", book1.Name);
            Assert.Equal("Book2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TestTwoVarsCanRefeneceSameObject()
        {
            var book1 = this.GetBook("Book1");
            var book2 = book1;

            Assert.Equal("Book1", book1.Name);
            Assert.Equal("Book1", book2.Name);

            book2.Name = "Book2";

            Assert.Equal("Book2", book1.Name);
            Assert.Equal("Book2", book2.Name);

            Assert.Same(book1, book2);
        }

        [Fact]
        public void TestRefOutBahaviour()
        {
            var book = this.GetBook("Book1");
            Assert.Equal("Book1", book.Name);

            this.SetBookName(book);
            Assert.Equal("new name", book.Name);

            this.SetRefBookName(ref book);
            Assert.Equal("new new name", book.Name);

            this.GetOutBook(out Book book2, "Book2");
            Assert.Equal("Book2", book2.Name);
        }

        [Fact]
        public void TestStructIsNotAssignedAsReference()
        {
            var shape1 = new Shape();
            shape1.Name = "Square";
            shape1.Area = 12;
            var shape2 = shape1;

            Assert.Equal("Square", shape1.Name);
            Assert.Equal("Square", shape2.Name);

            shape2.Name = "Circle";

            Assert.Equal("Square", shape1.Name);
            Assert.Equal("Circle", shape2.Name);
        }

        private Book GetBook(string name)
        {
            return new Book(name);
        }

        private void SetBookName(Book book)
        {
            book.Name = "new name";
        }

        private void SetRefBookName(ref Book book)
        {
            book.Name = "new new name";
        }

        private void GetOutBook(out Book book, string name)
        {
            book = new Book(name);
        }
    }
}