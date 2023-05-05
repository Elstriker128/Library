using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Reflection.Emit;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Library
{
    public class InOut
    {
        /// <summary>
        /// A method that reads data from a data file and puts it into a TaskUtils object
        /// </summary>
        /// <param name="filename">the name of the data file</param>
        /// <param name="validator">an object of the CustomValidator class</param>
        /// <returns>a TaskUtils object full of data from the data file</returns>
        public static TaskUtils ReadData(string filename, CustomValidator validator)
        {
            TaskUtils collection = new TaskUtils();

            string[] lines = File.ReadAllLines(filename,Encoding.UTF8);
            try
            {
                collection.LibraryName = lines[0];
                collection.Address= lines[1];
                collection.PhoneNumber= lines[2];
            
                foreach (string line in lines.Skip(3))
                {
                    string[] values = line.Split(';');
                    string name = values[0];
                    string type = values[1];
                    string publisher = values[2];
                    DateTime releaseDate = DateTime.Parse(values[3]);
                    int pageCount = int.Parse(values[4]);
                    int circulation = int.Parse(values[5]);
                    var unknown1 = values[6];
                    var unknown2 = values[7];
                    switch (unknown1[0])
                    {
                        case 'I':
                            if (!unknown2.All(char.IsNumber))
                            {
                                string ISBN_1 = unknown1;
                                string author = unknown2;
                                Book book = new Book(name, type, publisher, releaseDate, pageCount, circulation, ISBN_1, author);
                                collection.Add(book);
                                break;
                            }
                            else
                            {
                                string ISBN_2 = unknown1;
                                int number_1 = int.Parse(unknown2);
                                Journal journal = new Journal(name, type, publisher, releaseDate, pageCount, circulation, ISBN_2, number_1);
                                collection.Add(journal);
                                break;
                            }

                        default:
                            DateTime date = DateTime.Parse(unknown1);
                            int number_2 = int.Parse(unknown2);
                            Newspaper newspaper = new Newspaper(name, type, publisher, releaseDate, pageCount, circulation, date, number_2);
                            collection.Add(newspaper);
                            break;
                    }
                }
            }
            catch(ArgumentNullException)
            {
                validator.Visible = false;
                validator.ErrorMessage = $"{filename} duomenu faile truksta duomenu";
                validator.IsValid= false;
            }
            catch(IndexOutOfRangeException)
            {
                validator.Visible = false;
                validator.ErrorMessage = $"{filename} duomenys bandoma talpinti uz duomenu rinkinio ribu";
                validator.IsValid = false;
            }
            return collection;
        }
        /// <summary>
        /// A method that prints data from a TaskUtils object to a result file
        /// </summary>
        /// <param name="filename">the name of the result file</param>
        /// <param name="header">a string that describes what data is being printed</param>
        /// <param name="data">an object of the TaskUtils class</param>
        public static void PrintData(string filename, string header, TaskUtils data)
        {
            if(filename.EndsWith("csv"))
            {
                using (StreamWriter writer = new StreamWriter(filename, true, Encoding.UTF8))
                {
                    writer.WriteLine(data.LibraryName);
                    writer.WriteLine(data.Address);
                    writer.WriteLine(data.PhoneNumber);
                    writer.WriteLine(header);
                    writer.WriteLine(($"{"Pavadinimas",-20},{"Tipas",-10},{"Leidėjas",-14},{"Išleidimo data",-15},{"Puslapiu skaičius",-15},{"Tiražas",-15},{"Data",-8},{"Numeris",-10},{"ISBN",-10},{"Autorius",-25}"));

                    for (int i = 0; i < data.Count(); i++)
                    {
                        Publication current = data.ReturnIndexValue(i);
                        if (current is Journal)
                        {
                            Journal journal = (Journal)current;
                            writer.WriteLine(journal.ToString());
                        }
                        else if (current is Book)
                        {
                            Book book = (Book)current;
                            writer.WriteLine(book.ToString());
                        }
                        else
                        {
                            Newspaper newspaper = (Newspaper)current;
                            writer.WriteLine(newspaper.ToString());
                        }
                    }

                    writer.WriteLine();
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(filename, true, Encoding.UTF8))
                {
                    writer.WriteLine(new string('-',190));
                    writer.WriteLine(data.LibraryName);
                    writer.WriteLine(data.Address);
                    writer.WriteLine(data.PhoneNumber);
                    writer.WriteLine(new string('-', 190));
                    writer.WriteLine(header);
                    writer.WriteLine(new string('-', 190));
                    writer.WriteLine(($"| {"Pavadinimas",-20} | {"Tipas",-14} | {"Leidėjas",-14} | {"Išleidimo data",-15} | {"Puslapiu skaičius",-20} | {"Tiražas",-15} | {"Data",-12} | {"Numeris",-10} | {"ISBN",-12} | {"Autorius",-20} |"));
                    writer.WriteLine(new string('-', 190));
                    for (int i = 0; i < data.Count(); i++)
                    {
                        Publication current = data.ReturnIndexValue(i);
                        if (current is Journal)
                        {
                            Journal journal = (Journal)current;
                            writer.WriteLine(String.Format($"| {journal.Name,-20} | {journal.Type,-14} | {journal.Publisher,-14} | {journal.ReleaseDate.ToString("MM/dd/yyyy"),-15} | {journal.PageCount,20} | {journal.Circulation,15} | {null,-12} | {journal.Number,10} | {journal.ISBN,-12} | {null,-20} |"));
                        }
                        else if (current is Book)
                        {
                            Book book = (Book)current;
                            writer.WriteLine(String.Format($"| {book.Name,-20} | {book.Type,-14} | {book.Publisher,-14} | {book.ReleaseDate.ToString("MM/dd/yyyy"),-15} | {book.PageCount,20} | {book.Circulation,15} | {null,-12} | {null,10} | {book.ISBN,12} | {book.Author,-20} |"));
                        }
                        else
                        {
                            Newspaper newspaper = (Newspaper)current;
                            writer.WriteLine(String.Format($"| {newspaper.Name,-20} | {newspaper.Type,-14} | {newspaper.Publisher,-14} | {newspaper.ReleaseDate.ToString("MM/dd/yyyy"),-15} | {newspaper.PageCount,20} | {newspaper.Circulation,15} | {newspaper.Date.ToString("MM/dd/yyyy"),12} | {newspaper.Number,10} | {null,-12} | {null,-20} |"));
                        }
                    }
                    writer.WriteLine(new string('-', 190));
                    writer.WriteLine();
                }
            }
        }
        /// <summary>
        /// A method that prints popular publication data from a TaskUtils object to a result file
        /// </summary>
        /// <param name="filename">the name of the result file</param>
        /// <param name="header">a string that describes what data is being printed</param>
        /// <param name="data">an object of the TaskUtils class</param>
        public static void PrintPopular(string filename, string header, TaskUtils data)
        {
            if (filename.EndsWith("csv"))
            {
                using (StreamWriter writer = new StreamWriter(filename, true, Encoding.UTF8))
                {
                    writer.WriteLine(header);
                    writer.WriteLine(($"{"Pavadinimas",-20},{"Tiražas",-15}"));

                    for (int i = 0; i < data.Count(); i++)
                    {
                        Publication current = data.ReturnIndexValue(i);
                        if (current is Journal)
                        {
                            Journal journal = (Journal)current;
                            writer.WriteLine(String.Format($"{journal.Name,-20},{journal.Circulation,15}"));
                        }
                        else if (current is Book)
                        {
                            Book book = (Book)current;
                            writer.WriteLine(String.Format($"{book.Name,-20},{book.Circulation,15}"));
                        }
                        else
                        {
                            Newspaper newspaper = (Newspaper)current;
                            writer.WriteLine(String.Format($"{newspaper.Name,-20},{newspaper.Circulation,15}"));
                        }
                    }

                    writer.WriteLine();
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(filename, true, Encoding.UTF8))
                {
                    writer.WriteLine(new string('-', 50));
                    writer.WriteLine(data.LibraryName);
                    writer.WriteLine(data.Address);
                    writer.WriteLine(data.PhoneNumber);
                    writer.WriteLine(new string('-', 50));
                    writer.WriteLine(header);
                    writer.WriteLine(new string('-', 50));
                    writer.WriteLine(($"| {"Pavadinimas",-20} | {"Tiražas",-15} |"));
                    writer.WriteLine(new string('-', 50));
                    for (int i = 0; i < data.Count(); i++)
                    {
                        Publication current = data.ReturnIndexValue(i);
                        if (current is Journal)
                        {
                            Journal journal = (Journal)current;
                            writer.WriteLine(String.Format($"| {journal.Name,-20} | {journal.Circulation,15} |"));
                        }
                        else if (current is Book)
                        {
                            Book book = (Book)current;
                            writer.WriteLine(String.Format($"| {book.Name,-20} | {book.Circulation,15} |"));
                        }
                        else
                        {
                            Newspaper newspaper = (Newspaper)current;
                            writer.WriteLine(String.Format($"| {newspaper.Name,-20} | {newspaper.Circulation,15} |"));
                        }
                    }
                    writer.WriteLine(new string('-', 50));
                    writer.WriteLine();
                }
            }
        }
    }
}