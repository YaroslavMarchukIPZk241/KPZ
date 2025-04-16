using System;
using System.Collections.Generic;
using System.Text;

namespace LightHTML
{
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
    public abstract class LightNode
    {
        public abstract string OuterHTML { get; }
        public abstract string InnerHTML { get; }
    }

    public class LightTextNode : LightNode
    {
        public string Text { get; set; }

        public LightTextNode(string text)
        {
            Text = text;
        }

        public override string OuterHTML => Text;
        public override string InnerHTML => Text;
    }
    public class LightElementNode : LightNode
    {
        public string TagName { get; set; }
        public DisplayType Display { get; set; }
        public ClosingType Closing { get; set; }
        public List<string> CssClasses { get; set; } = new();
        public List<LightNode> Children { get; set; } = new();

        public LightElementNode(string tagName, DisplayType display, ClosingType closing)
        {
            TagName = tagName;
            Display = display;
            Closing = closing;
        }

        public void AddChild(LightNode child)
        {
            Children.Add(child);
        }

        public override string InnerHTML
        {
            get
            {
                StringBuilder sb = new();
                foreach (var child in Children)
                {
                    sb.Append(child.OuterHTML);
                }
                return sb.ToString();
            }
        }

        public override string OuterHTML
        {
            get
            {
                var classAttr = CssClasses.Count > 0 ? $" class=\"{string.Join(" ", CssClasses)}\"" : "";

                if (Closing == ClosingType.Single)
                {
                    return $"<{TagName}{classAttr} />";
                }
                else
                {
                    return $"<{TagName}{classAttr}>{InnerHTML}</{TagName}>";
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {
            var div = new LightElementNode("div", DisplayType.Block, ClosingType.Paired);
            div.CssClasses.Add("container");

            var h1 = new LightElementNode("h1", DisplayType.Block, ClosingType.Paired);
            h1.CssClasses.Add("title");
            h1.AddChild(new LightTextNode("Вітаємо на сайті!"));

            var ul = new LightElementNode("ul", DisplayType.Block, ClosingType.Paired);
            ul.CssClasses.Add("menu");

            var li1 = new LightElementNode("li", DisplayType.Block, ClosingType.Paired);
            li1.AddChild(new LightTextNode("Головна"));

            var li2 = new LightElementNode("li", DisplayType.Block, ClosingType.Paired);
            li2.AddChild(new LightTextNode("Про нас"));

            var li3 = new LightElementNode("li", DisplayType.Block, ClosingType.Paired);
            li3.AddChild(new LightTextNode("Контакти"));

            ul.AddChild(li1);
            ul.AddChild(li2);
            ul.AddChild(li3);
            div.AddChild(h1);
            div.AddChild(ul);

            Console.WriteLine("InnerHTML:");
            Console.WriteLine(div.InnerHTML);
            Console.WriteLine("\nOuterHTML:");
            Console.WriteLine(div.OuterHTML);
        }
    }
}