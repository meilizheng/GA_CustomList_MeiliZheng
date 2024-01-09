using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_CustomList_MeiliZheng
{
    //Created a CustomList class with generic type parameter
    public class CustomList<T> 
    {
        //declare the field
        private T[] fruits;
        private int count;

        //This is the constructor initializer. It's invoking CustomList(int initialSize). 
        //it's calling the constructor that takes an int parameter with the value 10.
        public CustomList() : this(10) { } 

        //Constructor
        public CustomList(int initialSize) 
        {
            fruits = new T[initialSize];
        }

        //Property
        public int Count => count;

        //Add Method, use to add new item to the list
        public void Add(T item)
        {
            CheckIntegrity();//Call CheckIntegrity Method
            fruits[count++] = item;
        }

        //AddAtIndex Method with add item by index
        public void AddAtIndex (T item, int index)
        {
            CheckIntegrity();
            if (index < 0 || index > count)//if index < 0 or > count, throw a out of range exception
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            // Shift existing elements to make space for the new added item.
            // Starting from the end of the array, move each element one position to the right.
            for (int i = count; i > index; i--) 
            {
                fruits[i] = fruits[i-1];
            }
            // Place the new item at the desired index in the array.
            fruits[index] = item;
            // Increment the count to reflect the addition of the new item.
            count++;
        }

        public bool Remove(T item)
        {
            // Use for loop to find the item in the array.
            for (int i = 0; i < count; i++)
            {
                // Check if the current element equals the item to be removed.
                if (fruits[i].Equals(item))
                {
                    // Shift elements to the left to fill the gap left by the removed item.
                    for (int j = i; j < count-1; j++)
                    {
                        fruits[j] = fruits[j+1];
                    }
                    // Update the count to reflect the removal of the item.
                    count--;
                    // successful removal.
                    return true;
                }
            }
            // The item was not found in the array.
            return false; 
        }

        // Check if the array is approaching its capacity, and if so, double its size.
        private void CheckIntegrity()
        {
            // If the count is more than 90% of the array's length, indicating it's nearing capacity.
            if (count > 0.9 * fruits.Length)
            {
                // Create a larger array with double the current capacity.
                T[] largerArray = new T[fruits.Length * 2];
                // Copy the existing elements from the current array to the larger array.
                Array.Copy(fruits, largerArray, count);
                // Update the reference to the array to point to the larger one.
                fruits = largerArray;
            }
        }

        // Retrieve the element at the specified index in the array.
        public T GetItem(int index)
        {
            // Check if the index is out of bounds.
            if (index < 0 || index > count)
            {
                // Throw an exception to indicate an invalid index.
                throw new AbandonedMutexException(nameof(index));
            }
            // Return the element at the specified index.
            return fruits[index];
        }


        public override string ToString()
        {
            // Use string.Join to concatenate elements with new lines, up to the current count.
            string itemsString = string.Join(Environment.NewLine, fruits.Take(count));
            // Construct a formatted string including type, count, and elements.
            return $"Type: {typeof(T).Name}, Count: {count}{Environment.NewLine}{itemsString}";
        }

    }
}
