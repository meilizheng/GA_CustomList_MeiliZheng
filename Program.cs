namespace GA_CustomList_MeiliZheng
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a custom list to store string elements.
            CustomList<string> fruitList = new CustomList<string>();

            //Add various fruits to the list.
            fruitList.Add("Apple");
            fruitList.Add("Banana");
            fruitList.Add("Watermelon");
            fruitList.Add("Kiwi");
            fruitList.Add("Cheery");
            fruitList.Add("Pear");
            fruitList.Add("Blueberry");
            fruitList.Add("Strawberry");
            fruitList.Add("Pineapple");

            // Insert "Mango" at index 1.
            fruitList.AddAtIndex("Mango", 1);

            // Remove "Banana" from the list.
            fruitList.Remove("Banana");

            // Display the count of elements in the list.
            Console.WriteLine($"Count: {fruitList.Count}");

            // Retrieve and display the item at index 1.
            Console.WriteLine($"Item at index 1: {fruitList.GetItem(1)}");

            // Display the string representation of the list.
            Console.WriteLine($"List: {fruitList}");
        }
    }
}