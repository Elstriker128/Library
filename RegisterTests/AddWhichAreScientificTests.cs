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
    public class AddWhichAreScientificTests
    {
        [DataTestMethod()]
        [DataRow("Harry Potter", "fantasy", "Allma Littera", "2010-10-07", 350, 1000000, "ISBN-466799", "J.K. Rowling", 1)]
        [DataRow("Public library", "comedy", "Allma Littera", "2009-11-20", 200, 50000, "ISBN-555333", "Anonymous", 1)]
        [DataRow("Vincas Kudirka's biography", "mokslinis", "Obuolys", "2010-07-25", 150, 10000, "ISBN-379155", "Kazys Grinius", 2)]
        public void AddWhichAreScientific_CheckIfCountAfterMethodIsRight_True(string name, string type, string publisher, string releaseDate, int pageCount, int circulation, string ISBN, string author, int count)
        {
            TaskUtils register = new TaskUtils();
            TaskUtils filtered = new TaskUtils();
            Book book = new Book(name, type, publisher, DateTime.Parse(releaseDate), pageCount, circulation, ISBN, author);
            Journal journal = new Journal("15min", "mokslinis", "15min", DateTime.Parse("2023-02-09"), 15, 2000, "ISBN-222333", 2);

            register.Add(book);
            register.Add(journal);
            register.AddWhichAreScientific(ref filtered);

            Assert.AreEqual(count,filtered.Count());
        }
    }
}
