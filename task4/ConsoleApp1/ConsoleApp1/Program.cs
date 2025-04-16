using System;
using System.Collections.Generic;

public class Virus : ICloneable
{
    public string Name { get; set; }
    public List<Virus> Children { get; set; } = new List<Virus>();

    public Virus(string name)
    {
        Name = name;
    }
    public void AddChild(Virus child)
    {
        Children.Add(child);
    }
    public object Clone()
    {
        Virus clone = new Virus(this.Name + "_clone");

        foreach (var child in Children)
        {
            clone.AddChild((Virus)child.Clone());
        }

        return clone;
    }
    public void PrintHierarchy(string indent = "")
    {
        Console.WriteLine(indent + Name);
        foreach (var child in Children)
        {
            child.PrintHierarchy(indent + "  ");
        }
    }
}

class Program
{
    static void Main()
    {
        Virus parent = new Virus("ParentVirus");
        Virus child1 = new Virus("ChildVirus1");
        Virus child2 = new Virus("ChildVirus2");
        Virus grandChild1 = new Virus("GrandChildVirus1");
        Virus grandChild2 = new Virus("GrandChildVirus2");
        child1.AddChild(grandChild1);
        child2.AddChild(grandChild2);
        parent.AddChild(child1);
        parent.AddChild(child2);

        Console.WriteLine("Original virus family:");
        parent.PrintHierarchy();
        Virus clonedParent = (Virus)parent.Clone();

        Console.WriteLine("\nCloned virus family:");
        clonedParent.PrintHierarchy();
    }
}
