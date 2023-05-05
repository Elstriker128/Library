using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library
{
    public class Newspaper : Publication, IEquatable<Newspaper>
    {
        public DateTime Date { get; private set; }
        public int Number { get; private set; }
        /// <summary>
        /// A constructor for an abstract Publication object
        /// </summary>
        /// <param name="name">the name of the publication</param>
        /// <param name="type">the type of the publication</param>
        /// <param name="publisher">the publisher of the publication</param>
        /// <param name="releaseDate">the release date of the publication</param>
        /// <param name="pageCount">the page count of the publication</param>
        /// <param name="circulation">the circulation of the publication</param>
        /// <param name="date">the written date of the publication</param>
        /// <param name="number">the number of the publication</param>
        public Newspaper(string name, string type, string publisher, DateTime releaseDate, int pageCount, int circulation, DateTime date, int number) : base(name, type, publisher, releaseDate, pageCount, circulation)
        {
            this.Date = date;
            this.Number = number;
        }
        /// <summary>
        /// An overriden CompareTo method to compare two objects
        /// </summary>
        /// <param name="other">an object of the base object class</param>
        /// <returns>an integer depending on the comparison results</returns>
        public override int CompareTo(object other)
        {
            if (other is Newspaper)
            {
                if ((object)other == null)
                    return 0;

                if (this.ReleaseDate.Year.CompareTo((other as Newspaper).ReleaseDate.Year) != 0)
                {
                    return this.ReleaseDate.Year.CompareTo((other as Newspaper).ReleaseDate.Year);
                }
                else if(this.ReleaseDate.Month.CompareTo((other as Newspaper).ReleaseDate.Month) != 0)
                {
                    return this.ReleaseDate.Month.CompareTo((other as Newspaper).ReleaseDate.Month);
                }
                else
                {
                    return this.ReleaseDate.Day.CompareTo((other as Newspaper).ReleaseDate.Day);
                }
            }
            else
            {
                if ((object)other == null)
                    return 0;

                if (this.ReleaseDate.Year.CompareTo((other as Publication).ReleaseDate.Year) != 0)
                {
                    return this.ReleaseDate.Year.CompareTo((other as Publication).ReleaseDate.Year);
                }
            }
            return 0;
        }
        /// <summary>
        /// An Equals method to realise the IEquatable interface
        /// </summary>
        /// <param name="other">an object of the Newspaper class</param>
        /// <returns>either true or false depending on if the the two values are the same or not</returns>
        public bool Equals(Newspaper other)
        {
            if ((object)other == null)
                return false;
            if (this.Name == other.Name && this.Date == other.Date && this.Publisher == other.Publisher)
                return true;
            else
                return false;
        }
        /// <summary>
        /// An overriden Equals method that uses the IEquatable interface implementation to check if the values are equal
        /// </summary>
        /// <param name="obj">an object of the base object class</param>
        /// <returns>either true or false depending on if the the two values are the same or not</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Newspaper perObj = obj as Newspaper;
            if (perObj == null)
                return false;
            else
                return Equals(perObj);
        }
        /// <summary>
        /// An overriden GetHashCode method used for checking two object similarities
        /// </summary>
        /// <returns>an integer which depends on if the the two values are the same or not</returns>
        public override int GetHashCode()
        {
            int hashCode = -1664145972;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Publisher);
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            return hashCode;
        }
        /// <summary>
        /// An overriden ToString method used to format the objects data in a needed placement
        /// </summary>
        /// <returns>a formatted string</returns>
        public override string ToString()
        {
            return String.Format($"{this.Name,-20},{this.Type,-10},{this.Publisher,-14},{this.ReleaseDate.ToString("MM/dd/yyyy"),-15},{this.PageCount,15},{this.Circulation,15},{this.Date.ToString("MM/dd/yyyy"),8},{this.Number,10},{"No value",-10},{"No value",-25}");
        }
    }
}