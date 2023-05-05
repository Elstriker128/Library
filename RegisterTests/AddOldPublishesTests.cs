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
    public class AddOldPublishesTests
    {
        [DataTestMethod()]
        [DataRow("Harry Potter", "fantasy", "Allma Littera", "2010-10-07", 350, 1000000, "ISBN-466799", "J.K. Rowling", 3)]
        [DataRow("Public library", "comedy", "Allma Littera", "2009-11-20", 200, 50000, "ISBN-555333", "Anonymous", 3)]
        [DataRow("Vincas Kudirka's biography", "historical", "Obuolys", "2023-07-25", 150, 10000, "ISBN-379155", "Kazys Grinius", 2)]
        public void AddOldPublishes_CheckIfCountAfterMethodIsRight_True(string name, string type, string publisher, string releaseDate, int pageCount, int circulation, string ISBN, string author, int count)
        {
            TaskUtils register = new TaskUtils();
            TaskUtils filtered = new TaskUtils();

            Book book = new Book(name, type, publisher, DateTime.Parse(releaseDate), pageCount, circulation, ISBN, author);
            Journal journal = new Journal("15min", "scientific", "15min", DateTime.Parse("2023-02-09"), 15, 2000, "ISBN-222333", 2);
            Newspaper newspaper = new Newspaper("New York Times", "scientific", "New York Times", DateTime.Parse("2022-02-09"), 30, 5000, DateTime.Parse("2022-02-09"), 3);

            register.Add(book);
            register.Add(journal);
            register.Add(newspaper);

            register.AddOldPublishes(ref filtered);

            Assert.AreEqual(count, filtered.Count());
        }
    }
}
