using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureImplementation4CSharp.BaseADT
{
    public interface ADTListOpertion<T>
    {
        /// <summary>
        /// Inserts an element into this list at the given index
        /// </summary>
        /// <param name="element"></param>
        /// <param name="index"></param>
        public bool Insert(T element, int index);
        /// <summary>
        /// Adds an element to the end of the list
        /// </summary>
        /// <param name="element"></param>
        public bool Add(T element);
        /// <summary>
        /// Removes the first occurrence of an element from the List.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool Remove(T element);
        /// <summary>
        /// Removes the element at the given index of the List
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool RemoveAt(int index);
        /// <summary>
        /// Searches for the given element and returns the zero-based index of the first occurrence within the List,
        /// If it doesn't get anything results, return -1
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public int IndexOf(T element);
        /// <summary>
        /// Searchs for the element at the given index of list
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T FindKth(int index);
    }
}
