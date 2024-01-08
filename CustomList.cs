using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_CustomList_MeiliZheng
{
    public class CustomList<T>
    {
        private T[] fruits;
        private int count;

        public CustomList() : this(15) { }

        public CustomList(int initialSize) 
        {
            fruits = new T[initialSize];
        }

        public int Count => count;

        public void Add(T item)
        {
            CheckIntegrity();
            fruits[count++] = item;
        }
        public void AddAtIndex (T item, int index)
        {
            CheckIntegrity();
            if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            for (int i = count; i > index; i--)
            {
                fruits[i] = fruits[i-1];
            }

            fruits[index] = item;
            count++;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (fruits[i].Equals(item))
                {
                    for(int j = i; j < count-1; j++)
                    {
                        fruits[j] = fruits[j+1];
                    }
                    count--;
                    return true;
                }
            }
            return false; ;
        }

        private void CheckIntegrity()
        {
            if(count > 0.8 * fruits.Length)
            {
                T[] largerArray = new T[fruits.Length * 2];
                Array.Copy(fruits, largerArray, count);
                fruits = largerArray;
            }
        }

        public T GetItem(int index)
        {
            if (index < 0 || index > count)
            {
                throw new AbandonedMutexException(nameof(index));
            }

            return fruits[index];
        }

        public override string ToString()
        {
            return $"Type: {typeof(T).Name}, Count: {count}";
        }
    }
}
