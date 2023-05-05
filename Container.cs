using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library
{
    public class Container
    {
        private Publication[] allPublications;
        private int Capacity;
        public int Count { get; set; }
        /// <summary>
        /// A constructor that creates an empty container that has 16 empty slots
        /// </summary>
        /// <param name="capacity">a container size integer</param>
        public Container(int capacity = 16)
        {
            this.Capacity = capacity;
            this.allPublications= new Publication[capacity];
        }
        /// <summary>
        /// A method that adds a Publication object to the end of a container
        /// </summary>
        /// <param name="publication">an object of the Publication class</param>
        public void Add(Publication publication)
        {
            if (this.Count == this.Capacity)
            {
                this.EnsureCapacity(this.Count * 2);
            }
            this.allPublications[this.Count++] = publication;
        }
        /// <summary>
        /// A method that returns an object from a container based on the given integer
        /// </summary>
        /// <param name="index">an integer that tells what object needs to be returned</param>
        /// <returns>returns an object from a container</returns>
        public Publication Get(int index)
        {
            return this.allPublications[index];
        }
        /// <summary>
        /// A method that ensures the needed capacity of a container
        /// </summary>
        /// <param name="minimumCapacity">an integer that tells the minimum needed capacity for a container</param>
        private void EnsureCapacity(int minimumCapacity)
        {
            if (this.Capacity < minimumCapacity)
            {
                Publication[] temp = new Publication[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.allPublications[i];
                }
                this.Capacity = minimumCapacity;
                this.allPublications = temp;
            }
        }
        /// <summary>
        /// A method that checks if a container contains the given Publication data
        /// </summary>
        /// <param name="publication">an object of the Publication class</param>
        /// <returns>either true or false depending on the value is in the container or not</returns>
        public bool Contains(Publication publication)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.allPublications[i].Equals(publication))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// A method that puts a Publication object into a container at the given integer's space
        /// </summary>
        /// <param name="publication">an object of the Publication class</param>
        /// <param name="index">an integer that tells where object needs to be put</param>
        public void Put(Publication publication, int index)
        {
            if (index >= 0 || index <= this.Count)
            {
                this.allPublications[index] = publication;
            }
        }
        /// <summary>
        /// A method that inserts a Publication object into a container at the given integer's space
        /// </summary>
        /// <param name="publication">an object of the Publication class</param>
        /// <param name="index">an integer that tells where object needs to be put</param>
        public void Insert(Publication publication, int index)
        {
            if (index >= 0 || index <= this.Count)
            {
                for (int i = this.Count; i > index; i--)
                {
                    this.allPublications[i] = this.allPublications[i - 1];
                }
                this.Count++;
                this.allPublications[index] = publication;

            }
        }
        /// <summary>
        /// A method that removes an object of the Publication class from a container
        /// </summary>
        /// <param name="publication">an object of the Publication class</param>
        public void Remove(Publication publication)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.allPublications[i] == publication)
                {
                    for (int j = i; j < this.Count - 1; j++)
                    {
                        this.allPublications[j] = this.allPublications[j + 1];
                    }
                    this.Count--;
                }
            }
        }
        /// <summary>
        /// A method that removes an object of the Publication class from a container at the specific index
        /// </summary>
        /// <param name="index">an integer that tells where object needs to be removed</param>
        public void RemoveAt(int index)
        {
            if (index >= 0 || index <= this.Count)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (i == index)
                    {
                        for (int j = i; j < this.Count - 1; j++)
                        {
                            this.allPublications[j] = this.allPublications[j + 1];
                        }
                        this.Count--;
                    }
                }
            }
        }
    }
}