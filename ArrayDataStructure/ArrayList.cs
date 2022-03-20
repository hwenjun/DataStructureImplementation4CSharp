using DataStructureImplementation4CSharp.BaseADT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureImplementation4CSharp.ArrayDataStructure
{
    /// <summary>
    /// Implements Dynamic Generics ArrayList
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ArrayList<T> : ADTListOpertion<T>
    {
        #region Const Variables
        private const int INIT_ARR_CAPACITY = 10;
        private const int CAPACITY_INCREASE_STEP = 10;
        #endregion

        #region Priavate Fields

        private T[]? _fieldArr = null;

        private int _fieldLength = 0;
        #endregion

        #region Private Properties
        private T[] _arr
        {
            get => _fieldArr;
            set
            {
                if (value == null || value.Length == 0)
                {
                    if(ResizeCapacity(0, out T[] arr))
                        _fieldArr = arr;

                    return;
                }

                _fieldArr = value;
            }
        }

        private int _capacity => _arr.Length;

        private int _length
        {
            get => _fieldLength;
            set
            {
                if (value < 0 ||
                    value == _fieldLength) 
                    return;

                if (ResizeCapacity(value, out T[] suitableArr))
                    _arr = suitableArr;
                     
                _fieldLength = value;
            }
        }
        #endregion

        #region Public Propertie
        public int Capacity => _capacity;
        public int Length => _length;
        #endregion

        #region Private Methods

        /// <summary>
        /// Resize Capacity through the actual length(after elements will be changed)
        /// if it is necessary for this array to change its capcaity,
        /// then output a new array and return true;
        /// or output an original array and return false
        /// </summary>
        /// <param name="actualLengthAfterChange"></param>
        /// <returns></returns>
        private bool ResizeCapacity(int actualLengthAfterChange, out T[] suitableArr)
        {
            //Reduce Capacity
            if ((actualLengthAfterChange + CAPACITY_INCREASE_STEP) < _capacity)
            {
                suitableArr = new T[actualLengthAfterChange + CAPACITY_INCREASE_STEP];
                return true;
            }

            //Expand Capacity
            if(actualLengthAfterChange > _capacity)
            {
                suitableArr = new T[actualLengthAfterChange + CAPACITY_INCREASE_STEP];
                return true;
            }

            suitableArr = _arr;
            return false;
        }
        
        #endregion

        #region constructor
        /// <summary>
        /// Create Dynamic Generics ArrayList
        /// </summary>
        public ArrayList()
        {
            _arr = new T[INIT_ARR_CAPACITY];
        }

        /// <summary>
        /// Create Dynaic Generics ArrayList using array
        /// </summary>
        /// <param name="arr"></param>
        public ArrayList(T[] arr) 
        {
            _arr = arr;
        }
        #endregion

        #region Implements Methods
        /// <summary>
        /// Adds an element to the end of the list,
        /// if it is not successful, returns false
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool Add(T element)
        {
            //ToDo: Insert method must be private, and Private methods should not depend on global fields
            return Insert(element, -1);
        }

        /// <summary>
        /// Negative index is acceptable, Modeled after python
        /// if index is out of bounds, return default(T);
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T FindKth(int index)
        {
            int actualIndex = index >= 0 ? index : _length + index;
            if(actualIndex < 0 || actualIndex >= _length)
                return default(T);

            return _arr[actualIndex];
        }

        public int IndexOf(T element)
        {
            if (element == null)
                return -1;

            //ToDo: To be optimized -> binary search
            for (int index = 0; index < _length; index++)
            {
                if(element.Equals(_arr[index]))
                    return index;
            }

            return -1;
        }

        /// <summary>
        /// Negative index is acceptable, Modeled after python
        /// if index is out of bounds, return false
        /// </summary>
        /// <param name="element"></param>
        /// <param name="index"></param>
        public bool Insert(T element, int index)
        {
            int changedLength = _length + 1;
            int actualIndex = index >= 0 ? index : changedLength + index;
            if (actualIndex < 0 || actualIndex >= changedLength)
                return false;

            try
            {
                ResizeCapacity(changedLength, out T[] suitableArr);
                for (int newIndex = 0; newIndex < changedLength; newIndex++)
                {
                    if (newIndex < index)
                        suitableArr[newIndex] = _arr[newIndex];
                    else if (newIndex == index)
                        suitableArr[newIndex] = element;
                    else if (newIndex > index)
                        suitableArr[newIndex] = _arr[newIndex - 1];
                }
                _arr = suitableArr;
                _length++;
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool Remove(T element)
        {
            int searchIndex = -1;
            if ((searchIndex = IndexOf(element)) == -1)
                return false;

            return RemoveAt(searchIndex);
        }

        /// <summary>
        /// Negative index is acceptable, Modeled after python
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool RemoveAt(int index)
        {
            int actualIndex = index >= 0 ? index : _length + index;
            if (actualIndex < 0 || actualIndex >= _length)
                return false;

            try
            {
                ResizeCapacity(_length - 1, out T[] suitableArr);
                for (int newIndex = 0; newIndex < _length - 1; newIndex++)
                {
                    if (newIndex < index)
                        suitableArr[newIndex] = _arr[newIndex];
                    else
                        suitableArr[newIndex] = _arr[newIndex + 1];
                 }
                _arr = suitableArr;
                _length--;
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }
        #endregion
    }
}
