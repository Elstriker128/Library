using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace Library
{
    public class Journal : Publication, IEquatable<Journal>
    {
        public string ISBN { get; private set; }
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
        /// <param name="iSBN">the ISBN of the publication</param>
        /// <param name="number">the number of the publication</param>
        public Journal(string name, string type, string publisher, DateTime releaseDate, int pageCount, int circulation, string iSBN, int number) : base(name, type, publisher, releaseDate, pageCount, circulation)
        {
            this.ISBN = iSBN;
            this.Number = number;
        }
        /// <summary>
        /// An overriden CompareTo method to compare two objects
        /// </summary>
        /// <param name="other">an object of the base object class</param>
        /// <returns>an integer depending on the comparison results</returns>
        public override int CompareTo(object other)
        {
            if (other is Journal)
            {
                if ((object)other == null)
                    return 0;

                if (this.ReleaseDate.Year.CompareTo((other as Journal).ReleaseDate.Year) != 0)
                {
                    return this.ReleaseDate.Year.CompareTo((other as Journal).ReleaseDate.Year);
                }
                else
                {
                    return this.ReleaseDate.Month.CompareTo((other as Journal).ReleaseDate.Month);
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
        /// <param name="other">an object of the Journal class</param>
        /// <returns>either true or false depending on if the the two values are the same or not</returns>
        public bool Equals(Journal other)
        {
            if ((object)other == null)
                return false;
            if (this.Name == other.Name && this.ISBN == other.ISBN && this.Number == other.Number)
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
            Journal perObj = obj as Journal;
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
            int hashCode = -2037337563;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ISBN);
            hashCode = hashCode * -1521134295 + Number.GetHashCode();
            return hashCode;
        }
        /// <summary>
        /// An overriden ToString method used to format the objects data in a needed placement
        /// </summary>
        /// <returns>a formatted string</returns>
        public override string ToString()
        {
            return String.Format($"{this.Name,-20},{this.Type,-10},{this.Publisher,-14},{this.ReleaseDate.ToString("MM/dd/yyyy"),-15},{this.PageCount,15},{this.Circulation,15},{"No value",-8},{this.Number,10},{this.ISBN,-10},{"No value",-15}");
        }
    }
}