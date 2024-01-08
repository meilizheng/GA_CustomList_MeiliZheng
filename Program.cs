namespace GA_CustomList_MeiliZheng
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomList<string> fruitList = new CustomList<string>();

            fruitList.Add("Apple");
            fruitList.Add("Banana");
            fruitList.Add("Orange");

            fruitList.AddAtIndex("Mango", 1);

            fruitList.Remove("Banana");

            Console.WriteLine($"Count: {fruitList.Count}");
            Console.WriteLine($"Item at index 1: {fruitList.GetItem(1)}");
            Console.WriteLine($"List: {fruitList}");
        }
    }
}