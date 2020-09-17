
using System;
using Xunit;


namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);
    
    public class TypeTests

    {
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log;
            log = ReturnMessage;

            var result = log("Hello!");
            Assert.Equal("Hello!", result);
        }
        
        string ReturnMessage(string message)
        {
            return message;
        }
        [Fact]

        public void ValueTypesAlsoPassByReference()
        {
            var y = GetIntRef();
            setIntRef(ref y);

            Assert.Equal(42, y);
        }

        private void setIntRef(ref int z)
        {
            z = 42;
        }

        private int GetIntRef()
        {
            return 3;
        }

        [Fact]

        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            setInt(x);

            Assert.Equal(3, x);
        }

        private void setInt(int z)
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CsharpCanPassByReference()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(out book1, "New Name");

            Assert.Equal("New Name", book1.Name);

        }

        private void GetBookSetName(out Book book, string name)//out used instead of ref in order to help cub 'book = new Book(name)' initialization

        {
            book = new Book(name);
        }

        [Fact]
        public void CsharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);

        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }
    
        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
            
        }

        void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }


        [Fact] 
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));

        }
        Book GetBook(string name)
        {
            return new Book(name);
        }
        [Fact]
        public void StringsBehavesLikeValueTypes() //returns a lower case instead of upper as expected
        {
            string name = "okeji";
            MakeUpperCase(name);

            Assert.Equal("okeji", name);
        }

        private void MakeUpperCase(string parameter)
        {
            parameter.ToUpper();
        }

        [Fact]
        public void StringsToActuallyReturnAnUpper()
        {
            string name = "okeji";
            var upper = ToUpperCase(name);

            Assert.Equal("okeji", name);
            Assert.Equal("OKEJI", upper);
        }

        private string ToUpperCase(string NewParameter)
        {
            return NewParameter.ToUpper();
        }

    }

}
