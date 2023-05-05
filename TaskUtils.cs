using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library
{
    public class TaskUtils
    {
        private Container allPublications;
        public string LibraryName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        /// <summary>
        /// A constructor to create an empty container 
        /// </summary>
        public TaskUtils() 
        {
            this.allPublications = new Container();
        }
        /// <summary>
        /// A constructor that creates a new container from another container
        /// </summary>
        /// <param name="allPublicationals"></param>
        public TaskUtils(Container allPublicationals) : this()
        {
            for (int i = 0; i < allPublicationals.Count; i++)
            {
                this.allPublications.Add(allPublicationals.Get(i));
            }
        }
        /// <summary>
        /// A method that adds a Publication object at the end of a container
        /// </summary>
        /// <param name="publication"></param>
        public void Add(Publication publication)
        {
            this.allPublications.Add(publication);
        }
        /// <summary>
        /// A method that returns the amount of objects there are in a container
        /// </summary>
        /// <returns>the amount of objects there are in a container</returns>
        public int Count()
        {
            return this.allPublications.Count;
        }
        /// <summary>
        /// A method that returns a Publication object from a container based on the given index
        /// </summary>
        /// <param name="index">an integer that tells what object needs to be returned</param>
        /// <returns>a Publication object from a container</returns>
        public Publication ReturnIndexValue(int index)
        {
            return this.allPublications.Get(index);
        }
        /// <summary>
        ///  A method that checks if a container contains the given Publication data
        /// </summary>
        /// <param name="Info">an object of the Publication class</param>
        /// <returns>either true or false depending on the value is in the container or not</returns>
        public bool Contains(Publication Info)
        {
            return this.allPublications.Contains(Info);
        }
        /// <summary>
        /// A method that checks how many publications in a container are older than two years
        /// </summary>
        /// <returns>the amount of publications in a container are older than two years</returns>
        public int CountHowMany2YearOldCreations()
        {
            int count = 0;
            for(int i = 0; i<this.Count(); i++)
            {
                Publication current = this.ReturnIndexValue(i);
                TimeSpan subtraction = DateTime.Now.Subtract(current.ReleaseDate);
                if (subtraction.Days > 730)
                {
                    count++;
                }
            }
            return count;
        }
        /// <summary>
        /// A method that adds elements to a container if their type is "mokslinis"
        /// </summary>
        /// <param name="filtered">an object of the TaskUtils class</param>
        public void AddWhichAreScientific(ref TaskUtils filtered)
        {
            for(int i = 0; i<this.Count();i++)
            {
                Publication current = this.ReturnIndexValue(i);
                if (current.Type.Equals("mokslinis"))
                {
                    filtered.Add(current);
                }
            }
        }
        /// <summary>
        /// A method that adds elements to a container if their circulation is above 10000
        /// </summary>
        /// <param name="filtered">an object of the TaskUtils class</param>
        public void AddWhichAreOver10000(ref TaskUtils filtered)
        {
            for (int i = 0; i < this.Count(); i++)
            {
                Publication current = this.ReturnIndexValue(i);
                if (current.Circulation>10000)
                {
                    filtered.Add(current);
                }
            }
        }
        /// <summary>
        /// A method that adds elements to a container if they're old
        /// </summary>
        /// <param name="filtered">an object of the TaskUtils class</param>
        public void AddOldPublishes(ref TaskUtils filtered)
        {
            for (int i = 0; i < this.Count(); i++)
            {
                Publication current = this.ReturnIndexValue(i);
                if(current is Book)
                {
                    TimeSpan subtraction = DateTime.Now.Subtract(current.ReleaseDate);
                    if (subtraction.Days>365)
                    {
                        filtered.Add(current);
                    }
                }
                else if(current is Journal)
                {
                    TimeSpan subtraction = DateTime.Now.Subtract(current.ReleaseDate);
                    if (subtraction.Days > 30)
                    {
                        filtered.Add(current);
                    }
                }
                else
                {
                    TimeSpan subtraction = DateTime.Now.Subtract(current.ReleaseDate);
                    if (subtraction.Days > 7)
                    {
                        filtered.Add(current);
                    }
                }
            }
        }
        /// <summary>
        /// A method that sorts elements in a container based on the overriden CompareTo methods
        /// </summary>
        public void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < allPublications.Count - 1; i++)
                {
                    Publication a = allPublications.Get(i);
                    Publication b = allPublications.Get(i + 1);
                    if (a.CompareTo(b) > 0)
                    {
                        allPublications.Put(b, i);
                        allPublications.Put(a, i + 1);
                        flag = true;
                    }
                }
            }
        }
    }
}