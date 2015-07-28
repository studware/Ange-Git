namespace T5and6GenericClass
{
using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;   
    public class GenericList<T>
        where T: IComparable
    {
//       const int DefaultCapacity = 4096;   //  just an optimal choice for the disk I/O system: the length of bytes in the HDD sectors 
//                                           //  (assume newer HDDs - they use 4096-byte (4K) sectors, known as the Advanced Format (AF)

        //  fields
        private T[] listElements;
        private static readonly int InitCapacity = 4;
        private int count=0;

        //  constructors
        public GenericList (int capacity )
        {
            listElements = new T[capacity];
        }

        public GenericList()
            : this(InitCapacity)
        {
        }

        //  properties
        public int Capacity
        {
            get
            {
                return (int)this.listElements.Length;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The capacity must be positive!");
                }
                else if (value < count)
                {
                    throw new ArgumentOutOfRangeException("The capacity must be larger than the current last element position!");
                }
                else
                {
                    T[] newArr = new T[value];
                    if (count > 0)
                    {
                        Array.Copy(this.listElements, newArr, this.count);
                    }
                    this.listElements = newArr;
                }
            }
        }

        public int Count
        {
            get 
            { 
                return this.count; 
            }
        }

        public T this[int index]    //  indexer
        {
            get
            {
                if (index < 0 || index > this.count)
                {
                    throw new IndexOutOfRangeException(
                        String.Format("Invalid index: {0}", index));
                }
                return this.listElements[index];
            }
            set
            {
                if (index < 0 || index > this.count)
                {
                    throw new IndexOutOfRangeException(
                        String.Format("Invalid index: {0}", index));
                }
                this.listElements[index] = value;
            }
        }

        //  methods
        public void AddElement(T newElement) 
        {
            this.InsertElement(count, newElement);
        }

        public void InsertElement(int index, T newElement) 
        {
            if (index < 0 || index > count)
            {
                throw new IndexOutOfRangeException("Invalid index: " + index);                
            }
            else
            {
                if (this.count >= this.Capacity)
                {
                    Capacity = 2*Capacity;                    
                }
                T[] newArray=new T[Capacity];
                Array.Copy(listElements, newArray, index);
                Array.Copy(listElements, index, newArray, index + 1, count - index);
                newArray[index] = newElement;
                this.listElements = newArray;
                this.count++;
            }        
        }

        public T RemoveElement(int index)
        {
            if (index < 0 || index > count)
            {

                throw new IndexOutOfRangeException("Invalid index: " + index);
            }
            else
            {
                T elemToRemove = listElements[index];
                T[] newArray = new T[Capacity];
                Array.Copy(listElements, newArray, index);
                Array.Copy(listElements, index + 1, newArray, index, count - index + 1);
                this.listElements = newArray;
                this.count--;
                return elemToRemove;
            }
        }

        public void Clear()
        {
            listElements = new T[InitCapacity];
            count = 0;
        }

        public int IndexOf(T elemToFind)
        {
            for (int i = 0; i < listElements.Length; i++)
            {
                if (elemToFind.Equals(listElements[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public T Min()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Empty sequence!");
            }
            else
            {
                return listElements.Min();
            }
        }

        public T Max()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Empty sequence!");
            }
            else
            {
                T[] workArray = new T[count];
                Array.Copy(listElements, workArray, count);
                return listElements.OrderByDescending(x => x).First();
            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                str.Append(String.Format("{0}, ", listElements[i].ToString()));
            }
            str.Remove(str.Length - 2, 2);
            return str.ToString();
        }
    }
}
