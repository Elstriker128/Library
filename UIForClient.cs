using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Library
{
    public partial class UIForClient : System.Web.UI.Page
    {
        /// <summary>
        /// A method that inserts publication data into a PlaceHolder
        /// </summary>
        /// <param name="header">a string that describes what data is being printed</param>
        /// <param name="placeHolder">an object of the PlaceHolder class</param>
        /// <param name="publications">an object of the TaskUtils class</param>
        private void InsertPublicationData(string header, PlaceHolder placeHolder, TaskUtils publications)
        {
            Table required = new Table();
            required.GridLines = GridLines.Both;
            required.BorderColor = Color.Black;
            TableRow prow = new TableRow();

            TableCell called = new TableCell();
            called.Text = header;
            called.ColumnSpan = 10;
            prow.Cells.Add(called);
            required.Rows.Add(prow);
           
            TableRow frow = new TableRow();

            TableCell fname = new TableCell();
            fname.Text = "Pavadinimas";

            TableCell ftype = new TableCell();
            ftype.Text = "Tipas";

            TableCell fpublisher = new TableCell();
            fpublisher.Text = "Leidėjas";

            TableCell fdate = new TableCell();
            fdate.Text = "Išleidimo data";

            TableCell fpages = new TableCell();
            fpages.Text = "Puslapių skaičius";

            TableCell fcirculation = new TableCell();
            fcirculation.Text = "Tiražas";

            TableCell fanotherDate = new TableCell();
            fanotherDate.Text = "Data";

            TableCell fnumber = new TableCell();
            fnumber.Text = "Numeris";

            TableCell fISBN = new TableCell();
            fISBN.Text = "ISBN";

            TableCell fauthor = new TableCell();
            fauthor.Text = "Autorius";


            frow.Cells.Add(fname);
            frow.Cells.Add(ftype);
            frow.Cells.Add(fpublisher);
            frow.Cells.Add(fdate);
            frow.Cells.Add(fpages);
            frow.Cells.Add(fcirculation);
            frow.Cells.Add(fanotherDate);
            frow.Cells.Add(fnumber);
            frow.Cells.Add(fISBN);
            frow.Cells.Add(fauthor);

            required.Rows.Add(frow);

            for (int i = 0; i < publications.Count(); i++)
            {
                Publication current = publications.ReturnIndexValue(i);

                TableRow row = new TableRow();

                if (current is Book)
                {
                    TableCell name = new TableCell();
                    name.Text = current.Name;

                    TableCell type = new TableCell();
                    type.Text = current.Type;

                    TableCell publisher = new TableCell();
                    publisher.Text = current.Publisher;

                    TableCell date = new TableCell();
                    date.Text = current.ReleaseDate.ToString("MM/dd/yyyy");

                    TableCell pages = new TableCell();
                    pages.Text = current.PageCount.ToString();

                    TableCell circulation = new TableCell();
                    circulation.Text = current.Circulation.ToString();

                    TableCell anotherDate = new TableCell();

                    TableCell number = new TableCell();

                    TableCell ISBN = new TableCell();
                    ISBN.Text = (current as Book).ISBN;

                    TableCell author = new TableCell();
                    author.Text = (current as Book).Author;

                    row.Cells.Add(name);
                    row.Cells.Add(type);
                    row.Cells.Add(publisher);
                    row.Cells.Add(date);
                    row.Cells.Add(pages);
                    row.Cells.Add(circulation);
                    row.Cells.Add(anotherDate);
                    row.Cells.Add(number);
                    row.Cells.Add(ISBN);
                    row.Cells.Add(author);
                }
                else if (current is Newspaper)
                {
                    TableCell name = new TableCell();
                    name.Text = current.Name;

                    TableCell type = new TableCell();
                    type.Text = current.Type;

                    TableCell publisher = new TableCell();
                    publisher.Text = current.Publisher;

                    TableCell date = new TableCell();
                    date.Text = current.ReleaseDate.ToString("MM/dd/yyyy");

                    TableCell pages = new TableCell();
                    pages.Text = current.PageCount.ToString();

                    TableCell circulation = new TableCell();
                    circulation.Text = current.Circulation.ToString();

                    TableCell anotherDate = new TableCell();
                    anotherDate.Text = (current as Newspaper).Date.ToString("MM/dd/yyyy");

                    TableCell number = new TableCell();
                    number.Text = (current as Newspaper).Number.ToString();

                    TableCell ISBN = new TableCell();

                    TableCell author = new TableCell();

                    row.Cells.Add(name);
                    row.Cells.Add(type);
                    row.Cells.Add(publisher);
                    row.Cells.Add(date);
                    row.Cells.Add(pages);
                    row.Cells.Add(circulation);
                    row.Cells.Add(anotherDate);
                    row.Cells.Add(number);
                    row.Cells.Add(ISBN);
                    row.Cells.Add(author);
                }
                else
                {
                    TableCell name = new TableCell();
                    name.Text = current.Name;

                    TableCell type = new TableCell();
                    type.Text = current.Type;

                    TableCell publisher = new TableCell();
                    publisher.Text = current.Publisher;

                    TableCell date = new TableCell();
                    date.Text = current.ReleaseDate.ToString("MM/dd/yyyy");

                    TableCell pages = new TableCell();
                    pages.Text = current.PageCount.ToString();

                    TableCell circulation = new TableCell();
                    circulation.Text = current.Circulation.ToString();

                    TableCell anotherDate = new TableCell();

                    TableCell number = new TableCell();
                    number.Text = (current as Journal).Number.ToString();

                    TableCell ISBN = new TableCell();
                    ISBN.Text = (current as Journal).ISBN;

                    TableCell author = new TableCell();

                    row.Cells.Add(name);
                    row.Cells.Add(type);
                    row.Cells.Add(publisher);
                    row.Cells.Add(date);
                    row.Cells.Add(pages);
                    row.Cells.Add(circulation);
                    row.Cells.Add(anotherDate);
                    row.Cells.Add(number);
                    row.Cells.Add(ISBN);
                    row.Cells.Add(author);
                }

                required.Rows.Add(row);
                placeHolder.Controls.Add(required);
            }
        }
        /// <summary>
        /// A method that inserts only the appropiate header for the PlaceHolder
        /// </summary>
        /// <param name="header">a string that describes what data is being printed</param>
        /// <param name="placeHolder">an object of the PlaceHolder class</param>
        private void Insert2FormatDataNaming(string header, PlaceHolder placeHolder)
        {
            Table required = new Table();
            required.GridLines = GridLines.Both;
            required.BorderColor = Color.Black;
            TableRow prow = new TableRow();

            TableCell called = new TableCell();
            called.Text = header;
            called.ColumnSpan = 10;
            prow.Cells.Add(called);
            required.Rows.Add(prow);
            placeHolder.Controls.Add(required);
        }
        /// <summary>
        /// A method that inserts data into a placeholder that only consists of two data fields, one of which is 
        /// the amount of publications that are over 2 years old in a library
        /// </summary>
        /// <param name="header">a string that describes what data is being printed</param>
        /// <param name="placeHolder">an object of the PlaceHolder class</param>
        /// <param name="publications">an object of the TaskUtils class</param>
        /// <param name="amount">the amount of publications that are over 2 years old in a library </param>
        private void Insert2FormatData(string header, PlaceHolder placeHolder, TaskUtils publications, int amount)
        {
            Table required = new Table();
            required.GridLines = GridLines.Both;
            required.BorderColor = Color.Black;

            TableRow row = new TableRow();

            TableCell fname = new TableCell();
            fname.Text = publications.LibraryName;

            TableCell famount = new TableCell();
            famount.Text = amount.ToString();

            row.Cells.Add(fname);
            row.Cells.Add(famount);
            required.Rows.Add(row);
            placeHolder.Controls.Add(required);
        }
        /// <summary>
        /// A method that inserts data into a placeholder that only consists of two data fields
        /// </summary>
        /// <param name="header">a string that describes what data is being printed</param>
        /// <param name="placeHolder">an object of the PlaceHolder class</param>
        /// <param name="publications">an object of the TaskUtils class</param>
        private void Insert2FormatData(string header, PlaceHolder placeHolder, TaskUtils publications)
        {
            Table required = new Table();
            required.GridLines = GridLines.Both;
            required.BorderColor = Color.Black;

            for(int i=0; i<publications.Count();i++)
            {
                Publication current = publications.ReturnIndexValue(i);
                TableRow row = new TableRow();

                TableCell fname = new TableCell();
                fname.Text = current.Name;

                TableCell famount = new TableCell();
                famount.Text = current.Circulation.ToString();

                row.Cells.Add(fname);
                row.Cells.Add(famount);
                required.Rows.Add(row);
                placeHolder.Controls.Add(required);
            }
        }
        /// <summary>
        /// A method that activates when Button2 is clicked and it deletes all the data from the UI
        /// </summary>
        /// <param name="sender">an object of the base object class</param>
        /// <param name="e">an object of the EventArgs class</param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = string.Empty;
            PlaceHolder1.Controls.Clear();
            PlaceHolder2.Controls.Clear();
            PlaceHolder3.Controls.Clear();
            PlaceHolder4.Controls.Clear();
            PlaceHolder5.Controls.Clear();
            PlaceHolder6.Controls.Clear();
            PlaceHolder7.Controls.Clear();
            PlaceHolder8.Controls.Clear();
            PlaceHolder9.Controls.Clear();
            PlaceHolder10.Controls.Clear();
        }
    }
}