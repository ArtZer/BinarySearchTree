
Console.WriteLine("Hello, World!");
var tree = new BinarySearchTree.Tree<int>();
tree.Add(5);
tree.Add(3);
tree.Add(7);
tree.Add(1);
tree.Add(2);
tree.Add(8);
tree.Add(6);
tree.Add(9);
tree.Add(4);

foreach (var item in tree.Preorder())
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