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
    public class SortTests
    {
        [TestMethod()]
        public void Sort_CheckIfSortedCorrectly_True()
        {
            TaskUtils register = new TaskUtils();
            
            Book book1 = new Book("Harry Potter", "fantasy", "Allma Littera", DateTime.Parse("2010-10-07"), 350, 1000000, "ISBN-466799", "J.K. Rowling");
            Book book2 = new Book("Public library", "comedy", "Allma Littera", DateTime.Parse("2009-11-20"), 200, 50000, "ISBN-555333", "Anonymous");
            Book book3 = new Book("Vincas Kudirka's biography", "historical", "Obuolys", DateTime.Parse("2023-07-25"), 150, 10000, "ISBN-379155", "Kazys Grinius");

            register.Add(book1);
            register.Add(book2);
            register.Add(book3);

            register.Sort();

            Assert.AreEqual(book1, register.ReturnIndexValue(1));
            Assert.AreEqual(book2, register.ReturnIndexValue(0));
            Assert.AreEqual(book3, register.ReturnIndexValue(2));
        }
    }
}
