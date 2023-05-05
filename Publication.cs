using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library
{
    public abstract class Publication : IComparable<object>, IEquatable<Publication>
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public string Publisher { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public int PageCount { get; private set; }
        public int Circulation { get; private set; }
        /// <summary>
        /// A constructor for an abstract Publication object
        /// </summary>
        /// <param name="name">the name of the publication</param>
        /// <param name="type">the type of the publication</param>
        /// <param name="publisher">the publisher of the publication</param>
        /// <param name="releaseDate">the release date of the publication</param>
        /// <param name="pageCount">the page count of the publication</param>
        /// <param name="circulation">the circulation of the publication</param>
        public Publication(string name, string type, string publisher, DateTime releaseDate, int pageCount, int circulation)
        {
            Name = name;
            Type = type;
            Publisher = publisher;
            ReleaseDate = releaseDate;
            PageCount = pageCount;
            Circulation = circulation;
        }
        /// <summary>
        /// A virtual CompareTo method to compare two objects
        /// </summary>
        /// <param name="other">an object of the base object class</param>
        /// <returns>an integer depending on the comparison results</returns>
        public virtual int CompareTo(object other)
        {
            return 0;
        }
        /// <summary>
        /// An Equals method to realise the IEquatable interface
        /// </summary>
        /// <param name="other">an object of the Publication class</param>
        /// <returns>either true or false depending on if the the two values are the same or not</returns>
        public bool Equals(Publication other)
        {
            if ((object)other == null)
                return false;
            if (this.Name == other.Name && this.Type == other.Type && this.Publisher == other.Publisher)
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
            Publication perObj = obj as Publication;
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
            int hashCode = -2145180166;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Type);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Publisher);
            return hashCode;
        }
    }
}