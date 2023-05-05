using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tests
{
    [TestClass()]
    public class ConstructorTests
    {
        [DataTestMethod()]
        [DataRow("University library", "Kaunas", "+37088899944")]
        [DataRow("Public library", "Ryga", "+37069799944")]
        [DataRow("Personal library", "Kaunas", "+3723899944")]
        public void ConstructorWith3Parameters_PropertiesNotNull_True(string libraryName, string address, string phoneNumber)
        {
            TaskUtils register = new TaskUtils();
            register.LibraryName = libraryName;
            register.Address = address;
            register.PhoneNumber = phoneNumber;

            Assert.IsNotNull(register);
        }
        [TestMethod()]
        public void ConstructorWith0Parameters_IsNull_True()
        {
            TaskUtils register = new TaskUtils();
            Assert.AreEqual(0,register.Count());
        }
        [DataTestMethod()]
        [DataRow("Harry Potter", "fantasy", "Allma Littera","2010-10-07",350,1000000,"ISBN-466799","J.K. Rowling")]
        [DataRow("Public library", "comedy", "Allma Littera","2009-11-20",200,50000,"ISBN-555333","Anonymous")]
        [DataRow("Vincas Kudirka's biography", "historical", "Obuolys","2010-07-25",150,10000,"ISBN-379155","Kazys Grinius")]
        public void ConstructorWithAContainer_BothCountsAreEqual_True(string name, string type, string publisher, string releaseDate, int pageCount, int circulation,string ISBN, string author)
        {
            Container container = new Container();

            Book book = new Book(name,type,publisher,DateTime.Parse(releaseDate),pageCount, circulation,ISBN,author);

            container.Add(book);
            TaskUtils register = new TaskUtils(container);

            Assert.AreEqual(container.Count, register.Count());
        }
    }
}