
using System.Collections;

Console.WriteLine("Hello, World!");
var tree = new BinarySearchTree.Tree<int>();
tree.Add(5);
tree.Add(3);
tree.Add(7);
tree.Add(1);
tree.Add(2);
tree.Add(6);
tree.Add(9);
tree.Add(8);
tree.Add(4);

Console.WriteLine();

foreach (var item in tree.PreOrder())
{
    Console.Write(item + ", ");
}

Console.WriteLine();

foreach (var item in tree.PostOrder())
{
    Console.Write(item + ", ");
}

Console.WriteLine();

foreach (var item in tree.InOrder())
{
    Console.Write(item + ", ");
}

Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Поиск:");
Console.WriteLine(tree.Search(7));


Console.WriteLine("Поиск родителя четверки:");
Console.WriteLine(tree.SearchParent(4));

Console.WriteLine("Удаление элемента с левым поддеревом, но без правого:");
Console.WriteLine("8 имеет родителя = " + tree.SearchParent(8));
tree.Delete(9);

foreach (var item in tree.PreOrder())
{
    Console.Write(item + ", ");
}

Console.WriteLine();
Console.WriteLine("Пример IComparable:");
#region Example IComparable

ArrayList temperatures = new ArrayList();
// Initialize random number generator.
Random rnd = new Random();

// Generate 10 temperatures between 0 and 100 randomly.
for (int ctr = 1; ctr <= 10; ctr++)
{
    int degrees = rnd.Next(0, 100);
    Temperature temp = new Temperature(degrees);
    temperatures.Add(temp);
    int i = temp.CompareTo(new Temperature(50));
}

// Sort ArrayList.
temperatures.Sort();

foreach (Temperature temp in temperatures)
    Console.WriteLine(temp.Fahrenheit);

Console.ReadLine();

public class Temperature : IComparable
{
    public double temperatureF;

    public Temperature(int temper)
    {
        temperatureF = temper;
    }

    public int CompareTo(object? obj)
    {
        if (obj == null) return 1;

        Temperature otherTemperature = obj as Temperature;
        if (otherTemperature != null)
            return this.temperatureF.CompareTo(otherTemperature.temperatureF);
        else
            throw new ArgumentException("Object is not a Temperature");


        throw new NotImplementedException();
    }
    public double Fahrenheit
    {
        get
        {
            return this.temperatureF;
        }
        set
        {
            this.temperatureF = value;
        }
    }
}

#endregion