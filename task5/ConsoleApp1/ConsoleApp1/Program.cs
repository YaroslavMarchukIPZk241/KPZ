using ConsoleApp1;
using System;
public enum DisplayType
{
    Block,
    Inline
}

public enum ClosingType
{
    Single,
    Paired
}

class Program
{
        static void Main(string[] args)
        {
            var ul = new LightElementNode("ul", DisplayType.Block, ClosingType.Paired);
            ul.CssClasses.Add("menu");

            var li1 = new LightElementNode("li", DisplayType.Block, ClosingType.Paired);
            li1.AddChild(new LightTextNode("Home"));

            var li2 = new LightElementNode("li", DisplayType.Block, ClosingType.Paired);
            li2.AddChild(new LightTextNode("About"));

            var li3 = new LightElementNode("li", DisplayType.Block, ClosingType.Paired);
            li3.AddChild(new LightTextNode("Contact"));

            ul.AddChild(li1);
            ul.AddChild(li2);
            ul.AddChild(li3);

            Console.WriteLine("OuterHTML:");
            Console.WriteLine(ul.OuterHTML);

            Console.WriteLine("\nInnerHTML:");
            Console.WriteLine(ul.InnerHTML);
        }
    
}

