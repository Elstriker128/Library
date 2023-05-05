using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;

namespace Library.Tests
{
    [TestClass()]
    public class ReturnIndexValueTests
    {
        [DataTestMethod()]
        [DataRow("Harry Potter", "fantasy", "Allma Littera", "2010-10-07", 350, 1000000, "ISBN-466799", "J.K. Rowling", 0)]
        [DataRow("Public library", "comedy", "Allma Littera", "2009-11-20", 200, 50000, "ISBN-555333", "Anonymous", 0)]
        [DataRow("Vincas Kudirka's biography", "historical", "Obuolys", "2010-07-25", 150, 10000, "ISBN-379155", "Kazys Grinius", 0)]
        public void ReturnIndexValue_CheckIfReturnsRightValue_True(string name, string type, string publisher, string releaseDate, int pageCount, int circulation, string ISBN, string author, int index)
        {
            TaskUtils register = new TaskUtils();

            Book book = new Book(name, type, publisher, DateTime.Parse(releaseDate), pageCount, circulation, ISBN, author);

            register.Add(book);

            Publication current = register.ReturnIndexValue(index);

            Assert.AreEqual(current,book);
        }
    }
}
